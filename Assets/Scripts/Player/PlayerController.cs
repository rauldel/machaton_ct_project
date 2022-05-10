using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

  public Animator playerAnimator;
  public PlayerPhysicsController playerPhysicsController;
  public PlayerWeaponController playerWeaponController;
  public Text uiWeaponText;
  public Text uiLifeText;
  public Text uiCoinText;

  private float horizontalMove = 0f;
  private bool jump = false;
  private bool crouch = false;
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
    if (!GameSceneController.GameIsPaused)
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
  }
  #endregion

  #region PlayerPublicActions
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

  public void OnIncreaseCoin()
  {
    playerCoins++;
    uiCoinText.text = "Coin: " + playerCoins;
  }

  public void OnDecreaseCoin()
  {
    playerCoins--;
  }
  #endregion

  #region PlayerMethods
  public void EndDamageStatus()
  {
    playerAnimator.SetBool("isDamaged", false);
  }
  #endregion
}
