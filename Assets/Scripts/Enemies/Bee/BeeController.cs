using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum BEE_STATE { FLYING, FOLLOWING, STINGING, SCARED };

public class BeeController : MonoBehaviour, Enemy
{
  #region BeeAttributes
  [Header("Bee Attribtes")]
  [Space]
  [SerializeField]
  private int healthPoints = 7;

  [SerializeField]
  private int lootCoins = 7;

  [SerializeField]
  private float beeSpeed = 1f;

  [SerializeField]
  private float beeSpeedScared = 3f;

  [SerializeField]
  private float maxScaredTime = 3f;

  [SerializeField]
  private float maxFollowingDistance = 3f;

  [SerializeField]
  private bool loopedPath = true;

  [SerializeField]
  private List<Transform> movementPoints;

  [SerializeField]
  private Animator beeAnimator;

  [SerializeField]
  public BEE_STATE beeState;

  [SerializeField]
  public float minAudioDistance = 1f;

  [SerializeField]
  public float maxAudioDistance = 25f;

  [SerializeField]
  [Range(0, 1)]
  public float beeMaxVolume = 0.75f;

  private Transform player;

  private bool isFacingRight = true;
  private Transform currentTarget;
  private bool positivePath;
  private float timeScared;
  private AudioSource beeAudioSource;
  #endregion

  #region UnityEvents
  void Awake()
  {
    if (player == null)
    {
      player = FindObjectOfType<PlayerController>().transform;
    }
    if (movementPoints.Count > 0)
    {
      currentTarget = movementPoints[0];
      positivePath = true;
    }

    beeState = BEE_STATE.FLYING;
    beeAudioSource = GetComponent<AudioSource>();
  }

  void Update()
  {
    Vector2 newPosition = Vector2.zero;
    float playerDistance = Vector2.Distance(transform.position, player.position);

    HandleBeeSound(playerDistance);

    switch (beeState)
    {
      case BEE_STATE.FLYING:
        if (playerDistance < maxFollowingDistance)
        {
          beeState = BEE_STATE.FOLLOWING;
          newPosition = Vector2.MoveTowards(transform.position, player.position, beeSpeed * Time.deltaTime);
        }
        else
        {
          if (transform.position == currentTarget.position)
          {
            calculateNextTarget();
          }
          newPosition = Vector2.MoveTowards(transform.position, currentTarget.position, beeSpeed * Time.deltaTime);
        }
        break;
      case BEE_STATE.FOLLOWING:
        if (playerDistance <= maxFollowingDistance)
        {
          newPosition = Vector2.MoveTowards(transform.position, player.position, beeSpeed * Time.deltaTime);
        }
        else
        {
          beeState = BEE_STATE.FLYING;
          newPosition = Vector2.MoveTowards(transform.position, currentTarget.position, beeSpeed * Time.deltaTime);
        }
        break;
      case BEE_STATE.STINGING:
        newPosition = Vector2.MoveTowards(transform.position, player.position, beeSpeed * Time.deltaTime);
        break;
      case BEE_STATE.SCARED:
        timeScared += Time.deltaTime;

        // If scared, runs away from the player
        if (timeScared < maxScaredTime)
        {
          newPosition = Vector2.MoveTowards(transform.position, player.position, -beeSpeed * Time.deltaTime);
        }
        else
        {
          newPosition = Vector2.MoveTowards(transform.position, currentTarget.position, beeSpeed * Time.deltaTime);
          timeScared = 0;
          SwapSpeeds();
          beeState = BEE_STATE.FLYING;
        }
        break;
    }

    if (newPosition.x - transform.position.x > 0 && !isFacingRight)
    {
      Flip();
    }
    else if (newPosition.x - transform.position.x < 0 && isFacingRight)
    {
      Flip();
    }

    transform.position = newPosition;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    PlayerController player = collision.transform.GetComponent<PlayerController>();

    // If bee is in smoke (Layer 10), it will try to move away the smoke quickly
    if (collision.transform.gameObject.layer == 10)
    {
      timeScared = 0f;
      SwapSpeeds();
      beeState = BEE_STATE.SCARED;
    }

    if (player != null && beeState != BEE_STATE.STINGING)
    {
      beeState = BEE_STATE.STINGING;
      beeAnimator.SetBool("sting", true);
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    PlayerController player = collision.transform.GetComponent<PlayerController>();

    if (player != null)
    {
      beeState = BEE_STATE.FLYING;
    }
  }

  #endregion

  #region CustomPublicEvents
  public void OnEndStinging()
  {
    beeAnimator.SetBool("sting", false);
  }

  public void TakeDamage(int damageAmount)
  {
    Debug.Log("Damage received");
    if (healthPoints - damageAmount <= 0)
    {
      player.GetComponent<PlayerController>().OnIncreaseCoin(lootCoins);
      // Destroy object and invoke animation or something
      AudioManager audioManager = AudioManager.instance;
      audioManager.PlaySound("BeeDeathSFX", false);
      Destroy(gameObject);
    }
    else
    {
      healthPoints -= damageAmount;
    }
  }
  #endregion

  #region Utils
  private void calculateNextTarget()
  {
    int index = movementPoints.FindIndex(0, movementPoints.Count, element => element == currentTarget);
    if (loopedPath == true)
    {
      calculateNextLoopedTarget(index);
    }
    else
    {
      calculateNextQueuedTarget(index);
    }
  }

  private void calculateNextLoopedTarget(int index)
  {
    if (index == movementPoints.Count - 1)
    {
      index = 0;
    }
    else
    {
      index++;
    }
    currentTarget = movementPoints[index];
  }

  private void calculateNextQueuedTarget(int index)
  {
    if (positivePath == true)
    {
      if (index == 0)
      {
        index++;
        positivePath = true;
        currentTarget = movementPoints[index];
        return;
      }
      else if (index == movementPoints.Count - 1)
      {
        index--;
        positivePath = false;
        currentTarget = movementPoints[index];
        return;
      }
      else
      {
        index++;
        currentTarget = movementPoints[index];
        return;
      }
    }
    else
    {
      if (index == 0)
      {
        index++;
        positivePath = true;
        currentTarget = movementPoints[index];
        return;
      }
      else if (index == movementPoints.Count - 1)
      {
        index--;
        positivePath = false;
        currentTarget = movementPoints[index];
        return;
      }
      else
      {
        index--;
        currentTarget = movementPoints[index];
        return;
      }
    }
  }
  private void Flip()
  {
    isFacingRight = !isFacingRight;
    transform.Rotate(0f, 180f, 0f);
  }

  private void SwapSpeeds()
  {
    float speedAux = beeSpeed;
    beeSpeed = beeSpeedScared;
    beeSpeedScared = speedAux;
  }

  private void HandleBeeSound(float playerDistance)
  {
    if (playerDistance < minAudioDistance)
    {
      beeAudioSource.volume = beeMaxVolume;
    }
    else if (playerDistance > maxAudioDistance)
    {
      beeAudioSource.volume = 0;
    }
    else
    {
      beeAudioSource.volume = beeMaxVolume - ((playerDistance - minAudioDistance) / (maxAudioDistance - minAudioDistance));
    }

    if (GameSceneController.GameIsOver || GameSceneController.GameIsPaused || GameSceneController.StoreIsOpen)
    {
      beeAudioSource.Pause();
    }
    else
    {
      beeAudioSource.UnPause();
    }
  }
  #endregion
}
