using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSetter : MonoBehaviour
{
  void Start() {
    GetComponent<TextMesh>().text = ("+ " + (10 * (TotalScore.instance.scoreMultiplier - 1))).ToString();
  }

}
