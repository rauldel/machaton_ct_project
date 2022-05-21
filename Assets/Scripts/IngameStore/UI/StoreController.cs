using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using myCT.Common;
using myCT.Products;
using myCT.ProductTypes;

public class StoreController : MonoBehaviour
{
  #region StoreAttrbiutes
  [SerializeField]
  private SaveGameController saveGameController;

  [SerializeField]
  private ProductListController consumableListController;

  [SerializeField]
  private ProductListController weaponsListController;

  [SerializeField]
  private Text playerCoinsText;

  private List<Product> consumableProductsList;
  private List<Product> weaponProductsList;
  private List<Product> ammoProductsList;
  #endregion

  #region UnityMethods
  // Start is called before the first frame update
  void Start()
  {
    LoadPlayerCoins();
    LoadConsumableProducts();
    LoadWeaponProducts();
  }

  // Update is called once per frame
  void Update()
  {

  }
  #endregion

  #region StoreMethods
  private void LoadPlayerCoins()
  {
    SaveData data = SaveGameController.GetSavedData();
    playerCoinsText.text = data.playerCoins.ToString();
  }
  private async void LoadConsumableProducts()
  {
    Client client = CommercetoolsManager.GetClient();
    consumableProductsList = new List<Product>();
    ProductManager productManager = new ProductManager(client);
    ProductTypeManager productTypeManager = new ProductTypeManager(client);
    string productTypeName = "Consumable";

    string ptWhereName = "name=\"" + productTypeName + "\"";
    Response<ProductTypeQueryResult> productTypeResponse = await productTypeManager.QueryProductTypesAsync(ptWhereName);
    Response<ProductQueryResult> productsResponse;

    if (productTypeResponse.Success && productTypeResponse.Result.Results.Count > 0)
    {
      ProductType myProductType = productTypeResponse.Result.Results[0];

      string productsWhere = "productType(id=\"" + myProductType.Id + "\")";
      productsResponse = await productManager.QueryProductsAsync(productsWhere);

      if (productsResponse.Success)
      {
        consumableProductsList = productsResponse.Result.Results;
        consumableListController.PopulateList(consumableProductsList);
      }
    }
  }

  private async void LoadWeaponProducts()
  {
    Client client = CommercetoolsManager.GetClient();
    consumableProductsList = new List<Product>();
    ProductManager productManager = new ProductManager(client);
    ProductTypeManager productTypeManager = new ProductTypeManager(client);
    string productTypeName = "Weapon";

    string ptWhereName = "name=\"" + productTypeName + "\"";
    Response<ProductTypeQueryResult> productTypeResponse = await productTypeManager.QueryProductTypesAsync(ptWhereName);
    Response<ProductQueryResult> productsResponse;

    if (productTypeResponse.Success && productTypeResponse.Result.Results.Count > 0)
    {
      ProductType myProductType = productTypeResponse.Result.Results[0];

      string productsWhere = "productType(id=\"" + myProductType.Id + "\")";
      productsResponse = await productManager.QueryProductsAsync(productsWhere);

      if (productsResponse.Success)
      {
        weaponProductsList = productsResponse.Result.Results;
        weaponsListController.PopulateList(weaponProductsList);
      }
    }
  }
  #endregion
}
