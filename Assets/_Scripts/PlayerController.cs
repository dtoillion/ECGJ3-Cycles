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

  public GameObject PlayerExplosion;

  Renderer rend;

  void Awake()
  {
    rb = GetComponent<Rigidbody>();
    rend = GetComponent<Renderer> ();
  }

  void Update()
  {
    if(Input.GetKeyDown("up") && (moveCount <= 3) && (!GameController.control.Paused))
    {
      moveCount += 1;
      SoundEffectsManager.soundControl.PlayerUpSound();
      transform.Translate(0f, 0f, 3f);
    }
    if(Input.GetKeyDown("down") && (moveCount > 0) && (!GameController.control.Paused))
    {
      moveCount -= 1;
      SoundEffectsManager.soundControl.PlayerDownSound();
      transform.Translate(0f, 0f, -3f);
    }
  }

  void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag == "Enemy") {
      if(Nightime) {
        GameController.control.Health -= 1f;
        SoundEffectsManager.soundControl.PlayerHitSound();
        CameraShake.Shake(0.25f, 1f);
      } else {
        GameController.control.Orbs += 1f;
        SoundEffectsManager.soundControl.CollectOrbSound();
        Instantiate(PlayerExplosion, transform.position, Quaternion.identity);
        Destroy(other.transform.parent.gameObject);
      }
    }
  }
  void OnTriggerStay(Collider other) {
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
