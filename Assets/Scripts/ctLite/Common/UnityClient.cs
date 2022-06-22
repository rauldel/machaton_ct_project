using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using UnityEngine;
using UnityEngine.Networking;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ctLite.Common
{
  public class UnityClient
  {
    #region Properties

    /// <summary>
    /// Configuration
    /// </summary>
    public Configuration Configuration { get; private set; }

    /// <summary>
    /// Token
    /// </summary>
    public static Token Token { get; private set; }

    /// <summary>
    /// The identifiying user agent that is included in all API requests.
    /// </summary>
    public string UserAgent { get; private set; }

    public MonoBehaviour monoBehaviour { get; private set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Constructor
    /// </summary>
    public UnityClient(Configuration configuration, MonoBehaviour mono)
    {
      this.Configuration = configuration;
      Assembly assembly = Assembly.GetExecutingAssembly();
      string assemblyVersion = assembly.GetName().Version.ToString();
      string dotNetVersion = Environment.Version.ToString();
      this.UserAgent = string.Format("commercetools-dotnet-sdk/{0} .NET/{1}", assemblyVersion, dotNetVersion);
      monoBehaviour = mono;
    }

    #endregion

    #region Web Service Methods

    /// <summary>
    /// Executes a GET request.
    /// </summary>
    /// <param name="endpoint">API endpoint, excluding the project key</param>
    /// <param name="values">Values</param>
    /// <returns>JSON object</returns>
    public IEnumerator GetAsync<T>(string endpoint, Action<Response<T>> onSuccess, Action<Response<T>> onError, NameValueCollection values = null)
    {
      Response<T> response = new Response<T>();
      Debug.Log("GETASYNC");
      yield return monoBehaviour.StartCoroutine(
        EnsureToken(
          (Response<Token> token) =>
          {
            Debug.Log("TOKEN ENSURED: " + token.ToJsonString());
            UnityClient.Token = token.Result;
          },
          (Response<Token> error) =>
          {
            Debug.LogError("TOKEN ERROR: " + error.ToJsonString());
          }));

      if (UnityClient.Token == null)
      {
        response.Success = false;
        response.Errors.Add(new ErrorMessage("no_token", "Could not retrieve token"));
        onError(response);
      }

      if (!string.IsNullOrWhiteSpace(endpoint) && !endpoint.StartsWith("/"))
      {
        endpoint = string.Concat("/", endpoint);
      }

      string url = string.Concat(this.Configuration.ApiUrl, "/", this.Configuration.ProjectKey, endpoint, values.ToQueryString());

      UnityClientRequestMessage unityClientRequestMessage = CreateRequestMessage(url, UnityWebRequest.kHttpVerbGET, false);
      Debug.Log("GET REQUEST: " + unityClientRequestMessage.ToJsonString());
      yield return monoBehaviour.StartCoroutine(SendAsync<T>(unityClientRequestMessage, false, (Response<T> res) =>
      {
        response = res;
        onSuccess(res);
      }, (Response<T> error) =>
      {
        Debug.LogError("GETASYNC ERROR: " + error.ToJsonString());
        onError(error);
      }));
    }

    public IEnumerator PostAsync<T>(string endpoint, string payload, Action<Response<T>> onSuccess, Action<Response<T>> onError)
    {
      Response<T> response = new Response<T>();

      yield return monoBehaviour.StartCoroutine(
        EnsureToken(
          (Response<Token> token) =>
          {
            Debug.Log("TOKEN ENSURED: " + token.ToJsonString());
            UnityClient.Token = token.Result;
          },
          (Response<Token> error) =>
          {
            Debug.LogError("TOKEN ERROR: " + error.ToJsonString());
          }));

      if (UnityClient.Token == null)
      {
        response.Success = false;
        response.Errors.Add(new ErrorMessage("no_token", "Could not retrieve token"));
        onError(response);
      }

      if (!string.IsNullOrWhiteSpace(endpoint) && !endpoint.StartsWith("/"))
      {
        endpoint = string.Concat("/", endpoint);
      }

      string url = string.Concat(this.Configuration.ApiUrl, "/", this.Configuration.ProjectKey, endpoint);

      UnityClientRequestMessage unityClientRequestMessage = CreateRequestMessage(url, UnityWebRequest.kHttpVerbPOST, false, payload);
      Debug.Log("POST REQUEST: " + unityClientRequestMessage.ToJsonString());
      yield return monoBehaviour.StartCoroutine(SendAsync<T>(unityClientRequestMessage, false, (Response<T> res) =>
      {
        response = res;
        onSuccess(res);
      }, (Response<T> error) =>
      {
        Debug.LogError("POSTASYNC ERROR: " + error.ToJsonString());
        onError(error);
      }));
    }

    public IEnumerator DeleteAsync<T>(string endpoint, Action<Response<T>> onSuccess, Action<Response<T>> onError, NameValueCollection values = null)
    {
      Response<T> response = new Response<T>();

      Debug.Log("DELETEASYNC");
      yield return monoBehaviour.StartCoroutine(
        EnsureToken(
          (Response<Token> token) =>
          {
            Debug.Log("TOKEN ENSURED: " + token.ToJsonString());
            UnityClient.Token = token.Result;
          },
          (Response<Token> error) =>
          {
            Debug.LogError("TOKEN ERROR: " + error.ToJsonString());
          }));

      if (UnityClient.Token == null)
      {
        response.Success = false;
        response.Errors.Add(new ErrorMessage("no_token", "Could not retrieve token"));
        onError(response);
      }

      if (!string.IsNullOrWhiteSpace(endpoint) && !endpoint.StartsWith("/"))
      {
        endpoint = string.Concat("/", endpoint);
      }

      string url = string.Concat(this.Configuration.ApiUrl, "/", this.Configuration.ProjectKey, endpoint, values.ToQueryString());

      UnityClientRequestMessage unityClientRequestMessage = CreateRequestMessage(url, UnityWebRequest.kHttpVerbDELETE, false);
      Debug.Log("DELETE REQUEST: " + unityClientRequestMessage.ToJsonString());
      yield return monoBehaviour.StartCoroutine(SendAsync<T>(unityClientRequestMessage, false, (Response<T> res) =>
      {
        response = res;
        onSuccess(res);
      }, (Response<T> error) =>
      {
        Debug.LogError("DELETEASYNC ERROR: " + error.ToJsonString());
        onError(error);
      }));
    }

    private UnityClientRequestMessage CreateRequestMessage(string url, string method, bool isTokenRequest, string payload = null)
    {
      UnityClientRequestMessage requestMessage = new UnityClientRequestMessage();
      requestMessage.url = url;
      requestMessage.method = method;
      requestMessage.isTokenRequest = isTokenRequest;
      requestMessage.payload = payload;

      switch (requestMessage.method)
      {
        case UnityWebRequest.kHttpVerbPOST:
          if (requestMessage.isTokenRequest)
          {
            WWWForm form = new WWWForm();
            form.AddField("grant_type", "client_credentials");
            form.AddField("scope", string.Concat(this.Configuration.Scope.ToEnumMemberString(), ":", this.Configuration.ProjectKey));
            requestMessage.wwwForm = form;

            requestMessage.headers.Add("Content-Type", "application/x-www-form-urlencoded");
            requestMessage.headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Concat(this.Configuration.ClientID, ":", this.Configuration.ClientSecret))));
          }
          else
          {
            requestMessage.downloadHandler = new DownloadHandlerBuffer();
            requestMessage.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(payload));
            requestMessage.uploadHandler.contentType = "application/json";
            requestMessage.headers.Add("Authorization", UnityClient.Token.TokenType + " " + UnityClient.Token.AccessToken);
            requestMessage.headers.Add("Content-Type", "application/json");
          }
          break;
        case UnityWebRequest.kHttpVerbDELETE:
          requestMessage.headers.Add("Authorization", UnityClient.Token.TokenType + " " + UnityClient.Token.AccessToken);
          requestMessage.headers.Add("Content-Type", "application/json");
          break;
        default:
        case UnityWebRequest.kHttpVerbGET:
          requestMessage.headers.Add("Authorization", UnityClient.Token.TokenType + " " + UnityClient.Token.AccessToken);
          requestMessage.headers.Add("Accept", "application/json");
          break;
      }

      return requestMessage;
    }

    /// <summary>
    /// Executes a request.
    /// </summary>
    /// <param name="endpoint">API endpoint, excluding the project key</param>
    /// <param name="values">Values</param>
    /// <returns>JSON object</returns>
    private IEnumerator SendAsync<T>(UnityClientRequestMessage unityRequestMessage, bool isTokenRequest, Action<Response<T>> onSuccess, Action<Response<T>> onError)
    {
      UnityWebRequest www = new UnityWebRequest(unityRequestMessage.url);

      if (unityRequestMessage.method == UnityWebRequest.kHttpVerbGET)
      {
        www = UnityWebRequest.Get(unityRequestMessage.url);
        www.method = unityRequestMessage.method;
        foreach (KeyValuePair<string, string> header in unityRequestMessage.headers)
        {
          www.SetRequestHeader(header.Key, header.Value);
        }
      }
      else if (unityRequestMessage.method == UnityWebRequest.kHttpVerbPOST)
      {
        if (unityRequestMessage.isTokenRequest)
        {
          www = UnityWebRequest.Post(unityRequestMessage.url, unityRequestMessage.wwwForm);
        }
        else
        {
          www = new UnityWebRequest(unityRequestMessage.url);
          www.method = unityRequestMessage.method;
          www.uploadHandler = unityRequestMessage.uploadHandler;
          www.downloadHandler = unityRequestMessage.downloadHandler;
        }

        foreach (KeyValuePair<string, string> header in unityRequestMessage.headers)
        {
          www.SetRequestHeader(header.Key, header.Value);
        }
      }
      else if (unityRequestMessage.method == UnityWebRequest.kHttpVerbDELETE)
      {
        www = UnityWebRequest.Delete(unityRequestMessage.url);
        foreach (KeyValuePair<string, string> header in unityRequestMessage.headers)
        {
          www.SetRequestHeader(header.Key, header.Value);
        }
      }

      yield return www.SendWebRequest();
      Debug.Log("SendAsync result: " + www.ToJsonString());

      Response<T> response = GetResponse<T>(www);

      if (response.Success)
      {
        Debug.Log("ONSUCESS SendAsync: " + response.ToJsonString());
        onSuccess(response);
        yield return onSuccess;
      }
      else
      {
        Debug.Log("OnError SendAsync: " + response.ToJsonString());
        onError(response);
        yield return onError;
      }
    }

    #endregion

    #region Token Methods
    private IEnumerator EnsureToken(Action<Response<Token>> onSuccess, Action<Response<Token>> onError)
    {
      if (UnityClient.Token == null || UnityClient.Token.IsExpired())
      {
        UnityClient.Token = null;
        yield return monoBehaviour.StartCoroutine(GetTokenAsync((Response<Token> res) =>
        {
          if (res != null && res.Success)
          {
            Debug.Log("Token safe: " + res.ToJsonString());
            UnityClient.Token = res.Result;
            onSuccess(res);
          }
        }, (Response<Token> error) =>
        {
          Debug.LogError("Error EnsureToken: " + error.ToJsonString());
          onError(error);
        }));
      }
    }

    /// <summary>
    /// Retrieves a token from the authorization API using the client credentials flow.
    /// </summary>
    /// <returns>Token</returns>
    /// <see href="http://dev.commercetools.com/http-api-authorization.html#authorization-flows"/>
    public IEnumerator GetTokenAsync(Action<Response<Token>> onSuccess, Action<Response<Token>> onError)
    {
      UnityClientRequestMessage unityClientRequestMessage = CreateRequestMessage(this.Configuration.OAuthUrl, UnityWebRequest.kHttpVerbPOST, true);
      Response<Token> response = null;
      yield return monoBehaviour.StartCoroutine(SendAsync<Token>(unityClientRequestMessage, true,
        (Response<Token> res) =>
          {
            response = res;
            Debug.Log("Success GetTokenAsync: " + res.ToJsonString());
            onSuccess(res);
          },
        (Response<Token> error) =>
          {
            Debug.LogError("Error GetTokenAsync: " + error.ToJsonString());
            onError(error);
          }
        )
      );
    }

    #endregion

    #region Utility
    private Response<T> GetResponse<T>(UnityWebRequest www)
    {
      Debug.Log("GETRESPONSE: " + www.ToJsonString());
      Response<T> response = new Response<T>();
      Type resultType = typeof(T);

      response.StatusCode = (int) www.responseCode;
      if (www.isNetworkError || www.responseCode < 200 || www.responseCode >= 300)
      {
        response.Success = false;
        response.Errors = new List<ErrorMessage>();
        response.Errors.Add(new ErrorMessage(www.responseCode.ToString(), www.error));
      }
      else
      {
        response.Success = true;
        if (resultType == typeof(JObject) || resultType == typeof(JArray) || resultType.IsArray || (resultType.IsGenericType && resultType.Name.Equals(typeof(List<>).Name)))
        {
          response.Result = JsonConvert.DeserializeObject<T>(www.downloadHandler.text);
        }
        else
        {
          JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
          serializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
          serializerSettings.NullValueHandling = NullValueHandling.Ignore;

          if (www.downloadHandler != null)
          {
            T t = JsonConvert.DeserializeObject<T>(www.downloadHandler.text, serializerSettings);
            response.Result = t;
          } else {
            response.Result = default(T);
          }

        }
      }

      return response;
    }
    #endregion
  }
}