using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
  #region AudioManagerAttributes
  public static AudioManager instance;

  [Header("Audio Manager Attributes")]
  [Space]
  [SerializeField]
  Sound[] sounds;
  [SerializeField]
  private AudioMixer audioMixer;
  #endregion

  #region UnityMethods
  void Awake()
  {
  
    instance = this;
    for (int i = 0; i < sounds.Length; i++)
    {
      GameObject newSound = new GameObject("Sound_" + i + "_" + sounds[i].name);
      newSound.transform.SetParent(this.transform);
      sounds[i].SetSource(newSound.AddComponent<AudioSource>());
    }


  }
  #endregion

  #region AudioMethods
  public void PlaySound(string name, bool loop)
  {
    for (int i = 0; i < sounds.Length; i++)
    {
      if (sounds[i].name == name)
      {
        sounds[i].Play(loop);
        return;
      }
    }

    Debug.LogWarning("PlaySound -> No sound found with name: " + name);
  }

  public void PauseSound(string name)
  {
    for (int i = 0; i < sounds.Length; i++)
    {
      if (sounds[i].name == name)
      {
        sounds[i].Pause();
        return;
      }
    }

    Debug.LogWarning("PauseSound -> No sound found with name: " + name);
  }

  public void StopSound(string name)
  {
    for (int i = 0; i < sounds.Length; i++)
    {
      if (sounds[i].name == name)
      {
        sounds[i].Stop();
        return;
      }
    }

    Debug.LogWarning("StopSound -> No sound found with name: " + name);
  }

  public bool IsPlaying(string name)
  {
    for (int i = 0; i < sounds.Length; i++)
    {
      if (sounds[i].name == name)
      {
        return sounds[i].IsPlaying();
      }
    }

    Debug.LogWarning("IsPlaying -> No sound found with name: " + name);
    return false;
  }
  #endregion

  #region VolumeMethods
  public void SetVolume(string group, float volume) {
    audioMixer.SetFloat(group, Mathf.Log10(volume) * 20);
  }
  #endregion
}
