using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffects : MonoBehaviour
{
  private float interval = 0.01f;

  void OnTriggerEnter(Collider other) {
    if((other.gameObject.tag == "NightTime") || (other.gameObject.tag == "DayTime")) {
      StartCoroutine(Pulse());
    }
  }

  IEnumerator Pulse() {
    transform.localScale -= new Vector3(0.1f, 0f, 0.1f);
    yield return new WaitForSeconds(interval);
    transform.localScale += new Vector3(0.1f, 0f, 0.1f);
    yield return new WaitForSeconds(interval);
    transform.localScale += new Vector3(0.1f, 0f, 0.1f);
    yield return new WaitForSeconds(interval);
    transform.localScale += new Vector3(0.1f, 0f, 0.1f);
    yield return new WaitForSeconds(interval);
    transform.localScale += new Vector3(0.1f, 0f, 0.1f);
    yield return new WaitForSeconds(interval);
    transform.localScale += new Vector3(0.1f, 0f, 0.1f);
    yield return new WaitForSeconds(interval);
    transform.localScale += new Vector3(0.1f, 0f, 0.1f);
    yield return new WaitForSeconds(interval);
    transform.localScale -= new Vector3(0.1f, 0f, 0.1f);
    yield return new WaitForSeconds(interval);
    transform.localScale -= new Vector3(0.1f, 0f, 0.1f);
    yield return new WaitForSeconds(interval);
    transform.localScale -= new Vector3(0.1f, 0f, 0.1f);
    yield return new WaitForSeconds(interval);
    transform.localScale -= new Vector3(0.1f, 0f, 0.1f);
    yield return new WaitForSeconds(interval);
    transform.localScale -= new Vector3(0.1f, 0f, 0.1f);
    yield return new WaitForSeconds(interval);
    transform.localScale -= new Vector3(0.1f, 0f, 0.1f);
    yield return new WaitForSeconds(interval);
    transform.localScale += new Vector3(0.1f, 0f, 0.1f);
    StopCoroutine(Pulse());
  }

}
