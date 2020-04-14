using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public static GameController control = null;
  public Text HealthText;
  public Text OrbsText;
  public Text StageText;
  public Text ReverseText;
  public Text GameOverScoreText;

  public GameObject MainMenuScreen;
  public GameObject GameOverScreen;
  public GameObject GameStartScreen;
  public GameObject Enemy;
  public GameObject Player;

  public float Orbs = 0f;
  public float Stage = 1f;
  public float Health = 3f;

  public bool GameStarted = false;
  public bool GameRunning = false;
  public bool Paused = false;

  void Awake() {
    control = this;
  }

  void Update() {
    if(Input.GetKeyDown("return") && (!GameStarted)) {
      GameStart();
    }

    if(Input.GetKeyDown("escape") && (GameRunning)) {
      PauseGame();
    }

    if(GameRunning) {
      OrbsText.text = "Orbs: " + Orbs + " of " + Stage;
      StageText.text = "Stage: " + Stage;
      HealthText.text = "Health: " + Health;
    }

    if(Orbs == Stage) {
      AdvanceStage();
    }

    if((Health == 0) && (GameRunning)) {
      GameOver();
    }
  }

  IEnumerator SetupGame() {
    GameController.control.ReverseText.text = "Space to reverse";
    OrbsText.text = "Orbs: " + Orbs + " of " + Stage;
    HealthText.text = "Health: " + Health;
    StageText.text = "";
    yield return new WaitForSeconds(1f);
    StageText.text = "Get Ready!";
    yield return new WaitForSeconds(2f);
    GameRunning = true;
    Instantiate(Player, transform.position, transform.rotation);
    yield return new WaitForSeconds(0.5f);
    StartCoroutine(SpawnRings());
  }

  void AdvanceStage() {
    SoundEffectsManager.soundControl.StageClearedSound();
    Stage += 1f;
    Orbs = 0f;
    StartCoroutine(SpawnRings());
  }

  IEnumerator SpawnRings() {
    for (int i = 0; i < Stage; i++) {
      Instantiate(Enemy, transform.position, transform.rotation);
      yield return new WaitForSeconds(0.5f);
    }
  }

  public void PauseGame() {
    if(!GameController.control.Paused) {
      GameController.control.Paused = true;
      Time.timeScale = 0;
      SoundEffectsManager.soundControl.PauseSound();
      MainMenuScreen.SetActive(true);
    } else {
      GameController.control.Paused = false;
      Time.timeScale = 1;
      SoundEffectsManager.soundControl.PauseSound();
      MainMenuScreen.SetActive(false);
    }
  }

  public void GameStart() {
    GameStarted = true;
    GameStartScreen.SetActive(false);
    SoundEffectsManager.soundControl.PauseSound();
    StartCoroutine(SetupGame());
  }

  public void GameOver() {
    GameRunning = false;
    GameOverScreen.SetActive(true);
    GameOverScoreText.text = "Score: " + Stage;
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

}
