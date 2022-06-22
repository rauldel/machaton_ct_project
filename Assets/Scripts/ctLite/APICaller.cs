using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ctLite.Common;
using ctLite.Products;
using ctLite.Products.UpdateActions;
using ctLite.ProductProjections;

public class APICaller : MonoBehaviour
{
  private static Configuration configuration;
  private static UnityClient client;
  // Start is called before the first frame update
  IEnumerator Start()
  {
    client = GetUnityClient(ProjectScope.ManageProducts);


    /* Response<ProductProjectionQueryResult> res = new Response<ProductProjectionQueryResult>();
    yield return StartCoroutine(client.GetAsync<ProductProjectionQueryResult>("/product-projections?where=productType(id=\"d1bf8913-3d21-40e8-9bb2-03763925edf8\")",
    (Response<ProductProjectionQueryResult> response) =>
    {
      res = response;
      Debug.Log("ZICK ZACK: " + response.ToJsonString());
    },
    (Response<ProductProjectionQueryResult> error) =>
    {
      Debug.LogError("Error Getting GET: " + error.ToJsonString());
    }));

    Debug.Log("MAIN START SCRIPT AFTER GET: " + res.ToJsonString()); */

    /* LocalizedString ls = new LocalizedString();
    ls.SetValue("en-us", "Testarino Coroutine v2");
    ls.SetValue("de-de", "Armee der tristen");
    ChangeNameAction updateAction = new ChangeNameAction(ls);
    yield return StartCoroutine(client.PostAsync<Product>("/products/979e0b07-382e-4c68-ae16-dad3c79d2886", updateAction.ToJsonString(),
      (Response<Product> response) =>
      {
        Debug.Log("RES: " + response.ToJsonString());
      },
      (Response<Product> error) =>
      {
        Debug.Log("Error: " + error.ToJsonString());
      }
    )); */

    ProductManager pm = new ProductManager(client);
    Product p = null;

    yield return StartCoroutine(
      pm.GetProductByIdAsync(
        "477aac91-ca28-4718-b98d-05977472a928",
        (Response<Product> response) =>
          {
            p = response.Result;
            Debug.Log("Got Prod: " + p.ToJsonString());
          },
        (Response<Product> error) =>
          {
            Debug.LogError("Error Getting Prod: " + error.ToJsonString());
          }
        )
      );

/*     LocalizedString ls = new LocalizedString();
    ls.SetValue("en-us", "Testarino Coroutine v3");
    ls.SetValue("de-de", "Armee der tristen v3");
    ChangeNameAction updateAction = new ChangeNameAction(ls);
    List<UpdateAction> updateActions = new List<UpdateAction>() { updateAction };
    yield return StartCoroutine(
      pm.UpdateProductByIdAsync(
        p.Id,
        p.Version,
        updateActions,
        (Response<Product> response) =>
        {
          p = response.Result;
          Debug.Log("Updated Prod: " + p.ToJsonString());
        },
        (Response<Product> error) =>
        {
          Debug.LogError("Error Updating Prod: " + error.ToJsonString());
        }
      )
    ); */

    /* yield return StartCoroutine(
      pm.DeleteProductAsync(
        p,
        (Response<Product> response) =>
        {
          p = response.Result;
          Debug.Log("Deleted Prod: " + p.ToJsonString());
        },
        (Response<Product> error) =>
        {
          Debug.LogError("Error Deleting Prod: " + error.ToJsonString());
        }
      )
    ); */
  }

  // Update is called once per frame
  void Update()
  {

  }

  public UnityClient GetUnityClient(ProjectScope scope)
  {
    if (client == null || (client != null && configuration.Scope != scope))
    {
      CTClientData ctClientData = CommercetoolsManager.ReadSecretsFile();
      // Debug.Log("CT:" + ctClientData.ToJsonString());
      configuration = new Configuration(
        ctClientData.oAuthHost,
        ctClientData.apiHost,
        ctClientData.projectKey,
        //ctClientData.clientId,
        "PAm7qR4JBSClny1XL1lTj4cU",
        // ctClientData.clientSecret,
        "pVDqgXl8BssvD_hMhujWjEPRSv-PlNsP",
        scope
    );


      client = new UnityClient(configuration, this);
    }
    return client;
  }
}
