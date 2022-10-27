using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using ctLite.Common;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ctLite.Types
{
    /// <summary>
    /// Provides access to the functions in the Types section of the API. 
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-types.html"/>
    public class TypeManager
    {
        #region Constants

        private const string ENDPOINT_PREFIX = "/types";

        #endregion

        #region Member Variables

        private readonly UnityClient _client;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">Client</param>
        public TypeManager(UnityClient client)
        {
            _client = client;
        }

        #endregion

        #region API Methods

        /// <summary>
        /// Gets a Type by its ID.
        /// </summary>
        /// <param name="typeId">Type ID</param>
        /// <returns>Type</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-types.html#get-type-by-id"/>
        public IEnumerator GetTypeByIdAsync(string typeId, Action<Response<Type>> onSuccess, Action<Response<Type>> onError)
        {
            if (string.IsNullOrWhiteSpace(typeId))
            {
                throw new ArgumentException("typeId is required");
            }

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", typeId);
            return _client.GetAsync<Type>(endpoint, onSuccess, onError);
        }

        /// <summary>
        /// Queries for Types.
        /// </summary>
        /// <param name="where">Where</param>
        /// <param name="sort">Sort</param>
        /// <param name="limit">Limit</param>
        /// <param name="offset">Offset</param>
        /// <returns>TypeQueryResult</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-types.html#get-type-by-id"/>
        public IEnumerator QueryTypesAsync(Action<Response<TypeQueryResult>> onSuccess, Action<Response<TypeQueryResult>> onError, string where = null, string sort = null, int limit = -1, int offset = -1)
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

            return _client.GetAsync<TypeQueryResult>(ENDPOINT_PREFIX, onSuccess, onError, values);
        }

        /// <summary>
        /// Creates a new type.
        /// </summary>
        /// <param name="typeDraft">Type Draft</param>
        /// <returns>Type</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-types.html#create-type"/>
        public IEnumerator CreateTypeAsync(TypeDraft typeDraft, Action<Response<Type>> onSuccess, Action<Response<Type>> onError)
        {
            if (string.IsNullOrWhiteSpace(typeDraft.Key))
            {
                throw new ArgumentException("Key is required");
            }

            if (typeDraft.Name.IsEmpty())
            {
                throw new ArgumentException("At least one value for Name is required");
            }

            if (typeDraft.ResourceTypeIds.Count < 1)
            {
                throw new ArgumentException("At least one value for ResourceTypeIds is required");
            }

            string payload = JsonConvert.SerializeObject(typeDraft, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return _client.PostAsync<Type>(ENDPOINT_PREFIX, payload, onSuccess, onError);
        }

        /// <summary>
        /// Updates a type.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="action">The update action to be performed on the type.</param>
        /// <returns>Type</returns>
        public IEnumerator UpdateTypeAsync(Type type, UpdateAction action, Action<Response<Type>> onSuccess, Action<Response<Type>> onError)
        {
            return UpdateTypeByIdAsync(type.Id, type.Version, new List<UpdateAction> { action }, onSuccess, onError);
        }

        /// <summary>
        /// Updates a type.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="actions">The update actions to be performed on the type.</param>
        /// <returns>Type</returns>
        public IEnumerator UpdateTypeAsync(Type type, List<UpdateAction> actions, Action<Response<Type>> onSuccess, Action<Response<Type>> onError)
        {
            return UpdateTypeByIdAsync(type.Id, type.Version, actions, onSuccess, onError);
        }

        /// <summary>
        /// Updates a type.
        /// </summary>
        /// <param name="typeId">Type ID</param>
        /// <param name="version">The expected version of the type on which the changes should be applied.</param>
        /// <param name="action">The update action to be performed on the type.</param>
        /// <returns>Type</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-types.html#update-type-by-id"/>
        public IEnumerator UpdateTypeByIdAsync(string typeId, int version, UpdateAction action, Action<Response<Type>> onSuccess, Action<Response<Type>> onError)
        {
            return UpdateTypeByIdAsync(typeId, version, new List<UpdateAction> { action }, onSuccess, onError);
        }

        /// <summary>
        /// Updates a type.
        /// </summary>
        /// <param name="typeId">Type ID</param>
        /// <param name="version">The expected version of the type on which the changes should be applied.</param>
        /// <param name="actions">The list of update actions to be performed on the type.</param>
        /// <returns>Type</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-types.html#update-type-by-id"/>
        public IEnumerator UpdateTypeByIdAsync(string typeId, int version, List<UpdateAction> actions, Action<Response<Type>> onSuccess, Action<Response<Type>> onError)
        {
            if (string.IsNullOrWhiteSpace(typeId))
            {
                throw new ArgumentException("typeId is required");
            }

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", typeId);
            return UpdateTypeAsync(endpoint, version, actions, onSuccess, onError);
        }

        /// <summary>
        /// Updates a type.
        /// </summary>
        /// <param name="key">Type key</param>
        /// <param name="version">The expected version of the type on which the changes should be applied.</param>
        /// <param name="action">The update action to be performed on the type.</param>
        /// <returns>Type</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-types.html#update-type-by-id"/>
        public IEnumerator UpdateTypeByKeyAsync(string key, int version, UpdateAction action, Action<Response<Type>> onSuccess, Action<Response<Type>> onError)
        {
            return UpdateTypeByKeyAsync(key, version, new List<UpdateAction> { action }, onSuccess, onError);
        }

        /// <summary>
        /// Updates a type.
        /// </summary>
        /// <param name="key">Type key</param>
        /// <param name="version">The expected version of the type on which the changes should be applied.</param>
        /// <param name="actions">The list of update actions to be performed on the type.</param>
        /// <returns>Type</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-types.html#update-type-by-id"/>
        public IEnumerator UpdateTypeByKeyAsync(string key, int version, List<UpdateAction> actions, Action<Response<Type>> onSuccess, Action<Response<Type>> onError)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("key is required");
            }

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/key=", key);
            return UpdateTypeAsync(endpoint, version, actions, onSuccess, onError);
        }

        /// <summary>
        /// Private worker method for UpdateProductByIdAsync and UpdateProductByKeyAsync.
        /// </summary>
        /// <param name="endpoint">Request endpoint</param>
        /// <param name="version">The expected version of the type on which the changes should be applied.</param>
        /// <param name="actions">The list of update actions to apply to the type.</param>
        /// <returns>Type</returns>
        private IEnumerator UpdateTypeAsync(string endpoint, int version, List<UpdateAction> actions, Action<Response<Type>> onSuccess, Action<Response<Type>> onError)
        {
            if (version < 1)
            {
                throw new ArgumentException("version is required");
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

            return _client.PostAsync<Type>(endpoint, data.ToString(), onSuccess, onError);
        }

        /// <summary>
        /// Deletes a type.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Response of type JObject</returns>
        public IEnumerator DeleteTypeAsync(Type type, Action<Response<JObject>> onSuccess, Action<Response<JObject>> onError)
        {
            return DeleteTypeByIdAsync(type.Id, type.Version, onSuccess, onError);
        }

        /// <summary>
        /// Deletes a type.
        /// </summary>
        /// <param name="typeId">Type ID</param>
        /// <param name="version">Type version</param>
        /// <returns>JObject</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-types.html#delete-type-by-id"/>
        public IEnumerator DeleteTypeByIdAsync(string typeId, int version, Action<Response<JObject>> onSuccess, Action<Response<JObject>> onError)
        {
            if (string.IsNullOrWhiteSpace(typeId))
            {
                throw new ArgumentException("typeId is required");
            }

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", typeId);
            return DeleteTypeAsync(endpoint, version, onSuccess, onError);
        }

        /// <summary>
        /// Deletes a type.
        /// </summary>
        /// <param name="key">Type key</param>
        /// <param name="version">Type version</param>
        /// <returns>JObject</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-types.html#delete-type-by-key"/>
        public IEnumerator DeleteTypeByKeyAsync(string key, int version, Action<Response<JObject>> onSuccess, Action<Response<JObject>> onError)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("key is required");
            }

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/key=", key);
            return DeleteTypeAsync(endpoint, version, onSuccess, onError);
        }

        /// <summary>
        /// Private worker method for DeleteTypeByIdAsync and DeleteTypeByKeyAsync.
        /// </summary>
        /// <param name="endpoint">Request endpoint</param>
        /// <param name="version">Type version</param>
        /// <returns>JObject</returns>
        private IEnumerator DeleteTypeAsync(string endpoint, int version, Action<Response<JObject>> onSuccess, Action<Response<JObject>> onError)
        {
            if (version < 1)
            {
                throw new ArgumentException("version is required");
            }

            var values = new NameValueCollection
            {
                { "version", version.ToString() }
            };

            return _client.DeleteAsync<JObject>(endpoint, onSuccess, onError, values);
        }

        #endregion
    }
}
