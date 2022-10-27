using ctLite.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ctLite.Inventory
{
    /// <summary>
    /// Provides access to the functions in the Inventory section of the API.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-inventory.html"/>
    public class InventoryManager
    {
        #region Constants

        private const string ENDPOINT_PREFIX = "/inventory";

        #endregion

        #region Member Variables

        private UnityClient _client;

        #endregion 

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">Client</param>
        public InventoryManager(UnityClient client)
        {
            _client = client;
        }
        #endregion

        #region API Methods

        /// <summary>
        /// Gets an Inventory Entry by its ID.
        /// </summary>
        /// <param name="inventoryEntryId">InventoryEntry ID</param>
        /// <returns>InventoryEntry</returns>
        /// /// <see href="https://docs.commercetools.com/http-api-projects-inventory.html#get-inventoryentry-by-id"/>
        public IEnumerator GetInventoryEntryByIdAsync(string inventoryEntryId, Action<Response<InventoryEntry>> onSuccess, Action<Response<InventoryEntry>> onError)
        {
            if (string.IsNullOrWhiteSpace(inventoryEntryId))
            {
                throw new ArgumentException("inventoryEntryId is required");
            }

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", inventoryEntryId);
            return _client.GetAsync<InventoryEntry>(endpoint, onSuccess, onError);
        }

        /// <summary>
        /// Queries inventories.
        /// </summary>
        /// <param name="where">Where</param>
        /// <param name="sort">Sort</param>
        /// <param name="limit">Limit</param>
        /// <param name="offset">Offset</param>
        /// <returns>InventoryEntryQueryResult</returns>
        /// <see href="http://docs.commercetools.com/http-api-projects-inventory.html#query-inventory"/>
        public IEnumerator QueryInventoryAsync(Action<Response<InventoryEntryQueryResult>> onSuccess, Action<Response<InventoryEntryQueryResult>> onError, string where = null, string sort = null, int limit = -1, int offset = -1)
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

            return _client.GetAsync<InventoryEntryQueryResult>(ENDPOINT_PREFIX, onSuccess, onError, values);
        }

        /// <summary>
        /// Creates a new inventoryentry.
        /// </summary>
        /// <param name="inventoryEntryDraft">InventoryEntryDraft object</param>
        /// <returns>InventoryEntry</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-inventory.html#create-an-inventoryentry"/>
        public IEnumerator CreateInventoryEntryAsync(InventoryEntryDraft inventoryEntryDraft, Action<Response<InventoryEntry>> onSuccess, Action<Response<InventoryEntry>> onError)
        {
            if (inventoryEntryDraft == null)
            {
                throw new ArgumentException("inventoryEntryDraft cannot be null");
            }

            if (string.IsNullOrWhiteSpace(inventoryEntryDraft.Sku))
            {
                throw new ArgumentException("sku is required");
            }

            string payload = JsonConvert.SerializeObject(inventoryEntryDraft, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return _client.PostAsync<InventoryEntry>(ENDPOINT_PREFIX, payload, onSuccess, onError);
        }

        /// <summary>
        /// Updates an inventory entry.
        /// </summary>
        /// <param name="inventoryEntry">Inventory Entry</param>
        /// <param name="action">The update action to be performed on the inventory entry.</param>
        /// <returns>InventoryEntry</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-inventory.html#update-an-inventoryentry"/>
        public IEnumerator UpdateInventoryEntryAsync(InventoryEntry inventoryEntry, UpdateAction action, Action<Response<InventoryEntry>> onSuccess, Action<Response<InventoryEntry>> onError)
        {
            return UpdateInventoryEntryAsync(inventoryEntry.Id, inventoryEntry.Version, new List<UpdateAction> { action }, onSuccess, onError);
        }

        /// <summary>
        /// Updates an inventory entry.
        /// </summary>
        /// <param name="inventoryEntry">Inventory Entry</param>
        /// <param name="actions">The list of update actions to be performed on the inventory entry.</param>
        /// <returns>InventoryEntry</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-inventory.html#update-an-inventoryentry"/>
        public IEnumerator UpdateInventoryEntryAsync(InventoryEntry inventoryEntry, List<UpdateAction> actions, Action<Response<InventoryEntry>> onSuccess, Action<Response<InventoryEntry>> onError)
        {
            return UpdateInventoryEntryAsync(inventoryEntry.Id, inventoryEntry.Version, actions, onSuccess, onError);
        }

        /// <summary>
        /// Updates an inventory entry.
        /// </summary>
        /// <param name="inventoryEntryId">ID of the inventory entry</param>
        /// <param name="version">The expected version of the inventory entry on which the changes should be applied.</param>
        /// <param name="actions">The list of update actions to be performed on the inventory.</param>
        /// <returns>InventoryEntry</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-inventory.html#update-an-inventoryentry"/>
        public IEnumerator UpdateInventoryEntryAsync(string inventoryEntryId, int version, List<UpdateAction> actions, Action<Response<InventoryEntry>> onSuccess, Action<Response<InventoryEntry>> onError)
        {
            if (string.IsNullOrWhiteSpace(inventoryEntryId))
            {
                throw new ArgumentException("InventoryEntry ID is required");
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

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", inventoryEntryId);
            return _client.PostAsync<InventoryEntry>(endpoint, data.ToString(), onSuccess, onError);
        }

        /// <summary>
        /// Deletes an inventoryentry.
        /// </summary>
        /// <param name="inventoryEntry">Inventory Entry object</param>
        /// <returns>InventoryEntry</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-inventory.html#delete-an-inventoryentry"/>
        public IEnumerator DeleteInventoryEntryAsync(InventoryEntry inventoryEntry, Action<Response<InventoryEntry>> onSuccess, Action<Response<InventoryEntry>> onError)
        {
            return DeleteInventoryEntryAsync(inventoryEntry.Id, inventoryEntry.Version, onSuccess, onError);
        }

        /// <summary>
        /// Deletes an inventory entry.
        /// </summary>
        /// <param name="inventoryEntryId">Inventory Entry ID</param>
        /// <param name="version">Inventory version</param>
        /// <returns>InventoryEntry</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-inventory.html#delete-an-inventoryentry"/>
        public IEnumerator DeleteInventoryEntryAsync(string inventoryEntryId, int version, Action<Response<InventoryEntry>> onSuccess, Action<Response<InventoryEntry>> onError)
        {
            if (string.IsNullOrWhiteSpace(inventoryEntryId))
            {
                throw new ArgumentException("Inventory Entry ID is required");
            }

            if (version < 1)
            {
                throw new ArgumentException("Version is required");
            }

            var values = new NameValueCollection
            {
                { "version", version.ToString() }
            };

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", inventoryEntryId);
            return _client.DeleteAsync<InventoryEntry>(endpoint, onSuccess, onError, values);
        }

        #endregion
    }
}
