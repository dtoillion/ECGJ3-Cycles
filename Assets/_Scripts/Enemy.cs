using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  Color dayColor = Color.red;
  Color nightColor = Color.blue;
  Renderer rend;

  void Start()
  {
    rend = GetComponent<Renderer> ();
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "NightTime")
      rend.material.color = nightColor;
    if (other.gameObject.tag == "DayTime")
      rend.material.color = dayColor;
  }

}
