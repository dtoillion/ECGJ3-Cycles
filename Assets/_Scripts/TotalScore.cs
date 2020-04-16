using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
  public int totalScore;
  public int scoreMultiplier;

  public Text MultiplierText;

  public static TotalScore instance;

  void Start() {
    instance = this;
    totalScore = 0;
    scoreMultiplier = 1;
    MultiplierText.text = "";
  }

  public void UpdateTotalScore(int amountToAdd) {
    StopCoroutine("MultiplierReset");
    totalScore += (amountToAdd * scoreMultiplier);
    SoundEffectsManager.soundControl.CollectOrbSound();
    scoreMultiplier += 1;
    StartCoroutine("MultiplierReset");
  }

  IEnumerator MultiplierReset() {
    MultiplierText.text = "x" + scoreMultiplier;
    yield return new WaitForSeconds(4F);
    scoreMultiplier = 1;
    MultiplierText.text = "";
  }

}
