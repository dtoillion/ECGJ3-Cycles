using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrbit : MonoBehaviour
{
  public GameObject Enemy;

  private float MaxDistanceFromCenter = 15f;
  private float MinDistanceFromCenter = 3f;
  private float DistanceFromCenter;
  private float SpeedModifier;

  void Start()
  {
    float randomDistance = Random.Range(MinDistanceFromCenter, MaxDistanceFromCenter);
    float numSteps = Mathf.Floor(randomDistance / 3f);
    float DistanceFromCenter = numSteps * 3f;
    Enemy.transform.Translate(0f, 0f, DistanceFromCenter, Space.Self);
    SpeedModifier = Random.Range(-1f, 1f);
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    transform.Rotate(0f, 0.9f * SpeedModifier, 0f, Space.Self);
  }
}
