using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrbit : MonoBehaviour
{
  public float Speed;
  private bool CooledDown = true;

  void Start()
  {
    CooledDown = true;
    GameController.control.ReverseText.text = "Reverse Ready";
  }

  void FixedUpdate()
  {
    transform.Rotate(0f, Speed, 0f, Space.Self);
  }

  void Update()
  {
    if(Input.GetKeyDown("space"))
    {
      RotateDirection();
    }
  }

  void RotateDirection()
  {
    if(CooledDown)
    {
      CooledDown = false;
      Speed = Speed * -1;
      StartCoroutine(RotateDirectionCooldown());
    }
  }

  IEnumerator RotateDirectionCooldown()
  {
    GameController.control.ReverseText.text = "3";
    yield return new WaitForSeconds(1f);
    GameController.control.ReverseText.text = "2";
    yield return new WaitForSeconds(1f);
    GameController.control.ReverseText.text = "1";
    yield return new WaitForSeconds(1f);
    GameController.control.ReverseText.text = "Reverse Ready";
    CooledDown = true;
    StopCoroutine(RotateDirectionCooldown());
  }
}
