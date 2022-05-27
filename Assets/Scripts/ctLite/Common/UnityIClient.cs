using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;

using UnityEngine;

namespace ctLite.Common
{
  public interface UnityIClient
  {
      /// <summary>
        /// Configuration
        /// </summary>
        Configuration Configuration { get; }

        /// <summary>
        /// Token
        /// </summary>
        Token Token { get; }

        /// <summary>
        /// Executes a GET request.
        /// </summary>
        /// <param name="endpoint">API endpoint, excluding the project key</param>
        /// <param name="values">Values</param>
        /// <returns>JSON object</returns>
        IEnumerator<Response<T>> GetAsync<T>(string endpoint, NameValueCollection values = null);

        /// <summary>
        /// Executes a POST request.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="payload">Body of the request</param>
        /// <returns>JSON object</returns>
        IEnumerator<Response<T>> PostAsync<T>(string endpoint, string payload);

        /// <summary>
        /// Executes a DELETE request.
        /// </summary>
        /// <param name="endpoint">API endpoint, excluding the project key</param>
        /// <param name="values">Values</param>
        /// <returns>JSON object</returns>
        IEnumerator<Response<T>> DeleteAsync<T>(string endpoint, NameValueCollection values = null);

        /// <summary>
        /// Retrieves a token from the authorization API using the client credentials flow.
        /// </summary>
        /// <returns>Token</returns>
        /// <see href="http://dev.commercetools.com/http-api-authorization.html#authorization-flows"/>
        IEnumerator<Response<Token>> GetTokenAsync();

        /// <summary>
        /// Refreshes a token from the authorization API using the refresh token flow.
        /// </summary>
        /// <param name="refreshToken">Refresh token value from the current token</param>
        /// <returns>Token</returns>
        /// <see href="http://dev.commercetools.com/http-api-authorization.html#authorization-flows"/>
        IEnumerator<Response<Token>> RefreshTokenAsync(string refreshToken);
  }

}
