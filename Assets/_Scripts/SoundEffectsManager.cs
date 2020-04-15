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

  void Update() {
    if(TotalScore.instance.scoreMultiplier < 2) {
      audioSrc.pitch = 1;
    }
  }

  public void GameOverSound(){
    audioSrc.clip = audioClips[0];
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }
  public void PlayerHitSound(){
    audioSrc.clip = audioClips[1];
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }
  public void CollectOrbSound(){
    if(TotalScore.instance.scoreMultiplier >= 2) {
      audioSrc.pitch += 0.1F;
    }
    audioSrc.clip = audioClips[2];
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }
  public void ReverseSound(){
    audioSrc.clip = audioClips[3];
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }
  public void PlayerUpSound(){
    audioSrc.clip = audioClips[4];
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }
  public void PlayerDownSound(){
    audioSrc.clip = audioClips[5];
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }
  public void CoolDownSound(){
    audioSrc.clip = audioClips[6];
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }
  public void SpawnSound(){
    audioSrc.clip = audioClips[7];
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }
  public void PauseSound(){
    audioSrc.clip = audioClips[8];
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }
  public void StageClearedSound(){
   audioSrc.clip = audioClips[9];
   audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }

}
