using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  Color nightColor = new Color(1f, 0.2470588f, 0.2039216f, 1f);
  Color dayColor = new Color(0.01960784f, 0.7686275f, 0.4196078f, 1f);
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
