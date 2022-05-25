using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

using myCT.ProductProjections;

public class ProductButtonController : MonoBehaviour
{
  #region Properties
  [SerializeField]
  private Text productName;

  [SerializeField]
  private Text productPrice;

  [SerializeField]
  private UnityEngine.UI.Image productImage;

  [SerializeField]
  private Sprite loadingSprite;

  [SerializeField]
  private StoreController storeController;

  private ProductProjection product;

  #endregion

  #region Constructors
  public ProductButtonController() { }

  #endregion

  #region Methods
  public void setProduct(ProductProjection p)
  {
    product = p;

    productName.text = product.Name.GetValue("en-US");
    productPrice.text = (((float)product.MasterVariant.Prices[0].Value.CentAmount) / 100).ToString();

    if (product.MasterVariant.Images.Count > 0)
    {
      StartCoroutine(LoadImageFromURL(product.MasterVariant.Images[0].Url));
    }
    else
    {
      productImage.color = Color.cyan;
    }

    SaveData saveData = SaveGameController.GetSavedData();
    if (saveData.playerCoins < (product.MasterVariant.Prices[0].Value.CentAmount / 100) || DisableWeaponIfAlreadyBought(saveData))
    {
      DisableButton();
    }
  }

  public void DummyPopulation()
  {
    SetProductName("Dummy name");
    SetProductPrice("5.00");
  }

  public void SetProductName(string pName)
  {
    productName.text = pName;
  }

  public void SetProductPrice(string pPrice)
  {
    productPrice.text = pPrice;
  }

  public void SetProductImage(UnityEngine.UI.Image pImage)
  {
    productImage = pImage;
  }

  public void DisableButton()
  {
    Button button = GetComponent<Button>();
    button.interactable = false;
  }

  public void EnableButton()
  {
    Button button = GetComponent<Button>();
    button.interactable = true;
  }

  public void OnClick()
  {
    if (product != null)
    {
      AudioManager audioManager = AudioManager.instance;
      audioManager.PlaySound("ClickSFX", false);
      storeController.BuyProduct(product);
    }
  }

  public IEnumerator LoadImageFromURL(string imageURL)
  {
    productImage.sprite = loadingSprite;
    //Debug.Log("Loading image -> " + imageURL);
    UnityWebRequest imageLoader = UnityWebRequestTexture.GetTexture(imageURL);
    yield return imageLoader.SendWebRequest();

    if (imageLoader.isNetworkError || imageLoader.isHttpError)
    {
      Debug.LogError("Error getting image: " + imageURL);
    }
    else
    {
      // Debug.Log("Image Loaded");
      Texture2D texture2D = ((DownloadHandlerTexture)imageLoader.downloadHandler).texture;
      productImage.sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0, 0));
    }
  }

  private bool DisableWeaponIfAlreadyBought(SaveData saveData)
  {

    switch (productName.text)
    {
      case "Phaser":
        if (saveData.hasPhaser)
        {
          return true;
        }
        break;
      case "Laser":
        if (saveData.hasLaser)
        {
          return true;
        }
        break;
      case "Cannon":
        if (saveData.hasBombthrower)
        {
          return true;
        }
        break;
    }

    return false;
  }
  #endregion
}
