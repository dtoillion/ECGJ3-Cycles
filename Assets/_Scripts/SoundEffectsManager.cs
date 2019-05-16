using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
  AudioSource audio;
  public AudioClip[] audioClips;
  public static SoundEffectsManager soundControl;

  void Start()
  {
    soundControl = this;
    audio = GetComponent<AudioSource>();
  }

  public void GameOverSound(){
    audio.clip = audioClips[0];
    audio.Play();
  }
  public void PlayerHitSound(){
    audio.clip = audioClips[1];
    audio.Play();
  }
  public void CollectOrbSound(){
    audio.clip = audioClips[2];
    audio.Play();
  }
  public void ReverseSound(){
    audio.clip = audioClips[3];
    audio.Play();
  }
  public void PlayerUpSound(){
    audio.clip = audioClips[4];
    audio.Play();
  }
  public void PlayerDownSound(){
    audio.clip = audioClips[5];
    audio.Play();
  }
  public void CoolDownSound(){
    audio.clip = audioClips[6];
    audio.Play();
  }
  public void SpawnSound(){
    audio.clip = audioClips[7];
    audio.Play();
  }

}
