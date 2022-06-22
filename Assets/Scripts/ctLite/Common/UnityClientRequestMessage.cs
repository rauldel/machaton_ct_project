using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ctLite.Common
{
  public class UnityClientRequestMessage
  {
    #region Properties
    public Dictionary<string, string> headers { get; private set; }
    public bool isTokenRequest { get; set; }

    public string method { get; set; }
    public string url { get; set; }
    public string payload { get; set; }
    public UploadHandler uploadHandler { get; set; }
    public DownloadHandler downloadHandler { get; set; }
    public WWWForm wwwForm { get; set; }
    #endregion

    #region Constructors
    public UnityClientRequestMessage()
    {
      headers = new Dictionary<string, string>();
      isTokenRequest = false;
      method = UnityWebRequest.kHttpVerbGET;
      url = "";
      payload = null;
      uploadHandler = null;
      downloadHandler = null;
      wwwForm = null;
    }

    public UnityClientRequestMessage(
      bool isTokenRequest,
      string method,
      string url,
      string payload = null,
      UploadHandler uploadHandler = null,
      DownloadHandler downloadHandler = null,
      WWWForm wwwForm = null)
    {
      headers = new Dictionary<string, string>();
      this.isTokenRequest = isTokenRequest;
      this.method = method;
      this.url = url;
      this.payload = payload;
      this.uploadHandler = uploadHandler;
      this.downloadHandler = downloadHandler;
      this.wwwForm = wwwForm;
    }
    #endregion
  }
}