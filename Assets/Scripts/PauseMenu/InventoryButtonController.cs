using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButtonController : MonoBehaviour
{
  #region InventoryButtonControllerAttributes
  [SerializeField]
  private PauseMenuController pauseMenuController;

  [SerializeField]
  private Text itemNameText;

  [SerializeField]
  private Text itemQtyText;

  [SerializeField]
  private Image itemImage;
  #endregion

  #region UnityMethods
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void OnClick()
  {
    pauseMenuController.OnConsumeItem(itemNameText.text);
  }
  #endregion

  #region Utils
  public void SetItemName(string name)
  {
    itemNameText.text = name;
    if (name.Contains("charge"))
    {
      Button btn = GetComponent<Button>();
      btn.interactable = false;
    }
  }

  public void SetQtyText(int qty)
  {
    itemQtyText.text = "" + qty;
  }

  public void SetImage(Sprite sprite)
  {
    itemImage.sprite = sprite;
  }

  public void DummyPopulation()
  {
    SetItemName("Dummy name");
    SetQtyText(25);
  }
  #endregion
}
