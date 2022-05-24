using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
  #region PlayerAttributes
  [Header("Player Attribtes")]
  [Space]
  [SerializeField]
  private int INITIAL_PLAYER_LIFES = 10;

  [SerializeField]
  private int playerLife = 10;

  [SerializeField]
  private int playerCoins;
  public int PlayerCoins { private set { playerCoins = value; } get { return playerCoins; } }

  [SerializeField]
  private bool autoMovement = false;

  [SerializeField]
  private float runSpeed = 40f;

  [SerializeField]
  private float GAME_OVER_VELOCITY_THRESOLD = -20;

  public Transform playerInitialPosition;

  public Animator playerAnimator;
  public Rigidbody2D playerRigidbody;
  [SerializeField] private PlayerPhysicsController playerPhysicsController;
  [SerializeField] private PlayerWeaponController playerWeaponController;
  [SerializeField] private SaveGameController saveGameController;
  [SerializeField] private GameUIController gameUIController;

  private float horizontalMove = 0f;
  private bool jump = false;
  private bool crouch = false;

  [Header("Player Controller Events")]
  [Space]
  public UnityEvent OnGameOver;
  #endregion

  #region UnityEvents
  void Awake()
  {
    playerLife = INITIAL_PLAYER_LIFES;
    SaveData savedData = SaveGameController.GetSavedData();
    playerCoins = savedData.playerCoins;
    gameUIController.SetLifeText(playerLife);
    gameUIController.SetCoinText(playerCoins);
  }

  // Update is called once per frame
  void Update()
  {
    if (!GameSceneController.GameIsPaused && !GameSceneController.GameIsOver && !GameSceneController.StoreIsOpen)
    {
      if (autoMovement == true)
      {
        horizontalMove = runSpeed;
      }
      else
      {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
      }

      playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));

      if (Input.GetButtonDown("Jump"))
      {
        jump = true;
        playerAnimator.SetBool("isJumping", true);
      }

      if (Input.GetButtonDown("Fire1"))
      {
        playerAnimator.SetBool("isShooting", true);
      }
      else if (Input.GetButtonUp("Fire1"))
      {
        playerAnimator.SetBool("isShooting", false);
      }

      if (Input.GetButtonDown("Crouch"))
      {
        crouch = true;
      }
      else if (Input.GetButtonUp("Crouch"))
      {
        crouch = false;
      }
    }
  }

  // FixedUpdate is called every tick of Physics rendering
  void FixedUpdate()
  {
    // Move the player
    playerPhysicsController.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    jump = false;

    if (playerRigidbody.velocity.y <= GAME_OVER_VELOCITY_THRESOLD)
    {
      playerWeaponController.DeactivateAllWeapons();
      OnGameOver.Invoke();
    }
  }
  #endregion

  #region PlayerPublicActions
  public void OnRestartGame()
  {
    playerLife = INITIAL_PLAYER_LIFES;
    gameUIController.SetLifeText(playerLife);
    this.gameObject.transform.position = playerInitialPosition.transform.position;
    playerRigidbody.velocity = Vector2.zero;
    playerWeaponController.setWeapon(playerWeaponController.GetWeaponSelected());
  }
  public void OnLanding()
  {
    playerAnimator.SetBool("isJumping", false);
  }

  public void OnCrouching(bool isCrouching)
  {
    playerAnimator.SetBool("isCrouching", isCrouching);
  }

  public void OnDecrementLife()
  {
    Debug.Log("PLAYER HIT");
    if (playerLife - 1 == 0)
    {
      OnGameOver.Invoke();
    }
    else
    {
      playerLife--;
      gameUIController.SetLifeText(playerLife);
      playerAnimator.SetBool("isDamaged", true);
    }
  }

  public void OnIncrementLife(int newLifePoints)
  {
    playerLife += newLifePoints;
    gameUIController.SetLifeText(playerLife);
  }

  public void OnIncreaseCoin(int newCoins)
  {
    SaveData saveData = SaveGameController.GetSavedData();
    playerCoins = saveData.playerCoins + newCoins;
    saveGameController.UpdateCoin(playerCoins);
    saveGameController.UpdateCoinEarned(newCoins);
    gameUIController.SetCoinText(playerCoins);
  }

  public void OnDecreaseCoin(int newCoins)
  {
    playerCoins -= newCoins;
  }
  #endregion

  #region PlayerMethods
  public void EndDamageStatus()
  {
    playerAnimator.SetBool("isDamaged", false);
  }
  #endregion
}
