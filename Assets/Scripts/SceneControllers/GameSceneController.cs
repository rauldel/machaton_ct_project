using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
  [Header("Public Singleton Attributes")]
  [Space]
  // Public attributes
  public static bool GameIsPaused = false;
  public static bool GameIsOver = false;
  public static bool StoreIsOpen = false;
  public static bool CountdownIsOn = false;

  [Header("UI Game Objects")]
  [Space]
  public GameObject gameUI;

  public GameObject gameOverUI;
  public GameObject pauseUI;
  public GameObject storeUI;
  public GameObject countdownUI;

  [Header("Game Scene Dependencies")]
  [Space]
  [SerializeField]
  private PlayerController playerController;
  [SerializeField]
  private ParallaxBackground parallaxBackground;

  void Start()
  {
    Time.timeScale = 1f;
    SaveData saveData = SaveGameController.GetSavedData();
    AudioManager.instance.SetVolume("MainVolume", saveData.mainVolume);
    AudioManager.instance.SetVolume("MusicVolume", saveData.musicVolume);
    AudioManager.instance.SetVolume("SFXVolume", saveData.sfxVolume);
    CountdownIsOn = true;
    StartCoroutine(countdownUI.GetComponent<CountdownController>().StartCountdown());
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Cancel"))
    {
      // Needed condition for pausing the game
      if (StoreIsOpen == false && GameIsOver == false && CountdownIsOn == false)
      {
        if (GameIsPaused == false)
        {
          OnPauseGame();
        }
        else
        {
          OnResumeGame();
        }
      }

    }

    if (Input.GetButtonDown("Store"))
    {
      // Needed condition for opening the store
      if (GameIsOver == false && GameIsPaused == false && CountdownIsOn == false)
      {
        if (StoreIsOpen == false)
        {
          OnOpenStore();
        }
        else
        {
          OnCloseStore();
        }
      }
    }
  }

  #region SceneStateMethods
  public void OnExitGame()
  {
    AudioManager.instance.PlaySound("ClickSFX", false);
    SceneManager.LoadScene("MainMenu");
  }
  public void OnGameOver()
  {
    GameIsOver = true;
    Time.timeScale = 0;
    parallaxBackground.OnGameOver();
    playerController.OnReallocatePlayer();

    AudioManager audioManager = AudioManager.instance;
    audioManager.StopSound("BackgroundMusic");
    audioManager.StopSound("WalkingSFX");
    audioManager.PlaySound("GameOverMusic", false);

    gameUI.gameObject.SetActive(false);
    gameOverUI.gameObject.SetActive(true);
  }

  public void OnRestartGame()
  {
    AudioManager.instance.PlaySound("ClickSFX", false);
    CountdownIsOn = true;
    countdownUI.GetComponent<CountdownController>().StartCountdown();
    playerController.OnRestartGame();
    LevelGenerator levelGenerator = gameObject.GetComponent<LevelGenerator>();
    levelGenerator.RestartGame();

    AudioManager audioManager = AudioManager.instance;
    audioManager.PlaySound("BackgroundMusic", true);

    parallaxBackground.OnRestartGame();

    gameUI.gameObject.SetActive(true);
    gameOverUI.gameObject.SetActive(false);

    GameIsOver = false;
    Time.timeScale = 1;
  }

  public void OnPauseGame()
  {
    GameIsPaused = true;
    Time.timeScale = 0;

    AudioManager audioManager = AudioManager.instance;
    audioManager.PlaySound("OpenMenuSFX", false);

    gameUI.gameObject.SetActive(false);
    pauseUI.gameObject.SetActive(true);
  }

  public void OnResumeGame()
  {
    GameIsPaused = false;
    Time.timeScale = 1;

    AudioManager audioManager = AudioManager.instance;
    audioManager.PlaySound("CloseMenuSFX", false);

    pauseUI.gameObject.SetActive(false);
    gameUI.gameObject.SetActive(true);
  }

  public void OnOpenStore()
  {
    StoreIsOpen = true;
    Time.timeScale = 0;

    AudioManager audioManager = AudioManager.instance;
    audioManager.PlaySound("OpenMenuSFX", false);

    storeUI.gameObject.SetActive(true);
    gameUI.gameObject.SetActive(false);
  }

  public void OnCloseStore()
  {
    StoreController sc = storeUI.GetComponent<StoreController>();
    if (sc.isOrdering == false)
    {
      PlayerWeaponController pwc = playerController.gameObject.GetComponent<PlayerWeaponController>();
      GameUIController gameUIController = gameUI.GetComponent<GameUIController>();
      SaveData saveData = SaveGameController.GetSavedData();
      gameUIController.SetCoinText(saveData.playerCoins);

      switch (pwc.GetWeaponSelected())
      {
        case Weapons.Phaser:
          gameUIController.SetAmmoText(saveData.phaserAmmo.GetQuantity());
          break;
        case Weapons.Laser:
          gameUIController.SetAmmoText(saveData.laserAmmo.GetQuantity());
          break;

        case Weapons.SmokeBomb:
          gameUIController.SetAmmoText(saveData.smokeBombAmmo.GetQuantity());
          break;
      }
      gameUIController.UpdateWeaponsUI(pwc.GetWeaponSelected());

      StoreIsOpen = false;
      Time.timeScale = 1;

      AudioManager audioManager = AudioManager.instance;
      audioManager.PlaySound("CloseMenuSFX", false);

      storeUI.gameObject.SetActive(false);
      gameUI.gameObject.SetActive(true);
    }
  }
  #endregion

}
