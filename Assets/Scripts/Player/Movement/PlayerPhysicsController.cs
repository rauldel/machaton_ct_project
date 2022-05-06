using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPhysicsController : MonoBehaviour
{
  #region PlayerAttributes
  [Header("Player Attribtes")]
  [Space]

  // Maximum amount of time for being in damage state
  [SerializeField] private float maxTimeDamage = 1f;
  // Amount of force added when the player jumps
  [SerializeField] private float m_JumpForce = 400f;
  // Amount of maxSpeed applied to crouching movement. 1 = 100%
  [Range(0, 1)][SerializeField] private float m_CrouchSpeed = .36f;
  // How much to smooth out the movement  
  [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;
  // Whether or not a player can steer while jumping
  [SerializeField] private bool m_AirControl = false;
  // A mask determining what is ground to the character
  [SerializeField] private LayerMask m_WhatIsGround;
  // A position marking where to check if the player is grounded.
  [SerializeField] private Transform m_GroundCheck;
  // A position marking where to check for ceilings
  [SerializeField] private Transform m_CeilingCheck;
  // A collider that will be disabled when crouching
  [SerializeField] private Collider2D m_CrouchDisableCollider;

  // Reference to the RigidBody attached to the player
  private Rigidbody2D m_Rigidbody2D;
  // Radius of the overlap circle to determine if the player can stand up
  private const float k_CeilingRadius = .15f;
  // Radius of the overlap circle to determine if grounded
  private const float k_GroundedRadius = .15f;
  // Whether or not the player is grounded.
  private bool m_Grounded;
  // Flag for checking if player is being damaged
  private bool m_BeingDamaged = false;
  private float timeBeingDamaged = 0;
  // Flag for checking if Player was crouching in previous frame
  private bool m_wasCrouching = false;
  // For determining which way the player is currently facing.
  private bool m_FacingRight = true;
  // For determining if Player is invincible
  private bool isInvincible = false;
  // Vector for calculating velocity of the player
  private Vector3 m_Velocity = Vector3.zero;

  [Header("Player Physics Events")]
  [Space]

  public UnityEvent OnEndDamageStatus;
  public UnityEvent OnDecreaseLife;
  public UnityEvent OnIncreaseLife;
  public UnityEvent OnIncreaseCoin;
  public UnityEvent OnLandEvent;
  [System.Serializable]
  public class BoolEvent : UnityEvent<bool> { }
  public BoolEvent OnCrouchEvent;
  #endregion

  #region UnityEvents
  private void Awake()
  {
    m_Rigidbody2D = GetComponent<Rigidbody2D>();

    if (OnDecreaseLife == null)
      OnDecreaseLife = new UnityEvent();

    if (OnIncreaseLife == null)
      OnIncreaseLife = new UnityEvent();

    if (OnLandEvent == null)
      OnLandEvent = new UnityEvent();

    if (OnCrouchEvent == null)
      OnCrouchEvent = new BoolEvent();
  }

  // FixedUpdate is called once per tick in Physics system
  private void FixedUpdate()
  {
    bool wasGrounded = m_Grounded;
    m_Grounded = false;

    // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
    // This can be done using layers instead but Sample Assets will not overwrite your project settings.
    Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
    for (int i = 0; i < colliders.Length; i++)
    {
      if (colliders[i].gameObject != gameObject)
      {
        m_Grounded = true;
        if (!wasGrounded)
          OnLandEvent.Invoke();
      }
    }

    if (m_BeingDamaged)
    {
      float auxDamagedTime = timeBeingDamaged + Time.fixedDeltaTime;
      if (auxDamagedTime >= maxTimeDamage) {
        m_BeingDamaged = false;
        timeBeingDamaged = 0;
        OnEndDamageStatus.Invoke();
      } else {
        timeBeingDamaged = auxDamagedTime;
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    BeeController bee = collision.transform.GetComponent<BeeController>();
    HeadlessController headless = collision.transform.GetComponent<HeadlessController>();
    CoinController coin = collision.transform.GetComponent<CoinController>();

    // 12 es el layer de la cámara
    if (collision.transform.gameObject.layer == 12) {
      return;
    }

    // This means we hit an enemy with our body
    if ((bee != null || headless != null) && !m_BeingDamaged)
    {
      m_BeingDamaged = true;
      isInvincible = true;
      Vector2 impulso;

      if (m_Grounded)
      {
        impulso = new Vector2(this.gameObject.transform.position.x - collision.transform.position.x, 0);
      }
      else
      {
        impulso = this.gameObject.transform.position - collision.transform.position;
        m_Rigidbody2D.velocity = new Vector2(0, 0);
      }

      m_Rigidbody2D.AddForce(new Vector2(impulso.normalized.x * 10, impulso.normalized.y * 5), ForceMode2D.Impulse);

      // Invoke life decrement in PlayerController
      OnDecreaseLife.Invoke();
    }

    // This means we hit a coin with our body
    if (coin != null)
    {
      OnIncreaseCoin.Invoke();
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {}
  #endregion

  #region PlayerPhysicsMethods
  public void Move(float move, bool crouch, bool jump)
  {
    // If crouching, check to see if the character can stand up
    if (!crouch)
    {
      // If the character has a ceiling preventing them from standing up, keep them crouching
      if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
      {
        crouch = true;
      }
    }

    // Only control the player if grounded or airControl is turned on AND player is not getting damage
    if ((m_Grounded || m_AirControl) && (!m_BeingDamaged))
    {

      // If crouching
      if (crouch)
      {
        if (!m_wasCrouching)
        {
          m_wasCrouching = true;
          OnCrouchEvent.Invoke(true);
        }

        // Reduce the speed by the crouchSpeed multiplier
        move *= m_CrouchSpeed;

        // Disable one of the colliders when crouching
        if (m_CrouchDisableCollider != null)
          m_CrouchDisableCollider.enabled = false;
      }
      else
      {
        // Enable the collider when not crouching
        if (m_CrouchDisableCollider != null)
          m_CrouchDisableCollider.enabled = true;

        if (m_wasCrouching)
        {
          m_wasCrouching = false;
          OnCrouchEvent.Invoke(false);
        }
      }

      // Move the character by finding the target velocity
      Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
      // And then smoothing it out and applying it to the character
      m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

      // If the input is moving the player right and the player is facing left...
      if (move > 0 && !m_FacingRight)
      {
        // ... flip the player.
        Flip();
      }
      // Otherwise if the input is moving the player left and the player is facing right...
      else if (move < 0 && m_FacingRight)
      {
        // ... flip the player.
        Flip();
      }
    }
    // If the player should jump...
    if (m_Grounded && jump && !m_BeingDamaged)
    {
      // Add a vertical force to the player.
      m_Grounded = false;
      m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
    }
  }

  private void Flip()
  {
    // Switch the way the player is labelled as facing.
    m_FacingRight = !m_FacingRight;

    // Actually Rotate Player's gameobject
    transform.Rotate(0f, 180f, 0f);
  }
  #endregion
}
