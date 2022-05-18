using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeeFlyingZoneController : MonoBehaviour
{
  #region BeeFlyingZoneAttributes
  [Header("Bee Flying Zone Attribtes")]
  [Space]
  [SerializeField]
  private UnityEvent OnSetFollowingState;

  [SerializeField]
  private UnityEvent OnSetFlyingState;
  #endregion

  void Awake()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    PlayerController player = collision.transform.GetComponent<PlayerController>();

    if (player != null)
    {
      BeeController bee = gameObject.GetComponentInChildren<BeeController>();
      if (bee.beeState != BEE_STATE.FOLLOWING)
      {
        OnSetFollowingState.Invoke();
      }
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    PlayerController player = collision.transform.GetComponent<PlayerController>();

    if (player != null)
    {
      OnSetFlyingState.Invoke();
    }
  }
}
