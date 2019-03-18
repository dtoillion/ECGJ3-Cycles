using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrbit : MonoBehaviour
{
  public float Speed;
  private bool CooledDown = true;

  void Awake()
  {
    CooledDown = true;
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
    Debug.Log("Three");
    yield return new WaitForSeconds(1f);
    Debug.Log("Two");
    yield return new WaitForSeconds(1f);
    Debug.Log("One");
    yield return new WaitForSeconds(1f);
    Debug.Log("Cooled down");
    CooledDown = true;
    StopCoroutine(RotateDirectionCooldown());
  }
}
