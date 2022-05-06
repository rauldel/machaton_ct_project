using System.Collections.Generic;

using myCT.Common;
using myCT.ProductProjectionSearch;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace myCT.ProductProjections
{
    /// <summary>
    /// An implementation of PagedQueryResult that provides access to the results as a List of ProductProjection objects.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api.html#paged-query-result"/>
    public class ProductProjectionQueryResult : PagedQueryResult
    {
        #region Properties

        [JsonProperty(PropertyName = "results")]
        public List<ProductProjection> Results { get; private set; }

        [JsonProperty(PropertyName = "facets")]
        public Dictionary<string, Facet> Facets { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.ProductProjections.ProductProjectionQueryResult"/> class.
        /// </summary>
        public ProductProjectionQueryResult() : base() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public ProductProjectionQueryResult(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.Results = Helper.GetListFromJsonArray<ProductProjection>(data.results);
            this.Facets = new Dictionary<string, Facet>();

            if (data.facets != null)
            {
                foreach (JProperty facet in data.facets)
                {
                    Facet f = FacetFactory.Create(facet.Value);
                    this.Facets.Add(facet.Name, f);
                }
            }
        }

        #endregion
    }
}
