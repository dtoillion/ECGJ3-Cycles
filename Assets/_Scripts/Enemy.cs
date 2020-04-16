using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public Color nightColor;
  public Color dayColor;
  public Color spawnColorA;
  public Color spawnColorB;
  public bool Dangerous;
  private Collider enemyCollider;
  Renderer rend;

  void Start()
  {
    rend = GetComponent<Renderer> ();
    enemyCollider = GetComponent<Collider> ();
    enemyCollider.enabled = false;
    Dangerous = false;
    SoundEffectsManager.soundControl.SpawnSound();
    StartCoroutine(SpawnSafe());
  }

  IEnumerator DangerCooldown() {
    enemyCollider.enabled = false;
    yield return new WaitForSeconds(1f);
    enemyCollider.enabled = true;
    StopCoroutine(DangerCooldown());
  }

  IEnumerator SpawnSafe()
  {
    for (int i = 0; i < 2; i++) {
      rend.material.color = spawnColorA;
      yield return new WaitForSeconds(0.15f);
      rend.material.color = spawnColorB;
      yield return new WaitForSeconds(0.15f);
    }
    Dangerous = true;
    enemyCollider.enabled = true;
  }

  void OnTriggerEnter(Collider other) {
    if((other.gameObject.tag == "Player") && (Dangerous)) {
      StartCoroutine(DangerCooldown());
    }
    if ((other.gameObject.tag == "NightTime") && (Dangerous))
      rend.material.color = nightColor;
    if ((other.gameObject.tag == "DayTime") && (Dangerous))
      rend.material.color = dayColor;
  }

}
