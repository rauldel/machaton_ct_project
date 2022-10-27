using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using ctLite.Common;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ctLite.TaxCategories
{
    /// <summary>
    /// Provides access to the functions in the TaxCategories section of the API. 
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-taxCategories.html"/>
    public class TaxCategoryManager
    {
        #region Constants

        private const string ENDPOINT_PREFIX = "/tax-categories";

        #endregion

        #region Member Variables

        private readonly UnityClient _client;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">Client</param>
        public TaxCategoryManager(UnityClient client)
        {
            _client = client;
        }

        #endregion

        #region API Methods

        /// <summary>
        /// Gets a TaxCategory by its ID.
        /// </summary>
        /// <param name="taxCategoryId">TaxCategory ID</param>
        /// <returns>TaxCategory</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-taxCategories.html#get-taxcategory-by-id"/>
        public IEnumerator GetTaxCategoryByIdAsync(string taxCategoryId, Action<Response<TaxCategory>> onSuccess, Action<Response<TaxCategory>> onError)
        {
            if (string.IsNullOrWhiteSpace(taxCategoryId))
            {
                throw new ArgumentException("taxCategoryId is required");
            }

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", taxCategoryId);
            return _client.GetAsync<TaxCategory>(endpoint, onSuccess, onError);
        }

        /// <summary>
        /// Queries for TaxCategories.
        /// </summary>
        /// <param name="where">Where</param>
        /// <param name="sort">Sort</param>
        /// <param name="limit">Limit</param>
        /// <param name="offset">Offset</param>
        /// <returns>TaxCategoryQueryResult</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-taxCategories.html#query-taxcategories"/>
        public IEnumerator QueryTaxCategoriesAsync(Action<Response<TaxCategoryQueryResult>> onSuccess, Action<Response<TaxCategoryQueryResult>> onError, string where = null, string sort = null, int limit = -1, int offset = -1)
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

            return _client.GetAsync<TaxCategoryQueryResult>(ENDPOINT_PREFIX, onSuccess, onError, values);
        }

        /// <summary>
        /// Creates a new tax category.
        /// </summary>
        /// <param name="taxCategoryDraft">TaxCategoryDraft</param>
        /// <returns>TaxCategory</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-taxCategories.html#create-taxcategory"/>
        public IEnumerator CreateTaxCategoryAsync(TaxCategoryDraft taxCategoryDraft, Action<Response<TaxCategory>> onSuccess, Action<Response<TaxCategory>> onError)
        {
            if (string.IsNullOrWhiteSpace(taxCategoryDraft.Name))
            {
                throw new ArgumentException("Name is required");
            }

            string payload = JsonConvert.SerializeObject(taxCategoryDraft, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return _client.PostAsync<TaxCategory>(ENDPOINT_PREFIX, payload, onSuccess, onError);
        }

        /// <summary>
        /// Updates a tax category.
        /// </summary>
        /// <param name="taxCategory">Tax category</param>
        /// <param name="action">The update action to be performed on the tax category.</param>
        /// <returns>TaxCategory</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-taxCategories.html#update-taxcategory"/>
        public IEnumerator UpdateTaxCategoryAsync(TaxCategory taxCategory, UpdateAction action, Action<Response<TaxCategory>> onSuccess, Action<Response<TaxCategory>> onError)
        {
            return UpdateTaxCategoryAsync(taxCategory.Id, taxCategory.Version, new List<UpdateAction> { action }, onSuccess, onError);
        }

        /// <summary>
        /// Updates a tax category.
        /// </summary>
        /// <param name="taxCategory">Tax category</param>
        /// <param name="actions">The list of update actions to be performed on the tax category.</param>
        /// <returns>TaxCategory</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-taxCategories.html#update-taxcategory"/>
        public IEnumerator UpdateTaxCategoryAsync(TaxCategory taxCategory, List<UpdateAction> actions, Action<Response<TaxCategory>> onSuccess, Action<Response<TaxCategory>> onError)
        {
            return UpdateTaxCategoryAsync(taxCategory.Id, taxCategory.Version, actions, onSuccess, onError);
        }

        /// <summary>
        /// Updates a tax category.
        /// </summary>
        /// <param name="taxCategoryId">ID of the tax category</param>
        /// <param name="version">The expected version of the tax category on which the changes should be applied.</param>
        /// <param name="action">The update action to be performed on the tax category.</param>
        /// <returns>TaxCategory</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-taxCategories.html#update-taxcategory"/>
        public IEnumerator UpdateTaxCategoryAsync(string taxCategoryId, int version, UpdateAction action, Action<Response<TaxCategory>> onSuccess, Action<Response<TaxCategory>> onError)
        {
            return UpdateTaxCategoryAsync(taxCategoryId, version, new List<UpdateAction> { action }, onSuccess, onError);
        }

        /// <summary>
        /// Updates a tax category.
        /// </summary>
        /// <param name="taxCategoryId">ID of the tax category</param>
        /// <param name="version">The expected version of the tax category on which the changes should be applied.</param>
        /// <param name="actions">The list of update actions to be performed on the tax category.</param>
        /// <returns>TaxCategory</returns>
        /// <see href="https://dev.commercetools.com/http-api-projects-taxCategories.html#update-taxcategory"/>
        public IEnumerator UpdateTaxCategoryAsync(string taxCategoryId, int version, List<UpdateAction> actions, Action<Response<TaxCategory>> onSuccess, Action<Response<TaxCategory>> onError)
        {
            if (string.IsNullOrWhiteSpace(taxCategoryId))
            {
                throw new ArgumentException("Tax Category ID is required");
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

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", taxCategoryId);
            return _client.PostAsync<TaxCategory>(endpoint, data.ToString(), onSuccess, onError);
        }

        /// <summary>
        /// Removes a tax category.
        /// </summary>
        /// <param name="taxCategory">Tax category</param>
        /// <see href="https://dev.commercetools.com/http-api-projects-taxCategories.html#delete-taxcategory"/>
        public IEnumerator DeleteTaxCategoryAsync(TaxCategory taxCategory, Action<Response<JObject>> onSuccess, Action<Response<JObject>> onError)
        {
            return DeleteTaxCategoryAsync(taxCategory.Id, taxCategory.Version, onSuccess, onError);
        }

        /// <summary>
        /// Removes a tax category.
        /// </summary>
        /// <param name="taxCategoryId">Tax category ID</param>
        /// <param name="version">Tax category version</param>
        /// <see href="https://dev.commercetools.com/http-api-projects-taxCategories.html#delete-taxcategory"/>
        public IEnumerator DeleteTaxCategoryAsync(string taxCategoryId, int version, Action<Response<JObject>> onSuccess, Action<Response<JObject>> onError)
        {
            if (string.IsNullOrWhiteSpace(taxCategoryId))
            {
                throw new ArgumentException("Tax Category ID is required");
            }

            if (version < 1)
            {
                throw new ArgumentException("Version is required");
            }

            var values = new NameValueCollection
            {
                { "version", version.ToString() }
            };

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", taxCategoryId);
            return _client.DeleteAsync<JObject>(endpoint, onSuccess, onError, values);
        }

        #endregion
    }
}
