using UnityEngine;
using myCT.Common;

public static class CommercetoolsManager
{
  #region commercetoolsManagerAttributes
  private static string oAuthHost = "https://auth.europe-west1.gcp.commercetools.com/oauth/token";
  private static string apiHost = "https://api.europe-west1.gcp.commercetools.com";
  private static string projectKey = "cloud-runner";
  private static string clientId = "MN-aWtg4QWOx_cNPSW_ycKha";
  private static string clientSecret = "jA7VGjXaaI0kGefijkrcDKm5c3fUqyzV";

  /** Client Scopes **/
  // view_categories:cloud-runner manage_orders:cloud-runner view_payments:cloud-runner view_orders:cloud-runner view_products:cloud-runner view_key_value_documents:cloud-runner view_states:cloud-runner view_shipping_methods:cloud-runner view_import_sinks:cloud-runner view_attribute_groups:cloud-runner view_published_products:cloud-runner

  private static string anonymousIdPrefix = "cloud-runner";
  private static string orderNumberPrefix = "cr";

  private static Configuration configuration;
  private static Client client;
  #endregion

  public static Client GetClient(ProjectScope scope)
  {
    if (client == null || (client != null && configuration.Scope != scope))
    {
      configuration = new Configuration(
        oAuthHost,
        apiHost,
        projectKey,
        clientId,
        clientSecret,
        scope
    );

      client = new Client(configuration);
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
}
