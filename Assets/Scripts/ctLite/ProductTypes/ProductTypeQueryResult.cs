using System.Collections.Generic;

using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.ProductTypes
{
    /// <summary>
    /// An implementation of PagedQueryResult that provides access to the results as a List of ProductType objects.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api.html#pagedqueryresult"/>
    public class ProductTypeQueryResult : PagedQueryResult
    {
        #region Properties

        /// <summary>
        /// Results
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public List<ProductType> Results { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.ProductTypes.ProductTypeQueryResult"/> class.
        /// </summary>
        public ProductTypeQueryResult() : base() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public ProductTypeQueryResult(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.Results = Helper.GetListFromJsonArray<ProductType>(data.results);
        }

        #endregion
    }
}
