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
  public IEnumerator StartCountdown()
  {
    this.gameObject.SetActive(true);
    yield return new WaitForSeconds(1f);

    countdownText.text = "2";
    background.GetComponent<Image>().color = new Color(241f / 255f, 109f / 255f, 14f / 255f);
    yield return new WaitForSeconds(1f);

    countdownText.text = "1";
    background.GetComponent<Image>().color = new Color(0f, 179f / 255f, 158f / 255f);
    yield return new WaitForSeconds(1f);

    countdownText.text = "Run!";
    background.GetComponent<Image>().color = background.GetComponent<Image>().color = new Color(241f / 255f, 109f / 255f, 14f / 255f);
    yield return new WaitForSeconds(0.5f);

    GameSceneController.CountdownIsOn = isCountingDown;
    this.gameObject.SetActive(false);

    countdownText.text = "3";

    background.GetComponent<Image>().color = new Color(0f, 179f / 255f, 158f / 255f);
  }
  #endregion
}
