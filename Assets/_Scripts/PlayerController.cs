using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody rb;
  public bool Nightime = false;

  void Awake()
  {
    rb = GetComponent<Rigidbody>();
  }

  void Update()
  {
    if(Input.GetKeyDown("up"))
    {
      transform.Translate(0f, 0f, 3f);
    }
    if(Input.GetKeyDown("down"))
    {
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
  }
  void OnTriggerStay(Collider other) {
    if(other.gameObject.tag == "NightTime")
      Nightime = true;
    if(other.gameObject.tag == "DayTime")
      Nightime = false;
  }

}
