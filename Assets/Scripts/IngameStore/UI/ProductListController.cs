using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using myCT.ProductProjections;

[System.Serializable]
public class ProductListController : MonoBehaviour
{
  #region ProductListControllerAttributes
  [SerializeField]
  private GameObject productButtonTemplate;

  private List<GameObject> productButtonsList;
  #endregion

  #region UnityMethods
  // Start is called before the first frame update
  void Start()
  {
    productButtonsList = new List<GameObject>();
  }
  #endregion

  #region ProductListControllerMethods
  public void PopulateDummyList()
  {
    if (productButtonsList == null)
    {
      productButtonsList = new List<GameObject>();
    }

    if (productButtonsList.Count > 0)
    {
      foreach (GameObject p in productButtonsList)
      {
        Destroy(p.gameObject);
      }
      productButtonsList.Clear();
    }

    for (int i = 0; i < 7; i++)
    {
      GameObject productButton = Instantiate(productButtonTemplate) as GameObject;
      productButton.SetActive(true);

      productButton.GetComponent<ProductButtonController>().DummyPopulation();
      productButton.transform.SetParent(productButtonTemplate.transform.parent, false);
      productButtonsList.Add(productButton);
    }
  }

  public void PopulateList(List<ProductProjection> productsList)
  {
    if (productButtonsList == null)
    {
      productButtonsList = new List<GameObject>();
    }

    if (productButtonsList.Count > 0)
    {
      foreach (GameObject p in productButtonsList)
      {
        Destroy(p.gameObject);
      }
      productButtonsList.Clear();
    }

    foreach (ProductProjection p in productsList)
    {
      GameObject productButton = Instantiate(productButtonTemplate) as GameObject;
      productButton.SetActive(true);

      productButton.GetComponent<ProductButtonController>().setProduct(p);
      productButton.transform.SetParent(productButtonTemplate.transform.parent, false);
      productButtonsList.Add(productButton);
    }
  }

  public void DisableButtons() {
    foreach(GameObject g in productButtonsList) {
      ProductButtonController pbc = g.GetComponent<ProductButtonController>();
      pbc.DisableButton();
    }
  }

  public void EnableButtons() {
    foreach(GameObject g in productButtonsList) {
      ProductButtonController pbc = g.GetComponent<ProductButtonController>();
      pbc.EnableButton();
    }
  }
  #endregion
}
