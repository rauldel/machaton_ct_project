using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CTClientData
{
  // Whenever want to regenerate the secrets, fill the id and secret and call from other gameobject CommercetoolsManager.GenerateSecretsFile()
  public string oAuthHost = "https://auth.europe-west1.gcp.commercetools.com/oauth/token";
  public string apiHost = "https://api.europe-west1.gcp.commercetools.com";
  public string projectKey = "cloud-runner";
  public string clientId = "";
  public string clientSecret = "";

  public CTClientData() { }

}