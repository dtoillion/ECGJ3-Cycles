using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public Color nightColor;
  public Color dayColor;
  Renderer rend;

  void Start()
  {
    rend = GetComponent<Renderer> ();
  }

  void OnTriggerStay(Collider other)
  {
    if (other.gameObject.tag == "NightTime")
      rend.material.color = nightColor;
    if (other.gameObject.tag == "DayTime")
      rend.material.color = dayColor;
  }

}
