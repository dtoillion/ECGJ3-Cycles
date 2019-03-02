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
  public GameObject Ring;
  public GameObject Player;
  private GameObject ObjectToDelete;

  public float Orbs = 0f;
  public float Stage = 1f;

  void Awake() {
    control = this;
    Time.timeScale = 1f;
    StartCoroutine(SpawnRings());
  }

  void Start() {
    Instantiate(Player, transform.position, transform.rotation);
  }

  void FixedUpdate() {
    OrbsText.text = "Orbs: " + Orbs + " of " + Stage;
    StageText.text = "Stage: " + Stage;
    if(Orbs == Stage)
      AdvanceStage();
  }

  void AdvanceStage() {
    Stage += 1f;
    Orbs = 0f;
    StartCoroutine(SpawnRings());
  }

  public void GameOver() {
    GameOverScreen.SetActive(true);
    Time.timeScale = 0f;
  }

  public void Retry() {
    GameOverScreen.SetActive(false);
    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
  }

  IEnumerator SpawnRings() {
    yield return new WaitForSeconds(1f);
    for (int i = 0; i < Stage; i++) {
      yield return new WaitForSeconds(1f);
      Instantiate(Ring, transform.position, transform.rotation);
    }
  }
}
