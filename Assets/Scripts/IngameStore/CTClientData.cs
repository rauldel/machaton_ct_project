using System;
using System.Text;
using UnityEngine;

[System.Serializable]
public class CTClientData
{
  // Whenever want to regenerate the secrets, fill the id and secret and call from other gameobject CommercetoolsManager.GenerateSecretsFile()
  public string oAuthHost = "https://auth.europe-west1.gcp.commercetools.com/oauth/token";
  public string apiHost = "https://api.europe-west1.gcp.commercetools.com";
  public string projectKey = "cloud-runner";
  private string clientId = "VFU0dFlWZDBaelJSVjA5NFgyTk9VRk5YWDNsalMyaGg=";
  private string clientSecret = "YWtFM1ZrZHFXR0ZoU1RCclIyVm1hV3ByY21ORVMyMDFZek5tVlhGNWVsWT0=";

  public CTClientData() { }

  public string getClientId()
  {
    return decodeAttribute(clientId);
  }

  public string getClientSecret()
  {
    return decodeAttribute(clientSecret);
  }

  private string decodeAttribute(string attribute)
  {
    return Encoding.UTF8.GetString(
      Convert.FromBase64String(
        Encoding.UTF8.GetString(
          Convert.FromBase64String(
            attribute)
          )
        )
      );
  }
}