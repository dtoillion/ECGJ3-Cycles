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
  public GameObject GameWinScreen;
  public GameObject GameStartScreen;
  public GameObject Enemy;
  public GameObject Player;

  public float Orbs = 0f;
  public float Stage = 1f;
  public float Health = 3f;
  public float StagesToWin = 10f;

  public bool GameStarted = false;
  public bool Paused = false;
  public bool Infinite = false;

  void Awake() {
    control = this;
  }

  void Update()
  {
    if(Input.GetKeyDown("escape") && (GameStarted))
    {
      PauseGame();
    }
  }

  void FixedUpdate() {
    if(GameStarted) {
      OrbsText.text = "Orbs: " + Orbs + " of " + Stage;
      if(Infinite) {
        StageText.text = "Stage: " + Stage;
      } else {
        StageText.text = "Stage: " + Stage + " of " + StagesToWin;
      }
      HealthText.text = "Health: " + Health;
    }
    if(Orbs == Stage)
      AdvanceStage();
    if((Health == 0) && (GameStarted)){
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
    GameStarted = true;
    Instantiate(Player, transform.position, transform.rotation);
    yield return new WaitForSeconds(0.5f);
    StartCoroutine(SpawnRings());
    StopCoroutine(SetupGame());
  }

  void AdvanceStage() {
    if((Stage == StagesToWin) && (!Infinite)) {
      GameWin();
    } else {
      Stage += 1f;
      Orbs = 0f;
      StartCoroutine(SpawnRings());
    }
  }

  public void PauseGame()
  {
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

  public void GameStartInfinite() {
    GameStartScreen.SetActive(false);
    Infinite = true;
    SoundEffectsManager.soundControl.PauseSound();
    StartCoroutine(SetupGame());

  }
  public void GameStartNormal() {
    GameStartScreen.SetActive(false);
    SoundEffectsManager.soundControl.PauseSound();
    StartCoroutine(SetupGame());
  }

  public void GameOver() {
    GameStarted = false;
    GameOverScreen.SetActive(true);
    GameOverScoreText.text = "Score: " + Stage;
    SoundEffectsManager.soundControl.GameOverSound();
    Time.timeScale = 0;
  }

  public void GameWin() {
    GameWinScreen.SetActive(true);
    Time.timeScale = 0;
  }

  public void Retry() {
    GameOverScreen.SetActive(false);
    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1;
  }

  IEnumerator SpawnRings() {
    for (int i = 0; i < Stage; i++) {
      yield return new WaitForSeconds(1.5f);
      Instantiate(Enemy, transform.position, transform.rotation);
      yield return new WaitForSeconds(0.5f);
    }
  }
}
