using UnityEngine;

using System;

using Newtonsoft.Json;

using ctLite.Common.Converters;

namespace ctLite.Common
{
    /// <summary>
    /// Represents a response from an authorization request using the client credentials flow.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-authorization.html#client-credentials-flow"/>
    public class Token
    {
        #region Properties

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; private set; }

        [JsonProperty(PropertyName = "scope")]
        [JsonConverter(typeof(ProjectScopeConverter))]
        public ProjectScope? ProjectScope { get; private set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; private set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; private set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; private set; }

        public DateTime? ExpiryDate { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Common.Token"/> class.
        /// </summary>
        public Token() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="accessToken">The token value</param>
        /// <param name="projectScope">Token's scope</param>
        /// <param name="refreshToken"></param>
        /// <param name="tokenType">Token's type</param>
        /// <param name="expiresIn">Token's validity duration</param>
        public Token(string accessToken, ProjectScope? projectScope, string refreshToken, string tokenType, int expiresIn) 
        {
            if (accessToken == null || refreshToken == null || tokenType == null || expiresIn <= 0)
            {
                return;
            }

            this.AccessToken = accessToken;
            this.ExpiresIn = expiresIn;
            this.ProjectScope = projectScope;
            this.RefreshToken = refreshToken;
            this.TokenType = tokenType;

            if (this.ExpiresIn > 0)
            {
                // Offset slightly as per commercetools recommendation
                this.ExpiryDate = DateTime.UtcNow.AddSeconds(this.ExpiresIn - 60);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks the expiry date against the current time to see if the token has expired.
        /// </summary>
        public bool IsExpired()
        {
            if (this.ExpiryDate == null) {
                // Offset slightly as per commercetools recommendation
                this.ExpiryDate = DateTime.UtcNow.AddSeconds(this.ExpiresIn - 60);
            }
            if (this.ExpiryDate.HasValue)
            {
                return DateTime.UtcNow.CompareTo(this.ExpiryDate.Value) >= 0;
            }

            return true;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:ctLite.Common.Token"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:ctLite.Common.Token"/>.</returns>
        public override string ToString()
        {
            String s = "Token {\n";
            s += "AccessToken: " + this.AccessToken + "\n";
            s += "ExpiresIn: " + this.ExpiresIn + "\n";
            s += "ProjectScope: " + this.ProjectScope + "\n";
            s += "RefreshToken: " + this.RefreshToken + "\n";
            s += "TokenType: " + this.TokenType + "\n";
            s += "}";
            return s;
        }

        #endregion 
    }
}