using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  Color dayColor = new Color(1f, 0.2470588f, 0.2039216f, 1f);
  Color nightColor = new Color(0.05882353f, 0.7372549f, 0.9764706f, 1f);
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
