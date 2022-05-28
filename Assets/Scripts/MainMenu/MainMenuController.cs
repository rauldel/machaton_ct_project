using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
  #region MainMenuAttributes
  [Header("Main Menu Dependencies")]
  [Space]
  [SerializeField]
  private MainMenuBackgroundController mainMenuBackgroundController;
  [SerializeField]
  private AudioManager audioManager;

  [Header("Thunder Spawn Parameters")]
  [Space]
  [SerializeField]
  private float minThunderFrequency = 4f;

  [SerializeField]
  private float maxThunderFrequency = 8f;

  [Header("UI Dependencies")]
  [Space]
  [SerializeField]
  private GameObject mainMenuUI;
  [SerializeField]
  private GameObject optionsMenuUI;

  [SerializeField]
  private Slider mainSlider;
  [SerializeField]
  private Slider musicSlider;
  [SerializeField]
  private Slider sfxSlider;

  private SaveData saveData;
  #endregion

  #region UnityMethods
  // Start is called before the first frame update
  void Awake()
  {
    Time.timeScale = 1f;
    audioManager.PlaySound("MainMenuTheme", true);
    audioManager.PlaySound("Rain", true);

    saveData = SaveGameController.GetSavedData();
    mainSlider.SetValueWithoutNotify(saveData.mainVolume);
    musicSlider.SetValueWithoutNotify(saveData.musicVolume);
    sfxSlider.SetValueWithoutNotify(saveData.sfxVolume);

    float nextThunderTime = Random.Range(minThunderFrequency, maxThunderFrequency);
    Invoke("SpawnThunder", nextThunderTime);
  }

  // Update is called once per frame
  void Update()
  {

  }
  #endregion

  #region PublicMethods
  public void OnStartGame()
  {
    audioManager.PlaySound("Click", false);
    SceneManager.LoadScene("EndlessLevel");
  }

  public void OnOpenOptionsMenu()
  {
    audioManager.PlaySound("Click", false);
    mainMenuUI.gameObject.SetActive(false);
    optionsMenuUI.gameObject.SetActive(true);
  }

  public void OnCloseOptionsMenu()
  {
    audioManager.PlaySound("Click", false);
    mainMenuUI.gameObject.SetActive(true);
    optionsMenuUI.gameObject.SetActive(false);
  }

  public void OnChangeMainVolume(float volume)
  {
    saveData.mainVolume = volume;
    SaveGameController.WriteDataToStorage(saveData);
    audioManager.SetVolume("MainVolume", volume);
  }
  public void OnChangeMusicVolume(float volume)
  {
    saveData.musicVolume = volume;
    SaveGameController.WriteDataToStorage(saveData);
    audioManager.SetVolume("MusicVolume", volume);
  }

  public void OnChangeSFXVolume(float volume)
  {
    saveData.sfxVolume = volume;
    SaveGameController.WriteDataToStorage(saveData);
    audioManager.SetVolume("SFXVolume", volume);
  }
  #endregion

  #region Utils
  private void SpawnThunder()
  {
    StartCoroutine(mainMenuBackgroundController.EmitThunder(audioManager));

    float nextThunderTime = Random.Range(minThunderFrequency, maxThunderFrequency);
    Invoke("SpawnThunder", nextThunderTime);
  }
  #endregion
}
