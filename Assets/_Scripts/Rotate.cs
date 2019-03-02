using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
  public float Speed;

  void FixedUpdate()
  {
    transform.Rotate(0f, Speed, 0f, Space.Self);
  }
}
