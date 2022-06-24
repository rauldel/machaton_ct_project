using UnityEngine;
// using myCT.Common;
using ctLite.Common;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class CommercetoolsManager
{
  #region commercetoolsManagerAttributes
  /** Client Scopes **/
  // view_categories:cloud-runner manage_orders:cloud-runner view_payments:cloud-runner view_orders:cloud-runner view_products:cloud-runner view_key_value_documents:cloud-runner view_states:cloud-runner view_shipping_methods:cloud-runner view_import_sinks:cloud-runner view_attribute_groups:cloud-runner view_published_products:cloud-runner

  private static string anonymousIdPrefix = "cloud-runner";
  private static string orderNumberPrefix = "cr";

  private static Configuration configuration;
  private static UnityClient client;
  #endregion

  public static UnityClient GetClient(ProjectScope scope, MonoBehaviour monoBehaviour)
  {
    if (client == null || (client != null && configuration.Scope != scope))
    {
      CTClientData ctClientData = CommercetoolsManager.ReadSecretsFile();
      Debug.Log("CT:" + ctClientData.ToJsonString());
      configuration = new Configuration(
        ctClientData.oAuthHost,
        ctClientData.apiHost,
        ctClientData.projectKey,
        ctClientData.clientId,
        ctClientData.clientSecret,
        scope
      );

      client = new UnityClient(configuration, monoBehaviour);
      client.InvalidateToken();
    }
    return client;
  }

  public static string GenerateAnonymousId()
  {
    string anonymousId = "";
    System.DateTime date = System.DateTime.UtcNow;
    int randomNumber = Random.Range(0, 100000);

    anonymousId = anonymousIdPrefix + "_" + randomNumber
    + "_" + date.Day + "-" + date.Month + "-" + date.Year
    + "_" + date.Hour + "-" + date.Minute + "-" + date.Second;

    return anonymousId;
  }

  public static string GenerateOrderNumber()
  {
    string orderNumber = "";
    System.DateTime date = System.DateTime.UtcNow;
    int randomNumber = Random.Range(0, 100000);

    orderNumber = orderNumberPrefix + "_" + randomNumber
    + "_" + date.Day + "-" + date.Month + "-" + date.Year
    + "_" + date.Hour + "-" + date.Minute + "-" + date.Second;

    return orderNumber;
  }

  #region MockingHelpers
  public static Address GetMockedAddress()
  {
    Address address = new Address();
    address.Title = "Yo";
    address.FirstName = "Cloud";
    address.LastName = "Runner";
    address.StreetName = "Sky Avenue";
    address.StreetNumber = "0";
    address.PostalCode = "2013";
    address.City = "Columbia";
    address.State = "North Carolina";
    address.Country = "US";
    address.Email = "cloud.runner@commercetools.com";

    return address;
  }
  #endregion

  #region SecretKeepers
  public static void GenerateSecretsFile()
  {
    string path = Application.streamingAssetsPath + "/secrets.dat";
    Debug.Log("path: " + path);

    BinaryFormatter formatter = new BinaryFormatter();
    FileStream stream = new FileStream(path, FileMode.Create);
    formatter.Serialize(stream, new CTClientData());
    stream.Close();
  }

  public static CTClientData ReadSecretsFile()
  {
    string path = Application.streamingAssetsPath + "/secrets.dat";

    if (File.Exists(path))
    {
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);
      CTClientData data = formatter.Deserialize(stream) as CTClientData;
      stream.Close();
      return data;
    }
    else
    {
      // This is for WebGL
      CTClientData data = new CTClientData();
      data.oAuthHost = "https://auth.europe-west1.gcp.commercetools.com/oauth/token";
      data.apiHost = "https://api.europe-west1.gcp.commercetools.com";
      data.projectKey = "cloud-runner";
      data.clientId = "MN-aWtg4QWOx_cNPSW_ycKha";
      data.clientSecret = "jA7VGjXaaI0kGefijkrcDKm5c3fUqyzV";
      return data;
      // throw new System.Exception("Missing file: secrets.dat");
    }
  }
  #endregion
}
