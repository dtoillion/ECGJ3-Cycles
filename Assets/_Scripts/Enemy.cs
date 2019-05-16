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
  private Collider sC;
  Renderer rend;

  void Start()
  {
    rend = GetComponent<Renderer> ();
    sC = GetComponent<Collider> ();
    sC.enabled = false;
    Dangerous = false;
    StartCoroutine(SpawnSafe());
  }

  IEnumerator SpawnSafe()
  {
    rend.material.color = spawnColorA;
    yield return new WaitForSeconds(0.3f);
    rend.material.color = spawnColorB;
    yield return new WaitForSeconds(0.3f);
    rend.material.color = spawnColorA;
    yield return new WaitForSeconds(0.3f);
    rend.material.color = spawnColorB;
    yield return new WaitForSeconds(0.3f);
    rend.material.color = spawnColorA;
    yield return new WaitForSeconds(0.3f);
    Dangerous = true;
    sC.enabled = true;
    StopCoroutine(SpawnSafe());
  }

  void OnTriggerStay(Collider other)
  {
    if ((other.gameObject.tag == "NightTime") && (Dangerous))
      rend.material.color = nightColor;
    if ((other.gameObject.tag == "DayTime") && (Dangerous))
      rend.material.color = dayColor;
  }

}
