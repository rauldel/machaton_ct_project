using System.Collections.Generic;

using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.TaxCategories
{
    /// <summary>
    /// An implementation of PagedQueryResult that provides access to the results as a List of TaxCategory objects.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api.html#pagedqueryresult"/>
    public class TaxCategoryQueryResult : PagedQueryResult
    {
        #region Properties

        [JsonProperty(PropertyName = "results")]
        public List<TaxCategory> Results { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.TaxCategories.TaxCategoryQueryResult"/> class.
        /// </summary>
        public TaxCategoryQueryResult() : base() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public TaxCategoryQueryResult(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.Results = Helper.GetListFromJsonArray<TaxCategory>(data.results);
        }

        #endregion
    }
}
