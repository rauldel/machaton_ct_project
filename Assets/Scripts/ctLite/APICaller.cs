using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ctLite.Common;
using ctLite.ProductProjections;

public class APICaller : MonoBehaviour
{
  private static Configuration configuration;
  private static UnityClient client;
  // Start is called before the first frame update
  IEnumerator Start()
  {
    client = GetUnityClient(ProjectScope.ViewProducts);


    Response<ProductProjectionQueryResult> res = new Response<ProductProjectionQueryResult>();
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

    Debug.Log("MAIN START SCRIPT AFTER GET: " + res.ToJsonString());
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
        ctClientData.clientId,
        ctClientData.clientSecret,
        scope
    );


      client = new UnityClient(configuration, this);
    }
    return client;
  }
}
