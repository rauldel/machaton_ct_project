using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
  public string name;
  public AudioClip audioClip;

  public AudioMixerGroup audioMixerGroup;

  [Range(0f, 1f)]
  public float volume = 0.7f;
  [Range(0.5f, 1.5f)]
  public float pitch = 1f;

  [Range(0f, 0.5f)]
  public float randomVolume = 0.1f;
  [Range(0f, 0.5f)]
  public float randomPitch = 0.1f;

  private AudioSource audioSource;

  public void SetSource(AudioSource source)
  {
    audioSource = source;
    audioSource.outputAudioMixerGroup = audioMixerGroup;
    source.clip = audioClip;
  }

  public void Play(bool looped)
  {
    audioSource.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
    audioSource.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
    audioSource.loop = looped;
    audioSource.Play();
  }

  public void Pause()
  {
    audioSource.Pause();
  }

  public void Stop()
  {
    audioSource.Stop();
  }

  public bool IsPlaying()
  {
    return audioSource.isPlaying;
  }
}
