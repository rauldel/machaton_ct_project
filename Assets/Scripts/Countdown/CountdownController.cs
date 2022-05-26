using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
  #region CountdownAttributes
  [Header("Player Controller Events")]
  [Space]
  [SerializeField]
  private GameObject background;

  [SerializeField]
  private Text countdownText;
  public bool isCountingDown = false;
  #endregion

  #region UnityMethods
  void Awake()
  { }
  #endregion

  #region CountdownMethods
  public void StartCountdown()
  {
    this.gameObject.SetActive(true);
    Invoke("OnOneSecond", 1f);
  }

  private void OnOneSecond()
  {
    countdownText.text = "2";
    background.GetComponent<Image>().color = new Color(241f/255f, 109f/255f, 14f/255f);
    Invoke("OnTwoSeconds", 1f);
  }

  private void OnTwoSeconds()
  {
    countdownText.text = "1";
    background.GetComponent<Image>().color = new Color(0f, 179f/255f, 158f/255f);
    Invoke("OnThreeSeconds", 1f);
  }

  private void OnThreeSeconds()
  {
    countdownText.text = "Run!";
    background.GetComponent<Image>().color = background.GetComponent<Image>().color = new Color(241f/255f, 109f/255f, 14f/255f);
    Invoke("OnCleanCountdown", 0.5f);
  }

  private void OnCleanCountdown()
  {
    GameSceneController.CountdownIsOn = isCountingDown;
    this.gameObject.SetActive(false);

    countdownText.text = "3";

    background.GetComponent<Image>().color = new Color(0f, 179f/255f, 158f/255f);
  }
  #endregion
}
