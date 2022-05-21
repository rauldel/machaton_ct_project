using myCT.Common;

public static class CommercetoolsManager
{
  #region commercetoolsManagerAttributes
  private static string oAuthHost = "https://auth.europe-west1.gcp.commercetools.com/oauth/token";
  private static string apiHost = "https://api.europe-west1.gcp.commercetools.com";
  private static string projectKey = "cloud-runner";
  private static string clientId = "Yvwyfq5008lvVt1Ue_zBhVnS";
  private static string clientSecret = "AYMKwnnPoe3vacF8dJJCHxv_boeL6LLz";

  private static Configuration configuration;
  private static Client client;
  #endregion

  public static Client GetClient()
  {
    if (client == null)
    {
      configuration = new Configuration(
        oAuthHost,
        apiHost,
        projectKey,
        clientId,
        clientSecret,
        ProjectScope.ViewProducts
    );

      client = new Client(configuration);
    }
    return client;
  }
}
