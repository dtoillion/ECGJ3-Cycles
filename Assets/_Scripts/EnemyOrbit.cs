using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrbit : MonoBehaviour
{
  public GameObject Enemy;

  private float MaxDistanceFromCenter = 15f;
  private float MinDistanceFromCenter = 6f;
  private float DistanceFromCenter;
  private float Speed;

  void Start()
  {
    float randomDistance = Random.Range(MinDistanceFromCenter, MaxDistanceFromCenter);
    float numSteps = Mathf.Floor(randomDistance / 3f);
    float DistanceFromCenter = numSteps * 3f;
    Enemy.transform.Translate(0f, 0f, DistanceFromCenter, Space.Self);
    Speed = Random.Range(0.1f, 2f);
  }

  void FixedUpdate()
  {
    transform.Rotate(0f, Speed, 0f, Space.Self);
  }
}
