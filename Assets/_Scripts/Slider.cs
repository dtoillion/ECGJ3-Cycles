using System.Collections;
using UnityEngine;

public class Slider : MonoBehaviour {

  private AudioSource SliderAudio;
  private Light SliderLight;

  public float Speed;
  public float WaitTime;

  private Vector3 PositionOne;
  private Vector3 PositionTwo;

  public float XOne;
  public float XTwo;

  public float YOne;
  public float YTwo;

  public float ZOne;
  public float ZTwo;

  void Start() {
    SliderAudio = GetComponent<AudioSource>();
    SliderLight = GetComponent<Light>();
    PositionOne = new Vector3(transform.position.x + XOne, transform.position.y + YOne, transform.position.z + ZOne);
    PositionTwo = new Vector3(transform.position.x + XTwo, transform.position.y + YTwo, transform.position.z + ZTwo);
  }

  void Update() {
    transform.position = Vector3.Lerp (PositionOne, PositionTwo, Mathf.PingPong(Time.time * Speed, WaitTime));
  }

  void OnCollisionExit(Collision col) {
    if(col.gameObject.tag == "GolfBall") {
      SliderLight.intensity = 0f;
    }
  }

  void OnCollisionEnter(Collision col) {
    if((col.gameObject.tag == "GolfBall") && (!SliderAudio.isPlaying)) {
      SliderAudio.Play();
      SliderLight.intensity = 2f;
    }
  }

}
