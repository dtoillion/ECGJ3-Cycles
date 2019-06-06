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

  public GameObject PlayerHitEffects;
  public GameObject OrbCollectedEffects;

  Renderer rend;

  void Awake()
  {
    rb = GetComponent<Rigidbody>();
    rend = GetComponent<Renderer> ();
  }

  void Start()
  {
    rend.material.color = nightColor;
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
        Instantiate(PlayerHitEffects, transform.position, Quaternion.identity);
        CameraShake.Shake(0.75f, 1.2f);
      } else {
        GameController.control.Orbs += 1f;
        SoundEffectsManager.soundControl.CollectOrbSound();
        Instantiate(OrbCollectedEffects, transform.position, Quaternion.identity);
        CameraShake.Shake(0.2f, 0.4f);
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
