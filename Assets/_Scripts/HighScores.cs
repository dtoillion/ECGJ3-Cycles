using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScores : MonoBehaviour
{
  const string privateCode = "LY2JNYrX-EmjomWfY_3_8AWnDKWglRx0Sgmd6AfeHguA";
  const string publicCode = "5e97014e0cf2aa0c289a29de";
  const string webURL = "https://www.dreamlo.com/lb/";

  public Highscore[] highscoresList;
  public static HighScores instance;
  public string Platform;

  public bool loading = false;
  public GameObject loadingIndicator;

  void Awake() {
    instance = this;
    loadingIndicator.SetActive(false);
    loading = false;
    if (Application.platform == RuntimePlatform.WindowsPlayer) {
      Platform = "Windows";
    } else if (Application.platform == RuntimePlatform.LinuxPlayer) {
      Platform = "Linux";
    } else if (Application.platform == RuntimePlatform.WebGLPlayer) {
      Platform = "Web Browser";
    } else {
      Platform = "Dev Mode";
    }
  }

  public void AddNewHighScore(string Username, int Score, int Stage) {
    StartCoroutine(UploadNewHighScore(Username, Score, Stage, Platform));
  }

  IEnumerator UploadNewHighScore(string Username, int Score, int Stage, string Platform) {
    loading = true;
    loadingIndicator.SetActive(true);

    WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(Username) + "/" + Score + "/" + Stage + "/" + Platform );
    yield return www;

    loading = false;
    loadingIndicator.SetActive(false);

    if(string.IsNullOrEmpty(www.error)) {
      print("upload succesful");
    } else {
      print("error uploading: " + www.error);
    }
  }

  public void DownloadHighscores() {
    StartCoroutine("DownloadHighScoresFromDatabase");
  }

  IEnumerator DownloadHighScoresFromDatabase() {
    loading = true;
    loadingIndicator.SetActive(true);

    WWW www = new WWW(webURL + publicCode + "/pipe/");
    yield return www;

    loading = false;
    loadingIndicator.SetActive(false);

    if(string.IsNullOrEmpty(www.error)) {
      FormatHighScores(www.text);
      DisplayHighscores.instance.OnHighscoresDownloaded(highscoresList);
    } else {
      print("error downloading: " + www.error);
    }
  }

  void FormatHighScores(string textStream) {
    string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
    highscoresList = new Highscore[entries.Length];

    for(int i = 0; i < entries.Length; i++) {
      string[] entryInfo = entries[i].Split(new char[] {'|'});
      string Username = entryInfo[0];
      int Score = int.Parse(entryInfo[1]);
      int Stage = int.Parse(entryInfo[2]);
      string Platform = entryInfo[3];
      highscoresList[i] = new Highscore(Username, Score, Stage, Platform);
    }
  }

  public void ReturnToMainMenu() {
    SceneManager.LoadScene("MainMenu");
  }

}

public struct Highscore {
  public string Username;
  public int Stage;
  public int Score;
  public string Platform;
  public Highscore(string _username, int _score, int _stage, string _platform) {
    Username = _username;
    Score = _score;
    Stage = _stage;
    Platform = _platform;
  }
}
