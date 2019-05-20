using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
  AudioSource audioSrc;
  public AudioClip[] audioClips;
  public static SoundEffectsManager soundControl;

  void Start()
  {
    soundControl = this;
    audioSrc = GetComponent<AudioSource>();
  }

  public void GameOverSound(){
    audioSrc.clip = audioClips[0];
    audioSrc.Play();
  }
  public void PlayerHitSound(){
    audioSrc.clip = audioClips[1];
    audioSrc.Play();
  }
  public void CollectOrbSound(){
    audioSrc.clip = audioClips[2];
    audioSrc.Play();
  }
  public void ReverseSound(){
    audioSrc.clip = audioClips[3];
    audioSrc.Play();
  }
  public void PlayerUpSound(){
    audioSrc.clip = audioClips[4];
    audioSrc.Play();
  }
  public void PlayerDownSound(){
    audioSrc.clip = audioClips[5];
    audioSrc.Play();
  }
  public void CoolDownSound(){
    audioSrc.clip = audioClips[6];
    audioSrc.Play();
  }
  public void SpawnSound(){
    audioSrc.clip = audioClips[7];
    audioSrc.Play();
  }
  public void PauseSound(){
    audioSrc.clip = audioClips[8];
    audioSrc.Play();
  }

}
