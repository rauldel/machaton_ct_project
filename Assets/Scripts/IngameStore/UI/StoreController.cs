using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* using myCT.Carts;
using myCT.Common;
using myCT.Orders;
using myCT.ProductProjections;
using myCT.ProductTypes; */
using ctLite.Carts;
using ctLite.Common;
using ctLite.Orders;
using ctLite.ProductProjections;
using ctLite.ProductTypes;

public class StoreController : MonoBehaviour
{
  #region StoreAttrbiutes
  [Header("Store Attributes")]
  [Space]
  [SerializeField]
  private GameObject loadingPopUpUI;

  [SerializeField]
  private SaveGameController saveGameController;

  [SerializeField]
  private ProductListController consumableListController;

  [SerializeField]
  private ProductListController weaponsListController;

  [SerializeField]
  private ProductListController ammoListController;

  [SerializeField]
  private Text playerCoinsText;

  public bool isOrdering = false;
  private List<ProductProjection> consumableProductsList;
  private List<ProductProjection> weaponProductsList;
  private List<ProductProjection> ammoProductsList;
  #endregion

  #region UnityMethods
  // Start is called before the first frame update
  void Start()
  {
    isOrdering = false;
    LoadPlayerCoins();
    StartCoroutine(LoadConsumableProducts());
    StartCoroutine(LoadWeaponProducts());
    StartCoroutine(LoadAmmoProducts());
  }

  void OnEnable()
  {
    isOrdering = false;
    LoadPlayerCoins();
    StartCoroutine(LoadConsumableProducts());
    StartCoroutine(LoadWeaponProducts());
    StartCoroutine(LoadAmmoProducts());
  }

  // Update is called once per frame
  void Update()
  {

  }
  #endregion

  #region LoadStoreMethods
  private void LoadPlayerCoins()
  {
    SaveData data = SaveGameController.GetSavedData();
    playerCoinsText.text = data.playerCoins.ToString();
  }
  private IEnumerator LoadConsumableProducts()
  {
    UnityClient client = CommercetoolsManager.GetClient(ProjectScope.ViewProducts, this);
    consumableProductsList = new List<ProductProjection>();
    ProductProjectionManager ppManager = new ProductProjectionManager(client);
    ProductTypeManager productTypeManager = new ProductTypeManager(client);
    string productTypeName = "Consumable";

    string ptWhereName = "name=\"" + productTypeName + "\"";
    Response<ProductTypeQueryResult> productTypeResponse = null;

    yield return StartCoroutine(
      productTypeManager.QueryProductTypesAsync(
        (Response<ProductTypeQueryResult> onSuccess) =>
        {
          productTypeResponse = onSuccess;
        },
        (Response<ProductTypeQueryResult> onError) =>
        {
          Debug.LogError("Error fetching product types: " + onError.ToJsonString());
        },
        ptWhereName
      )
    );

    Response<ProductProjectionQueryResult> productProjectionsResponse = null;

    if (productTypeResponse.Success && productTypeResponse.Result.Results.Count > 0)
    {
      ProductType myProductType = productTypeResponse.Result.Results[0];

      string productsWhere = "productType(id=\"" + myProductType.Id + "\")";
      yield return StartCoroutine(
        ppManager.QueryProductProjectionsAsync(
          (Response<ProductProjectionQueryResult> onSuccess) =>
          {
            productProjectionsResponse = onSuccess;
          },
          (Response<ProductProjectionQueryResult> onError) =>
          {
            Debug.LogError("Error fetching product projections: " + onError.ToJsonString());
          },
          productsWhere
        )
      );

      if (productProjectionsResponse.Success)
      {
        consumableProductsList = productProjectionsResponse.Result.Results;
        consumableListController.PopulateList(consumableProductsList);
      }
    }
  }

  private IEnumerator LoadWeaponProducts()
  {
    UnityClient client = CommercetoolsManager.GetClient(ProjectScope.ViewProducts, this);
    consumableProductsList = new List<ProductProjection>();
    ProductProjectionManager ppManager = new ProductProjectionManager(client);
    ProductTypeManager productTypeManager = new ProductTypeManager(client);
    string productTypeName = "Weapon";

    string ptWhereName = "name=\"" + productTypeName + "\"";
    Response<ProductTypeQueryResult> productTypeResponse = null;

    yield return StartCoroutine(
      productTypeManager.QueryProductTypesAsync(
        (Response<ProductTypeQueryResult> onSuccess) =>
        {
          productTypeResponse = onSuccess;
        },
        (Response<ProductTypeQueryResult> onError) =>
        {
          Debug.LogError("Error fetching product types: " + onError.ToJsonString());
        },
        ptWhereName
      )
    );

    Response<ProductProjectionQueryResult> productProjectionsResponse = null;

    if (productTypeResponse.Success && productTypeResponse.Result.Results.Count > 0)
    {
      ProductType myProductType = productTypeResponse.Result.Results[0];

      string productsWhere = "productType(id=\"" + myProductType.Id + "\")";
      yield return StartCoroutine(
        ppManager.QueryProductProjectionsAsync(
          (Response<ProductProjectionQueryResult> onSuccess) =>
          {
            productProjectionsResponse = onSuccess;
          },
          (Response<ProductProjectionQueryResult> onError) =>
          {
            Debug.LogError("Error fetching product projections: " + onError.ToJsonString());
          },
          productsWhere
        )
      );

      if (productProjectionsResponse.Success)
      {
        weaponProductsList = productProjectionsResponse.Result.Results;
        weaponsListController.PopulateList(weaponProductsList);
      }
    }
  }

  private IEnumerator LoadAmmoProducts()
  {
    UnityClient client = CommercetoolsManager.GetClient(ProjectScope.ViewProducts, this);
    consumableProductsList = new List<ProductProjection>();
    ProductProjectionManager ppManager = new ProductProjectionManager(client);
    ProductTypeManager productTypeManager = new ProductTypeManager(client);
    string productTypeName = "Ammo";

    string ptWhereName = "name=\"" + productTypeName + "\"";
    Response<ProductTypeQueryResult> productTypeResponse = null;

    yield return StartCoroutine(
      productTypeManager.QueryProductTypesAsync(
        (Response<ProductTypeQueryResult> onSuccess) =>
        {
          productTypeResponse = onSuccess;
        },
        (Response<ProductTypeQueryResult> onError) =>
        {
          Debug.LogError("Error fetching product types: " + onError.ToJsonString());
        },
        ptWhereName
      )
    );

    Response<ProductProjectionQueryResult> productProjectionsResponse = null;

    if (productTypeResponse.Success && productTypeResponse.Result.Results.Count > 0)
    {
      ProductType myProductType = productTypeResponse.Result.Results[0];

      string productsWhere = "productType(id=\"" + myProductType.Id + "\")";
      yield return StartCoroutine(
        ppManager.QueryProductProjectionsAsync(
          (Response<ProductProjectionQueryResult> onSuccess) =>
          {
            productProjectionsResponse = onSuccess;
          },
          (Response<ProductProjectionQueryResult> onError) =>
          {
            Debug.LogError("Error fetching product projections: " + onError.ToJsonString());
          },
          productsWhere
        )
      );

      if (productProjectionsResponse.Success)
      {
        ammoProductsList = productProjectionsResponse.Result.Results;
        ammoListController.PopulateList(ammoProductsList);
      }
    }
  }

  #endregion

  #region CartStoreMethods
  private string GetAnonymousId()
  {
    SaveData saveData = SaveGameController.GetSavedData();
    string anonymousId = saveData.anonymousId;

    if (anonymousId == "" || anonymousId == null)
    {
      anonymousId = CommercetoolsManager.GenerateAnonymousId();
      saveGameController.UpdateAnonymousId(anonymousId);
    }

    return anonymousId;
  }

  public IEnumerator BuyProduct(ProductProjection product)
  {
    isOrdering = true;
    consumableListController.DisableButtons();
    weaponsListController.DisableButtons();
    ammoListController.DisableButtons();
    loadingPopUpUI.gameObject.SetActive(true);

    SaveData saveData = SaveGameController.GetSavedData();
    UnityClient client = CommercetoolsManager.GetClient(ProjectScope.ManageOrders, this);
    if (saveData.playerCoins >= (product.MasterVariant.Prices[0].Value.CentAmount / 100))
    {
      CartManager cartManager = new CartManager(client);
      CartDraft cartDraft = new CartDraft("EUR");
      LineItemDraft lineItemDraft = new LineItemDraft(product.Id, product.MasterVariant.Id);
      lineItemDraft.Quantity = 1;
      List<LineItemDraft> lineItemDraftList = new List<LineItemDraft>() { lineItemDraft };

      cartDraft.LineItems = lineItemDraftList;
      cartDraft.AnonymousId = GetAnonymousId();
      cartDraft.ShippingAddress = CommercetoolsManager.GetMockedAddress();

      Response<Cart> responseCart = null;
      yield return StartCoroutine(
        cartManager.CreateCartAsync(
          cartDraft,
          (Response<Cart> onSuccess) =>
            {
              responseCart = onSuccess;
            },
          (Response<Cart> onError) =>
            {
              Debug.LogError("Error Creating Cart: " + onError.ToJsonString());
            }
        )
      );


      if (responseCart != null && responseCart.Success)
      {
        Debug.Log("Cart created! : " + responseCart.Result.ToJsonString());
        // If there's a cart, let's create an order from it
        OrderManager orderManager = new OrderManager(client);
        OrderFromCartDraft orderFromCartDraft = new OrderFromCartDraft(responseCart.Result);
        orderFromCartDraft.OrderNumber = CommercetoolsManager.GenerateOrderNumber();

        Response<Order> responseOrder = null;
        yield return StartCoroutine(
          orderManager.CreateOrderFromCartAsync(
            orderFromCartDraft,
            (Response<Order> onSuccess) =>
              {
                responseOrder = onSuccess;
              },
            (Response<Order> onError) =>
              {
                Debug.LogError("Error Creating Order: " + onError.ToJsonString());
              }
          )
        );

        if (responseOrder != null && responseOrder.Success)
        {
          Debug.Log("Order created! : " + responseOrder.Result.ToJsonString());
          Order order = responseOrder.Result;

          int newCoins = saveData.playerCoins - (int)(order.TotalPrice.CentAmount / 100);
          saveGameController.UpdateCoin(newCoins);
          saveGameController.UpdateCoinSpent((int)(order.TotalPrice.CentAmount / 100));
          LoadPlayerCoins();
          ProcessOrderToSaveData(order);
          FindObjectOfType<PlayerWeaponController>().UpdateAllWeaponsAmmo();
        }
        else
        {
          Debug.LogError("Order Error: " + responseOrder.Errors.ToJsonString());
        }
      }
      else
      {
        Debug.LogError("RES: " + responseCart.ToJsonString());
        Debug.LogError("Cart Error: " + responseCart.Errors.ToJsonString());
        Debug.LogError("CD: " + cartDraft.ToJsonString());
      }
    }
    else
    {
      // Don't have enough money
    }

    isOrdering = false;
    loadingPopUpUI.gameObject.SetActive(false);
    LoadConsumableProducts();
    LoadWeaponProducts();
    LoadAmmoProducts();
  }
  #endregion

  #region Utils
  private void ProcessOrderToSaveData(Order order)
  {
    string orderedProductName = order.LineItems[0].Name.GetValue("en-US");
    SaveData saveData = SaveGameController.GetSavedData();

    switch (orderedProductName)
    {
      case "Potion":
        saveData.SetPotionsCount(saveData.potionsCount + 1);
        break;

      case "Superpotion":
        saveData.SetSuperPotionsCount(saveData.superPotionsCount + 1);
        break;

      case "Hyperpotion":
        saveData.SetHyperPotionsCount(saveData.hyperPotionsCount + 1);
        break;

      case "Phaser":
        saveData.SetHasPhaser(true);
        break;

      case "Laser":
        saveData.SetHasLaser(true);
        break;

      case "Cannon":
        saveData.SetHasBombthrower(true);
        break;

      case "Phaser Charge":
        saveData.SetPhaserAmmo(saveData.phaserAmmo.GetQuantity() + 10);
        break;

      case "Laser Charge":
        saveData.SetLaserAmmo(saveData.laserAmmo.GetQuantity() + 10);
        break;

      case "Cannon Charge":
        saveData.SetSmokeBombAmmo(saveData.smokeBombAmmo.GetQuantity() + 10);
        break;
    }

    SaveGameController.WriteDataToStorage(saveData);
  }
  #endregion
}
