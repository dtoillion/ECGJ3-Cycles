using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody rb;
  public bool Nightime = false;
  private int moveCount = 0;

  public Color nightColor;
  public Color dayColor;

  Renderer rend;

  void Awake()
  {
    rb = GetComponent<Rigidbody>();
    rend = GetComponent<Renderer> ();
  }

  void Update()
  {
    if(Input.GetKeyDown("up") && (moveCount <= 3))
    {
      moveCount += 1;
      transform.Translate(0f, 0f, 3f);
    }
    if(Input.GetKeyDown("down") && (moveCount > 0))
    {
      moveCount -= 1;
      transform.Translate(0f, 0f, -3f);
    }
  }

  void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag == "Enemy") {
      if(Nightime) {
        GameController.control.Health -= 1f;
      } else {
        GameController.control.Orbs += 1f;
        Destroy(other.gameObject);
      }
    }
    if(other.gameObject.tag == "NightTime") {
      rend.material.color = nightColor;
      Nightime = true;
    }
    if(other.gameObject.tag == "DayTime") {
      rend.material.color = dayColor;
      Nightime = false;
    }
  }

}
