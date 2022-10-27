using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using ctLite.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ctLite.CartDiscounts
{
    public class CartDiscountManager
    {
        #region Constants

        private const string ENDPOINT_PREFIX = "/cart-discounts";

        #endregion

        #region Member Variables

        private readonly UnityClient _client;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">Client</param>
        public CartDiscountManager(UnityClient client)
        {
            _client = client;
        }

        #endregion

        #region API Methods

        /// <summary>
        /// Gets a Cart Discount by its ID.
        /// </summary>
        /// <param name="cartDiscountId">CartDiscountId ID</param>
        /// <see href="https://dev.commercetools.com/http-api-projects-cartDiscounts.html#get-cartdiscount-by-id"/>
        /// <returns>CartDiscount</returns>
        public IEnumerator GetCartDiscountByIdAsync(string cartDiscountId, Action<Response<CartDiscount>> onSuccess, Action<Response<CartDiscount>> onError)
        {
            if (string.IsNullOrWhiteSpace(cartDiscountId))
            {
                throw new ArgumentException("cartdiscountId is required");
            }

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", cartDiscountId);
            return _client.GetAsync<CartDiscount>(endpoint, onSuccess, onError);
        }

        /// <summary>
        /// Queries for CartDiscount.
        /// </summary>
        /// <param name="where">Where</param>
        /// <param name="sort">Sort</param>
        /// <param name="limit">Limit</param>
        /// <param name="offset">Offset</param>
        /// <returns>CartDiscountQueryResult</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-cartDiscounts.html#query-cartdiscounts"/>
        public IEnumerator QueryCartDiscountsAsync(Action<Response<CartDiscountQueryResult>> onSuccess, Action<Response<CartDiscountQueryResult>> onError, string where = null, string sort = null, int limit = -1, int offset = -1)
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

            return _client.GetAsync<CartDiscountQueryResult>(ENDPOINT_PREFIX, onSuccess, onError, values);
        }

        /// <summary>
        /// Creates a new CartDiscount.
        /// </summary>
        /// <param name="cartDiscountDraft">CartDiscountDraft</param>
        /// <returns>CartDiscount</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-cartDiscounts.html#create-a-cartdiscount"/>
        public IEnumerator CreateCartDiscountAsync(CartDiscountDraft cartDiscountDraft, Action<Response<CartDiscount>> onSuccess, Action<Response<CartDiscount>> onError)
        {
            string payload = JsonConvert.SerializeObject(cartDiscountDraft, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return _client.PostAsync<CartDiscount>(ENDPOINT_PREFIX, payload, onSuccess, onError);
        }

        /// <summary>
        /// Removes a CartDiscount.
        /// </summary>
        /// <param name="cartDiscount">CartDiscount</param>
        /// <returns>CartDiscount</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-cartDiscounts.html#delete-cartdiscount"/>
        public IEnumerator DeleteCartDiscountAsync(CartDiscount cartDiscount, Action<Response<CartDiscount>> onSuccess, Action<Response<CartDiscount>> onError)
        {
            return DeleteCartDiscountAsync(cartDiscount.Id, cartDiscount.Version, onSuccess, onError);
        }

        /// <summary>
        /// Removes a CartDiscount.
        /// </summary>
        /// <param name="cartDiscountId">CartDiscount ID</param>
        /// <param name="version">CartDiscount version</param>
        /// <returns>CartDiscount</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-cartDiscounts.html#delete-cartdiscount"/>
        public IEnumerator DeleteCartDiscountAsync(string cartDiscountId, int version, Action<Response<CartDiscount>> onSuccess, Action<Response<CartDiscount>> onError)
        {
            if (string.IsNullOrWhiteSpace(cartDiscountId))
            {
                throw new ArgumentException("CartDiscount ID is required");
            }

            if (version < 1)
            {
                throw new ArgumentException("Version is required");
            }

            var values = new NameValueCollection
            {
                { "version", version.ToString() }
            };

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", cartDiscountId);
            return _client.DeleteAsync<CartDiscount>(endpoint, onSuccess, onError, values);
        }

        /// <summary>
        /// Updates a cart discount.
        /// </summary>
        /// <param name="cartDiscount">CartDiscount</param>
        /// <param name="action">The update action to be performed on the cart discount.</param>
        /// <returns>CartDiscount</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-cartDiscounts.html#update-cartdiscount"/>
        public IEnumerator UpdateCartDiscountAsync(CartDiscount cartDiscount, UpdateAction action, Action<Response<CartDiscount>> onSuccess, Action<Response<CartDiscount>> onError)
        {
            return UpdateCartDiscountAsync(cartDiscount.Id, cartDiscount.Version, new List<UpdateAction> { action }, onSuccess, onError);
        }

        /// <summary>
        /// Updates a cart discount.
        /// </summary>
        /// <param name="cartDiscount">CartDiscount</param>
        /// <param name="actions">The list of update actions to be performed on the cart discount.</param>
        /// <returns>CartDiscount</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-cartDiscounts.html#update-cartdiscount"/>
        public IEnumerator UpdateCartDiscountAsync(CartDiscount cartDiscount, List<UpdateAction> actions, Action<Response<CartDiscount>> onSuccess, Action<Response<CartDiscount>> onError)
        {
            return UpdateCartDiscountAsync(cartDiscount.Id, cartDiscount.Version, actions, onSuccess, onError);
        }

        /// <summary>
        /// Updates a cart discount.
        /// </summary>
        /// <param name="cartDiscountId">ID of the cart discount</param>
        /// <param name="version">The expected version of the cart discount on which the changes should be applied.</param>
        /// <param name="actions">The list of update actions to be performed on the cart discount.</param>
        /// <returns>CartDiscount</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-cartDiscounts.html#update-cartdiscount"/>
        public IEnumerator UpdateCartDiscountAsync(string cartDiscountId, int version, List<UpdateAction> actions, Action<Response<CartDiscount>> onSuccess, Action<Response<CartDiscount>> onError)
        {
            if (string.IsNullOrWhiteSpace(cartDiscountId))
            {
                throw new ArgumentException("CartDiscount ID is required");
            }

            if (version < 1)
            {
                throw new ArgumentException("Version is required");
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

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", cartDiscountId);
            return _client.PostAsync<CartDiscount>(endpoint, data.ToString(), onSuccess, onError);
        }
        #endregion
    }
}
