using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour
{
  public Text[] highscoreText;
  public static DisplayHighscores instance;

  void Start() {
    instance = this;

    for(int i = 0; i < highscoreText.Length; i++) {
      highscoreText[i].text = (i + 1) + ". " + "loading...";
    }
  }

  public void OnHighscoresDownloaded(Highscore[] highscoreList) {
    for(int i = 0; i < highscoreText.Length; i++) {
      highscoreText[i].text = (i + 1) + ". ";
      if(highscoreList.Length > i) {
        highscoreText[i].text +=
          highscoreList[i].Username + " - " +
          highscoreList[i].Score + "\n   Stage: " +
          highscoreList[i].Stage;
        if(highscoreList[i].Platform != "")
          highscoreText[i].text += " - " + highscoreList[i].Platform;
      } else {
        highscoreText[i].text += "AAA";
      }
    }
  }

}
