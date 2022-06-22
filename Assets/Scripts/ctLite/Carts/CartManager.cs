using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using ctLite.Common;
using ctLite.Customers;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ctLite.Carts
{
  /// <summary>
  /// Provides access to the functions in the Carts section of the API.
  /// </summary>
  /// <see href="http://dev.commercetools.com/http-api-projects-carts.html"/>
  public class CartManager
  {
    #region Constants

    private const string ENDPOINT_PREFIX = "/carts";

    #endregion

    #region Member Variables

    private readonly UnityClient _client;

    #endregion

    #region Constructors

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="client">Client</param>
    public CartManager(UnityClient client)
    {
      _client = client;
    }

    #endregion

    #region API Methods

    /// <summary>
    /// Gets a Cart by its ID.
    /// </summary>
    /// <param name="cartId">Cart ID</param>
    /// <see href="http://dev.commercetools.com/http-api-projects-carts.html#get-cart-by-id"/>
    /// <returns>Cart</returns>
    public IEnumerator GetCartByIdAsync(string cartId, Action<Response<Cart>> onSuccess, Action<Response<Cart>> onError)
    {
      if (string.IsNullOrWhiteSpace(cartId))
      {
        throw new ArgumentException("cartId is required");
      }

      string endpoint = string.Concat(ENDPOINT_PREFIX, "/", cartId);
      return _client.GetAsync<Cart>(endpoint, onSuccess, onError);
    }

    /// <summary>
    /// Retrieves the active cart of the customer that has been modified most recently.
    /// </summary>
    /// <param name="customer">Customer</param>
    /// <returns>Cart</returns>
    /// <see href="http://dev.commercetools.com/http-api-projects-carts.html#get-cart-by-customer-id"/>
    public IEnumerator GetCartByCustomerAsync(Customer customer, Action<Response<Cart>> onSuccess, Action<Response<Cart>> onError)
    {
      return GetCartByCustomerIdAsync(customer.Id, onSuccess, onError);
    }

    /// <summary>
    /// Retrieves the active cart of the customer that has been modified most recently.
    /// </summary>
    /// <param name="customerId">Customer ID</param>
    /// <returns>Cart</returns>
    /// <see href="http://dev.commercetools.com/http-api-projects-carts.html#get-cart-by-customer-id"/>
    public IEnumerator GetCartByCustomerIdAsync(string customerId, Action<Response<Cart>> onSuccess, Action<Response<Cart>> onError)
    {
      if (string.IsNullOrWhiteSpace(customerId))
      {
        throw new ArgumentException("customerId is required");
      }

      string endpoint = string.Concat(ENDPOINT_PREFIX, "/?customerId=", customerId);
      return _client.GetAsync<Cart>(endpoint, onSuccess, onError);
    }

    /// <summary>
    /// Queries for Carts.
    /// </summary>
    /// <param name="where">Where</param>
    /// <param name="sort">Sort</param>
    /// <param name="limit">Limit</param>
    /// <param name="offset">Offset</param>
    /// <returns>CartQueryResult</returns>
    /// <see href="http://dev.commercetools.com/http-api-projects-carts.html#query-carts"/>
    public IEnumerator QueryCartsAsync(Action<Response<CartQueryResult>> onSuccess, Action<Response<CartQueryResult>> onError, string where = null, string sort = null, int limit = -1, int offset = -1)
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

      return _client.GetAsync<CartQueryResult>(ENDPOINT_PREFIX, onSuccess, onError, values);
    }

    /// <summary>
    /// Creates a new Cart.
    /// </summary>
    /// <param name="cartDraft">CartDraft</param>
    /// <returns>Cart</returns>
    /// <see href="http://dev.commercetools.com/http-api-projects-carts.html#create-cart"/>
    public IEnumerator CreateCartAsync(CartDraft cartDraft, Action<Response<Cart>> onSuccess, Action<Response<Cart>> onError)
    {
      if (string.IsNullOrWhiteSpace(cartDraft.Currency))
      {
        throw new ArgumentException("currency is required");
      }

      string payload = JsonConvert.SerializeObject(cartDraft, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
      return _client.PostAsync<Cart>(ENDPOINT_PREFIX, payload, onSuccess, onError);
    }

    /// <summary>
    /// Updates a cart.
    /// </summary>
    /// <param name="cart">Cart</param>
    /// <param name="action">The update action to be performed on the cart.</param>
    /// <returns>Cart</returns>
    /// <see href="http://dev.commercetools.com/http-api-projects-carts.html#update-cart"/>
    public IEnumerator UpdateCartAsync(Cart cart, UpdateAction action, Action<Response<Cart>> onSuccess, Action<Response<Cart>> onError)
    {
      return UpdateCartAsync(cart.Id, cart.Version, new List<UpdateAction> { action }, onSuccess, onError);
    }

    /// <summary>
    /// Updates a cart.
    /// </summary>
    /// <param name="cart">Cart</param>
    /// <param name="actions">The list of update actions to be performed on the cart.</param>
    /// <returns>Cart</returns>
    /// <see href="http://dev.commercetools.com/http-api-projects-carts.html#update-cart"/>
    public IEnumerator UpdateCartAsync(Cart cart, List<UpdateAction> actions, Action<Response<Cart>> onSuccess, Action<Response<Cart>> onError)
    {
      return UpdateCartAsync(cart.Id, cart.Version, actions, onSuccess, onError);
    }

    /// <summary>
    /// Updates a cart.
    /// </summary>
    /// <param name="cartId">ID of the cart</param>
    /// <param name="version">The expected version of the cart on which the changes should be applied.</param>
    /// <param name="actions">The list of update actions to be performed on the cart.</param>
    /// <returns>Cart</returns>
    /// <see href="http://dev.commercetools.com/http-api-projects-carts.html#update-cart"/>
    public IEnumerator UpdateCartAsync(string cartId, int version, List<UpdateAction> actions, Action<Response<Cart>> onSuccess, Action<Response<Cart>> onError)
    {
      if (string.IsNullOrWhiteSpace(cartId))
      {
        throw new ArgumentException("Cart ID is required");
      }

      if (version < 1)
      {
        throw new ArgumentException("Version is required");
      }

      if (actions == null || actions.Count < 1)
      {
        throw new ArgumentException("One or more update actions is required");
      }

      JObject data = JObject.FromObject(new
      {
        version = version,
        actions = JArray.FromObject(actions, new JsonSerializer { NullValueHandling = NullValueHandling.Ignore })
      });

      string endpoint = string.Concat(ENDPOINT_PREFIX, "/", cartId);
      return _client.PostAsync<Cart>(endpoint, data.ToString(), onSuccess, onError);
    }

    /// <summary>
    /// Removes a Cart. If it was assigned to a Customer, a new cart can be created for this customer.
    /// </summary>
    /// <param name="cart">Cart</param>
    /// <returns>Cart</returns>
    /// <see href="http://dev.commercetools.com/http-api-projects-carts.html#delete-cart"/>
    public IEnumerator DeleteCartAsync(Cart cart, Action<Response<Cart>> onSuccess, Action<Response<Cart>> onError)
    {
      return DeleteCartAsync(cart.Id, cart.Version, onSuccess, onError);
    }

    /// <summary>
    /// Removes a Cart. If it was assigned to a Customer, a new cart can be created for this customer.
    /// </summary>
    /// <param name="cartId">Cart ID</param>
    /// <param name="version">Cart version</param>
    /// <returns>Cart</returns>
    /// <see href="http://dev.commercetools.com/http-api-projects-carts.html#delete-cart"/>
    public IEnumerator DeleteCartAsync(string cartId, int version, Action<Response<Cart>> onSuccess, Action<Response<Cart>> onError)
    {
      if (string.IsNullOrWhiteSpace(cartId))
      {
        throw new ArgumentException("Cart ID is required");
      }

      if (version < 1)
      {
        throw new ArgumentException("Version is required");
      }

      var values = new NameValueCollection
            {
                { "version", version.ToString() }
            };

      string endpoint = string.Concat(ENDPOINT_PREFIX, "/", cartId);
      return _client.DeleteAsync<Cart>(endpoint, onSuccess, onError, values);
    }

    #endregion
  }
}
