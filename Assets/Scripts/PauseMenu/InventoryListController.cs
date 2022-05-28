using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryListController : MonoBehaviour
{
  #region InventoryListControllerAttributes
  [SerializeField]
  private GameObject inventoryButtonTemplate;
  [SerializeField]
  private List<Sprite> imagesList;

  [SerializeField]
  private List<string> productNameList;

  private List<GameObject> inventoryButtonsList;
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
  #endregion

  #region InventoryListMethods
  public void PopulateDummyList()
  {
    if (inventoryButtonsList == null)
    {
      inventoryButtonsList = new List<GameObject>();
    }

    if (inventoryButtonsList.Count > 0)
    {
      foreach (GameObject i in inventoryButtonsList)
      {
        Destroy(i.gameObject);
      }
      inventoryButtonsList.Clear();
    }

    for (int i = 0; i < 7; i++)
    {
      GameObject inventoryButton = Instantiate(inventoryButtonTemplate) as GameObject;
      inventoryButton.SetActive(true);

      inventoryButton.GetComponent<InventoryButtonController>().DummyPopulation();
      inventoryButton.transform.SetParent(inventoryButtonTemplate.transform.parent, false);
      inventoryButtonsList.Add(inventoryButton);
    }
  }
  public void PopulateList(List<KeyValuePair<string, int>> inventoryList)
  {
    if (inventoryButtonsList == null)
    {
      inventoryButtonsList = new List<GameObject>();
    }

    if (inventoryButtonsList.Count > 0)
    {
      foreach (GameObject i in inventoryButtonsList)
      {
        Destroy(i.gameObject);
      }
      inventoryButtonsList.Clear();
    }

    foreach (KeyValuePair<string, int> pair in inventoryList)
    {
      GameObject inventoryButton = Instantiate(inventoryButtonTemplate) as GameObject;
      InventoryButtonController ibc = inventoryButton.GetComponent<InventoryButtonController>();

      ibc.SetItemName(pair.Key);
      ibc.SetQtyText(pair.Value);
      ibc.SetImage(GetItemSprite(pair.Key));

      inventoryButton.SetActive(true);
      inventoryButton.transform.SetParent(inventoryButtonTemplate.transform.parent, false);
      inventoryButtonsList.Add(inventoryButton);
    }
  }

  private Sprite GetItemSprite(string productName)
  {
    int index = 0;

    for (int i = 0; i < productNameList.Count; i++)
    {
      if (productNameList[i] == productName)
      {
        index = i;
      }
    }

    return imagesList[index];
  }
  #endregion
}
