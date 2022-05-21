using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

using myCT.Products;

public class ProductButtonController : MonoBehaviour
{
  #region Properties
  [SerializeField]
  private Text productName;

  [SerializeField]
  private Text productPrice;

  [SerializeField]
  private UnityEngine.UI.Image productImage;

  private Product product;

  #endregion

  #region Constructors
  public ProductButtonController() { }

  #endregion

  #region Methods
  public void setProduct(Product p)
  {
    product = p;

    productName.text = product.MasterData.Current.Name.GetValue("en-US");
    productPrice.text = (((float)product.MasterData.Current.MasterVariant.Prices[0].Value.CentAmount) / 100).ToString();

    if (product.MasterData.Current.MasterVariant.Images.Count > 0)
    {
      StartCoroutine(LoadImageFromURL(product.MasterData.Current.MasterVariant.Images[0].Url));
    }
    else
    {
      productImage.color = Color.cyan;
    }

  }

  public void DummyPopulation() {
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

  public void OnClick()
  {
    Debug.Log("Button clicked -> " + productName.text + " - Money: " + productPrice.text);
  }

  public IEnumerator LoadImageFromURL(string imageURL)
  {
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
  #endregion
}
