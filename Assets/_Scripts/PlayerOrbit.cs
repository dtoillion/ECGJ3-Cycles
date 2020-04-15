using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrbit : MonoBehaviour
{
  public float Speed;
  private bool CooledDown = true;

  void Start()
  {
    SoundEffectsManager.soundControl.SpawnSound();
    CooledDown = true;
    GameController.control.ReverseText.text = "Reverse Ready";
  }

  void FixedUpdate()
  {
    transform.Rotate(0f, Speed, 0f, Space.Self);
  }

  void Update()
  {
    if(Input.GetKeyDown("space") && (!GameController.control.Paused))
    {
      RotateDirection();
    }
  }

  void RotateDirection()
  {
    if(CooledDown)
    {
      SoundEffectsManager.soundControl.ReverseSound();
      CooledDown = false;
      Speed = Speed * -1;
      StartCoroutine(RotateDirectionCooldown());
    } else {
      SoundEffectsManager.soundControl.CoolDownSound();
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
  }
}
