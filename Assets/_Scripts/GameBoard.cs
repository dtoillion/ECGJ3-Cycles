using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
  public float Speed;
  public GameObject[] Sections;
  public Material DayColor;
  public Material NightColor;

  public static GameBoard instance;

  void Start() {
    instance = this;
  }

  void Update() {
    transform.Rotate(0f, Speed, 0f, Space.Self);
  }

  public void DayNightCycle() {
    for (int i = 0; i < Sections.Length; i++) {
      int rando = Random.Range(1, 3);
      if(rando == 1) {
        Sections[i].GetComponent<Renderer>().material = NightColor;
        Sections[i].tag = "NightTime";
      } else {
        Sections[i].GetComponent<Renderer>().material = DayColor;
        Sections[i].tag = "DayTime";
      }
    }
    GameObject ControlSection = Sections[Random.Range(0, Sections.Length)];
    ControlSection.GetComponent<Renderer>().material = DayColor;
    ControlSection.tag = "DayTime";
    Speed -= 0.05F;
  }
}
