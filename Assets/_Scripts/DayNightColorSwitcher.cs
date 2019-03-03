using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightColorSwitcher : MonoBehaviour
{
  public Color nightColor;
  public Color dayColor;
  SpriteRenderer rend;

  void Awake()
  {
    rend = GetComponent<SpriteRenderer> ();
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "NightTime")
      rend.color = nightColor;
    if (other.gameObject.tag == "DayTime")
      rend.color = dayColor;
  }
}
