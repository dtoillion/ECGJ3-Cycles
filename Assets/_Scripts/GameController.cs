using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public static GameController control = null;
  public Text HealthText;
  public Text ScoreText;
  public Text StageText;
  public Text ReverseText;
  public Text GameOverScoreText;

  public GameObject EscapeMenuScreen;
  public GameObject GameOverScreen;
  public GameObject HighScoreScreen;
  public GameObject GameStartScreen;
  public GameObject GameHintsScreen;
  public GameObject Enemy;
  public GameObject Player;

  public float Orbs = 0f;
  public int Stage = 1;
  public float Health = 3f;

  public string Username = "";

  public bool GameStarted = false;
  public bool GameRunning = false;
  public bool Paused = false;

  void Awake() {
    control = this;
  }

  void Start() {
    GameStartScreen.SetActive(true);
  }

  void Update() {
    if(Input.GetKeyDown("escape") && (GameRunning)) {
      PauseGame();
    }

    if(GameRunning) {
      ScoreText.text = TotalScore.instance.totalScore.ToString();
      StageText.text = "Stage: " + Stage;
      HealthText.text = "Health: " + Health;
    }

    if(Orbs == Stage) {
      AdvanceStage();
    }

    if((Health <= 0) && (GameRunning)) {
      GameOver();
    }
  }

  IEnumerator SetupGame() {
    GameBoard.instance.DayNightCycle();
    StageText.text = "";
    ReverseText.text = "";
    ScoreText.text = TotalScore.instance.totalScore.ToString();
    HealthText.text = "Health: " + Health;
    GameRunning = true;
    Instantiate(Player, transform.position, transform.rotation);
    yield return new WaitForSeconds(1f);
    StartCoroutine(SpawnRings());
    yield return new WaitForSeconds(6f);
    GameHintsScreen.SetActive(false);
  }

  void AdvanceStage() {
    SoundEffectsManager.soundControl.StageClearedSound();
    Stage += 1;
    Orbs = 0f;
    GameBoard.instance.DayNightCycle();
    StartCoroutine(SpawnRings());
  }

  IEnumerator SpawnRings() {
    for (int i = 0; i < Stage; i++) {
      Instantiate(Enemy, transform.position, transform.rotation);
      yield return new WaitForSeconds(0.5f);
    }
  }

  public void PauseGame() {
    if(!Paused) {
      Paused = true;
      Time.timeScale = 0;
      SoundEffectsManager.soundControl.PauseSound();
      EscapeMenuScreen.SetActive(true);
    } else {
      Paused = false;
      Time.timeScale = 1;
      SoundEffectsManager.soundControl.PauseSound();
      EscapeMenuScreen.SetActive(false);
    }
  }

  public void GameStart() {
    Username = PlayerPrefs.GetString("Name", "UNDEFINED");
    HighScoreScreen.SetActive(false);
    GameStartScreen.SetActive(false);
    GameHintsScreen.SetActive(true);
    SoundEffectsManager.soundControl.PauseSound();
    GameStarted = true;
    StartCoroutine(SetupGame());
  }

  public void GameOver() {
    GameRunning = false;
    HighScores.instance.AddNewHighScore(Username, TotalScore.instance.totalScore, Stage);
    GameOverScreen.SetActive(true);
    GameOverScoreText.text = "Score: " + TotalScore.instance.totalScore.ToString();
    SoundEffectsManager.soundControl.GameOverSound();
    Time.timeScale = 0;
  }

  public void Retry() {
    GameOverScreen.SetActive(false);
    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1;
  }

  public void QuitGame() {
    Application.Quit();
  }

  public void ShowHighscores() {
    SoundEffectsManager.soundControl.PauseSound();
    if(!HighScoreScreen.active) {
      HighScores.instance.DownloadHighscores();
      HighScoreScreen.SetActive(true);
    } else {
      HighScoreScreen.SetActive(false);
    }
  }

}
