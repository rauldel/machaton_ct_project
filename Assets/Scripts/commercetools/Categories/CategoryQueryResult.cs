using System.Collections.Generic;

using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Categories
{
    /// <summary>
    /// An implementation of PagedQueryResult that provides access to the results as a List of Category objects.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api.html#pagedqueryresult"/>
    public class CategoryQueryResult : PagedQueryResult
    {
        #region Properties

        /// <summary>
        /// Results
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public List<Category> Results { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Categories.CategoryQueryResult"/> class.
        /// </summary>
        public CategoryQueryResult() : base() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public CategoryQueryResult(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.Results = Helper.GetListFromJsonArray<Category>(data.results);
        }

        #endregion
    }
}
