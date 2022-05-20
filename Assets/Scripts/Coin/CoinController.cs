using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
  #region Coin Attributes
  [Header("Coin Attributes Attributes")]
  [Space]
  [SerializeField]
  public int value = 1;

  #endregion

  #region UnityMethods
  // Start is called before the first frame update
  void Awake()
  {
    updateColor();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    PlayerController player = collision.transform.GetComponent<PlayerController>();

    // If a coin is hit by the player
    if (player != null)
    {
      // Play sound
      Destroy(gameObject);
    }
  }
  #endregion

  private void updateColor()
  {
    if (value == 1)
    {
      gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    else if (value > 1 && value < 10)
    {
      gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
    }
    else if (value >= 10 && value < 100)
    {
      gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
    else if (value >= 100)
    {
      gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    }
  }

  #region Public Methods
  public void setValue(int newValue)
  {
    value = newValue;
    updateColor();
  }
  #endregion
}
