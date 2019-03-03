using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrbit : MonoBehaviour
{
  public float Speed;

  void FixedUpdate()
  {
    transform.Rotate(0f, Speed, 0f, Space.Self);
  }

  void Update()
  {
    if(Input.GetKeyDown("space"))
    {
      Speed = Speed * -1;
    }
  }
}
