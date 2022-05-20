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
  private int playerLife = 5;

  [SerializeField]
  private int playerCoins = 10;

  [SerializeField]
  private bool autoMovement = false;

  [SerializeField]
  private float runSpeed = 40f;

  [SerializeField]
  private float GAME_OVER_VELOCITY_THRESOLD = -20;

  public Transform playerInitialPosition;

  public Animator playerAnimator;
  public Rigidbody2D playerRigidbody;
  public PlayerPhysicsController playerPhysicsController;
  public PlayerWeaponController playerWeaponController;

  [Header("Player UI Attributes")]
  [Space]
  public Text uiWeaponText;
  public Text uiLifeText;
  public Text uiCoinText;

  private float horizontalMove = 0f;
  private bool jump = false;
  private bool crouch = false;
  
  [Header("Player Controller Events")]
  [Space]
  public UnityEvent OnGameOver;
  #endregion

  #region UnityEvents
  // Start is called before the first frame update
  void Start()
  {
    playerCoins = 10;
    uiLifeText.text = "Life(s) - " + playerLife;
    uiCoinText.text = "Coin: " + playerCoins;
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
      OnGameOver.Invoke();
    }
  }
  #endregion

  #region PlayerPublicActions
  public void OnRestartGame()
  {
    this.gameObject.transform.position = playerInitialPosition.transform.position;
    playerRigidbody.velocity = Vector2.zero;
  }
  public void OnLanding()
  {
    playerAnimator.SetBool("isJumping", false);
  }

  public void OnCrouching(bool isCrouching)
  {
    playerAnimator.SetBool("isCrouching", isCrouching);
  }

  public void DecrementLife()
  {
    playerLife--;
    uiLifeText.text = "Life(s) - " + playerLife.ToString();
    playerAnimator.SetBool("isDamaged", true);
  }

  public void IncrementLife()
  {
    playerLife++;
    uiLifeText.text = "Life(s) - " + playerLife.ToString();
  }

  public void OnIncreaseCoin(int newCoins)
  {
    playerCoins += newCoins;
    uiCoinText.text = "Coin: " + playerCoins;
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
