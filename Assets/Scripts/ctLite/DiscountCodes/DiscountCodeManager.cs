using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using ctLite.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ctLite.DiscountCodes
{
    public class DiscountCodeManager
    {
        #region Constants

        private const string ENDPOINT_PREFIX = "/discount-codes";

        #endregion

        #region Member Variables

        private readonly UnityClient _client;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">Client</param>
        public DiscountCodeManager(UnityClient client)
        {
            _client = client;
        }

        #endregion

        #region API Methods

        /// <summary>
        /// Gets a Discount Code by its ID.
        /// </summary>
        /// <param name="discountCodeId">Discount Code ID</param>
        /// <see href="https://dev.commercetools.com/http-api-projects-discountCodes.html#get-discountcode-by-id"/>
        /// <returns>DiscountCode</returns>
        public IEnumerator GetDiscountCodeByIdAsync(string discountCodeId, Action<Response<DiscountCode>> onSuccess, Action<Response<DiscountCode>> onError)
        {
            if (string.IsNullOrWhiteSpace(discountCodeId))
            {
                throw new ArgumentException($"{nameof(discountCodeId)} is required");
            }

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", discountCodeId);
            return _client.GetAsync<DiscountCode>(endpoint, onSuccess, onError);
        }

        /// <summary>
        /// Queries for DiscountCode.
        /// </summary>
        /// <param name="where">Where</param>
        /// <param name="sort">Sort</param>
        /// <param name="limit">Limit</param>
        /// <param name="offset">Offset</param>
        /// <returns>DiscountCodeQueryResult</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-discountCodes.html#query-discountcodes"/>
        public IEnumerator QueryDiscountCodesAsync(Action<Response<DiscountCodeQueryResult>> onSuccess, Action<Response<DiscountCodeQueryResult>> onError, string where = null, string sort = null, int limit = -1, int offset = -1)
        {
            NameValueCollection values = new NameValueCollection();

            if (!string.IsNullOrWhiteSpace(where))
            {
                values.Add("where", where);
            }

            if (!string.IsNullOrWhiteSpace(sort))
            {
                values.Add("sort", sort);
            }

            if (limit > 0)
            {
                values.Add("limit", limit.ToString());
            }

            if (offset >= 0)
            {
                values.Add("offset", offset.ToString());
            }

            return _client.GetAsync<DiscountCodeQueryResult>(ENDPOINT_PREFIX, onSuccess, onError, values);
        }

        /// <summary>
        /// Creates a new Discount Code.
        /// </summary>
        /// <param name="discountCodeDraft">DiscountCodeDraft</param>
        /// <returns>DiscountCode</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-discountCodes.html#create-a-discountcode"/>
        public IEnumerator CreateDiscountCodeAsync(DiscountCodeDraft discountCodeDraft, Action<Response<DiscountCode>> onSuccess, Action<Response<DiscountCode>> onError)
        {
            string payload = JsonConvert.SerializeObject(discountCodeDraft, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return _client.PostAsync<DiscountCode>(ENDPOINT_PREFIX, payload, onSuccess, onError);
        }

        /// <summary>
        /// Removes a Discount Code.
        /// </summary>
        /// <param name="discountCode">DiscountCode</param>
        /// <returns>DiscountCode</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-discountCodes.html#delete-discountcode"/>
        public IEnumerator DeleteDiscountCodeAsync(DiscountCode discountCode, Action<Response<DiscountCode>> onSuccess, Action<Response<DiscountCode>> onError)
        {
            return DeleteDiscountCodeAsync(discountCode.Id, discountCode.Version, onSuccess, onError);
        }

        /// <summary>
        /// Removes a DiscountCode.
        /// </summary>
        /// <param name="discountCartId">DiscountCode ID</param>
        /// <param name="version">DiscountCode version</param>
        /// <returns>DiscountCode</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-discountCodes.html#delete-discountcode"/>
        public IEnumerator DeleteDiscountCodeAsync(string discountCartId, int version, Action<Response<DiscountCode>> onSuccess, Action<Response<DiscountCode>> onError)
        {
            if (string.IsNullOrWhiteSpace(discountCartId))
            {
                throw new ArgumentException($"{nameof(discountCartId)} is required");
            }

            if (version < 1)
            {
                throw new ArgumentException($"{nameof(version)} is required");
            }

            var values = new NameValueCollection
            {
                { "version", version.ToString() }
            };

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", discountCartId);
            return _client.DeleteAsync<DiscountCode>(endpoint, onSuccess, onError, values);
        }

        /// <summary>
        /// Updates a Discount Code.
        /// </summary>
        /// <param name="discountCode">DiscountCode</param>
        /// <param name="action">The update action to be performed on the discount code.</param>
        /// <returns>DiscountCode</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-discountCodes.html#update-discountcode"/>
        public IEnumerator UpdateDiscountCodeAsync(DiscountCode discountCode, UpdateAction action, Action<Response<DiscountCode>> onSuccess, Action<Response<DiscountCode>> onError)
        {
            return UpdateDiscountCodeAsync(discountCode.Id, discountCode.Version, new List<UpdateAction> { action }, onSuccess, onError);
        }

        /// <summary>
        /// Updates a Discount Code.
        /// </summary>
        /// <param name="discountCode">DiscountCode</param>
        /// <param name="actions">The list of update actions to be performed on the cart discount.</param>
        /// <returns>DiscountCode</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-discountCodes.html#update-discountcode"/>
        public IEnumerator UpdateDiscountCodeAsync(DiscountCode discountCode, List<UpdateAction> actions, Action<Response<DiscountCode>> onSuccess, Action<Response<DiscountCode>> onError)
        {
            return UpdateDiscountCodeAsync(discountCode.Id, discountCode.Version, actions, onSuccess, onError);
        }

        /// <summary>
        /// Updates a DiscountCode.
        /// </summary>
        /// <param name="discountCodeId">ID of the DiscountCode</param>
        /// <param name="version">The expected version of the discount code on which the changes should be applied.</param>
        /// <param name="actions">The list of update actions to be performed on the discount code.</param>
        /// <returns>DiscountCode</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-discountCodes.html#update-discountcode"/>
        public IEnumerator UpdateDiscountCodeAsync(string discountCodeId, int version, List<UpdateAction> actions, Action<Response<DiscountCode>> onSuccess, Action<Response<DiscountCode>> onError)
        {
            if (string.IsNullOrWhiteSpace(discountCodeId))
            {
                throw new ArgumentException($"{nameof(discountCodeId)} is required");
            }

            if (version < 1)
            {
                throw new ArgumentException($"{nameof(version)} should to be greater than zero");
            }

            if (actions == null || actions.Count < 1)
            {
                throw new ArgumentException("One or more update actions is required");
            }

            var data = JObject.FromObject(new
            {
                version,
                actions = JArray.FromObject(actions, new JsonSerializer { NullValueHandling = NullValueHandling.Ignore })
            });

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", discountCodeId);
            return _client.PostAsync<DiscountCode>(endpoint, data.ToString(), onSuccess, onError);
        }
        #endregion
    }
}
