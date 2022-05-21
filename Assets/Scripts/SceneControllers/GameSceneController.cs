using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSceneController : MonoBehaviour
{
  [Header("Public Singleton Attributes")]
  [Space]
  // Public attributes
  public static bool GameIsPaused = false;
  public static bool GameIsOver = false;
  public static bool StoreIsOpen = false;

  [Header("UI Game Objects")]
  [Space]
  public GameObject gameUI;

  public GameObject gameOverUI;
  public GameObject pauseUI;
  public GameObject storeUI;

  [Header("Game Scene Dependencies")]
  [Space]
  public PlayerController playerController;

  // Start is called before the first frame update
  void Awake()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Cancel"))
    {
      // Needed condition for pausing the game
      if (StoreIsOpen == false && GameIsOver == false)
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
      if (GameIsOver == false && GameIsPaused == false)
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

  public void OnGameOver()
  {
    GameIsOver = true;
    Time.timeScale = 0;

    gameUI.gameObject.SetActive(false);
    gameOverUI.gameObject.SetActive(true);
  }

  public void OnRestartGame()
  {
    LevelGenerator levelGenerator = gameObject.GetComponent<LevelGenerator>();
    levelGenerator.RestartGame();
    playerController.OnRestartGame();

    gameUI.gameObject.SetActive(true);
    gameOverUI.gameObject.SetActive(false);

    GameIsOver = false;
    Time.timeScale = 1;
  }

  public void OnPauseGame()
  {
    GameIsPaused = true;
    Time.timeScale = 0;

    gameUI.gameObject.SetActive(false);
    pauseUI.gameObject.SetActive(true);
  }

  public void OnResumeGame()
  {
    GameIsPaused = false;
    Time.timeScale = 1;

    pauseUI.gameObject.SetActive(false);
    gameUI.gameObject.SetActive(true);
  }

  public void OnOpenStore()
  {
    StoreIsOpen = true;
    Time.timeScale = 0;

    storeUI.gameObject.SetActive(true);
    gameUI.gameObject.SetActive(false);
  }

  public void OnCloseStore()
  {
    StoreIsOpen = false;
    Time.timeScale = 1;

    storeUI.gameObject.SetActive(false);
    gameUI.gameObject.SetActive(true);
  }
}
