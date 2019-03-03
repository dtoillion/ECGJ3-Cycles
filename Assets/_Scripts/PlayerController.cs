using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody rb;
  public bool Nightime = false;
  private int moveCount = 0;

  void Awake()
  {
    rb = GetComponent<Rigidbody>();
  }

  void Update()
  {
    if(Input.GetKeyDown("up") && (moveCount <= 5))
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
        GameController.control.GameOver();
      } else {
        GameController.control.Orbs += 1f;
        Destroy(other.gameObject);
      }
    }
    if(other.gameObject.tag == "NightTime")
      Nightime = true;
    if(other.gameObject.tag == "DayTime")
      Nightime = false;
  }

}
