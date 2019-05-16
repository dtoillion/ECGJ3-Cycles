using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public static GameController control;
  public Text HealthText;
  public Text OrbsText;
  public Text StageText;
  public Text ReverseText;

  public GameObject GameOverScreen;
  public GameObject GameWinScreen;
  public GameObject Enemy;
  public GameObject Player;

  public float Orbs = 0f;
  public float Stage = 1f;
  public float Health = 3f;
  public float StagesToWin = 10f;

  public bool GameStarted = false;

  void Awake() {
    StartCoroutine(SetupGame());
  }

  void FixedUpdate() {
    if(GameStarted) {
      OrbsText.text = "Orbs: " + Orbs + " of " + Stage;
      StageText.text = "Stage: " + Stage + " of " + StagesToWin;
      HealthText.text = "Health: " + Health;
    }
    if(Orbs == Stage)
      AdvanceStage();
    if((Health == 0) && (GameStarted)){
      GameOver();
    }
  }

  IEnumerator SetupGame() {
    control = this;
    GameController.control.ReverseText.text = "Space to reverse";
    OrbsText.text = "Orbs: " + Orbs + " of " + Stage;
    HealthText.text = "Health: " + Health;
    StageText.text = "Ready?";
    yield return new WaitForSeconds(2f);
    StageText.text = "3";
    yield return new WaitForSeconds(1f);
    StageText.text = "2";
    yield return new WaitForSeconds(1f);
    StageText.text = "1";
    yield return new WaitForSeconds(1f);
    StageText.text = "Go!";
    Instantiate(Player, transform.position, transform.rotation);
    yield return new WaitForSeconds(1f);
    GameStarted = true;
    StartCoroutine(SpawnRings());
    StopCoroutine(SetupGame());
  }

  void AdvanceStage() {
    if(Stage == StagesToWin) {
      GameWin();
    } else {
      Stage += 1f;
      Orbs = 0f;
      StartCoroutine(SpawnRings());
    }
  }

  public void GameOver() {
    GameStarted = false;
    GameOverScreen.SetActive(true);
    SoundEffectsManager.soundControl.GameOverSound();
    Time.timeScale = 0;
  }

  public void GameWin() {
    GameWinScreen.SetActive(true);
  }

  public void Retry() {
    GameOverScreen.SetActive(false);
    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1;
  }

  IEnumerator SpawnRings() {
    yield return new WaitForSeconds(3f);
    for (int i = 0; i < Stage; i++) {
      Instantiate(Enemy, transform.position, transform.rotation);
      yield return new WaitForSeconds(1.5f);
    }
  }
}
