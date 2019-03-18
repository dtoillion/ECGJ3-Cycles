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

  public GameObject GameOverScreen;
  public GameObject GameWinScreen;
  public GameObject Enemy;
  public GameObject Player;

  public float Orbs = 0f;
  public float Stage = 1f;
  public float Health = 3f;
  public float StagesToWin = 10f;

  void Awake() {
    control = this;
    StartCoroutine(SpawnRings());
  }

  void Start() {
    Instantiate(Player, transform.position, transform.rotation);
  }

  void FixedUpdate() {
    OrbsText.text = "Orbs: " + Orbs + " of " + Stage;
    StageText.text = "Stage: " + Stage + " of " + StagesToWin;
    HealthText.text = "Health: " + Health;
    if(Orbs == Stage)
      AdvanceStage();
    if(Health == 0)
      GameOver();
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
    GameOverScreen.SetActive(true);
  }

  public void GameWin() {
    GameWinScreen.SetActive(true);
  }

  public void Retry() {
    GameOverScreen.SetActive(false);
    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
  }

  IEnumerator SpawnRings() {
    yield return new WaitForSeconds(2f);
    for (int i = 0; i < Stage; i++) {
      Instantiate(Enemy, transform.position, transform.rotation);
      yield return new WaitForSeconds(1.5f);
    }
  }
}
