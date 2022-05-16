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

  // Start is called before the first frame update
  void Awake()
  {

  }

  // Update is called once per frame
  void Update()
  {

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

    GameIsOver = false;
    Time.timeScale = 1;

    gameUI.gameObject.SetActive(true);
    gameOverUI.gameObject.SetActive(false);
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
    StoreIsOpen = true;
    Time.timeScale = 0;

    storeUI.gameObject.SetActive(false);
    gameUI.gameObject.SetActive(true);
  }
}
