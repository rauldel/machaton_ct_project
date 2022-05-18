using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BEE_STATE { FLYING, FOLLOWING, STINGING };

public class BeeController : MonoBehaviour
{
  #region BeeAttributes
  [Header("Bee Attribtes")]
  [Space]
  [SerializeField]
  private int healthPoints = 10;

  [SerializeField]
  private int lootCoins = 10;

  [SerializeField]
  private float beeSpeed = 1f;

  [SerializeField]
  private bool loopedPath = true;

  [SerializeField]
  private List<Transform> movementPoints;

  [SerializeField]
  private Animator beeAnimator;

  [SerializeField]
  public BEE_STATE beeState;

  private Transform player;

  private bool isFacingRight = true;
  private Transform currentTarget;
  private int lastIndex;
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
      lastIndex = 0;
    }

    beeState = BEE_STATE.FLYING;
  }

  void Update()
  {
    Vector2 newPosition = Vector2.zero;
    if (beeState == BEE_STATE.FLYING)
    {
      if (transform.position == currentTarget.position)
      {
        calculateNextTarget();
      }
      newPosition = Vector2.MoveTowards(transform.position, currentTarget.position, beeSpeed * Time.deltaTime);
    }
    else if (beeState == BEE_STATE.FOLLOWING)
    {
      newPosition = Vector2.MoveTowards(transform.position, player.position, beeSpeed * Time.deltaTime);
    }
    else if (beeState == BEE_STATE.STINGING)
    {
      newPosition = Vector2.MoveTowards(transform.position, player.position, beeSpeed * Time.deltaTime);
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
  public void OnSetFollowingState()
  {
    beeState = BEE_STATE.FOLLOWING;
  }

  public void OnSetFlyingState()
  {
    beeState = BEE_STATE.FLYING;
  }

  public void TakeDamage(int damageAmount)
  {
    if (healthPoints - damageAmount <= 0)
    {
      // Destroy object and invoke animation or something
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
      lastIndex = index;
      if (index == movementPoints.Count - 1)
      {
        index = 0;
      }
      else
      {
        index++;
      }
    }
    else
    {
      if (index == 0)
      {
        index++;
      }
      else if (index == movementPoints.Count - 1)
      {
        index--;
      }
      else if (index > lastIndex)
      {
        index++;
        lastIndex = index;
      }
      else if (index < lastIndex)
      {
        index--;
        lastIndex = index;
      }
    }
    currentTarget = movementPoints[index];
  }

  private void Flip()
  {
    isFacingRight = !isFacingRight;
    transform.Rotate(0f, 180f, 0f);
  }
  #endregion
}
