using System.Collections.Generic;

using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Products
{
    /// <summary>
    /// An implementation of PagedQueryResult that provides access to the results as a List of Product objects.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api.html#pagedqueryresult"/>
    public class ProductQueryResult : PagedQueryResult
    {
        #region Properties

        /// <summary>
        /// Results
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public List<Product> Results { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Products.ProductQueryResult"/> class.
        /// </summary>
        public ProductQueryResult() : base() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public ProductQueryResult(dynamic data = null)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.Offset = data.offset;
            this.Count = data.count;
            this.Total = data.total;
            this.Results = Helper.GetListFromJsonArray<Product>(data.results);
        }

        #endregion
    }
}
