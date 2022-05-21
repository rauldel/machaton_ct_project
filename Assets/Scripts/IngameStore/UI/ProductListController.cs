using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using myCT.Products;

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

  public void PopulateList(List<Product> productsList)
  {
    Debug.Log("PL: " + productsList.Count);
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

    foreach (Product p in productsList)
    {
      GameObject productButton = Instantiate(productButtonTemplate) as GameObject;
      productButton.SetActive(true);

      productButton.GetComponent<ProductButtonController>().setProduct(p);
      productButton.transform.SetParent(productButtonTemplate.transform.parent, false);
      productButtonsList.Add(productButton);
    }
  }

  #endregion
}
