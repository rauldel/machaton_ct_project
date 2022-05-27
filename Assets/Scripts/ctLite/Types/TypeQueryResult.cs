using System.Collections.Generic;

using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Types
{
    /// <summary>
    /// An implementation of PagedQueryResult that provides access to the results as a List of Type objects.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api.html#pagedqueryresult"/>
    public class TypeQueryResult : PagedQueryResult
    {
        #region Properties

        /// <summary>
        /// Results
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public List<Type> Results { get; set; }

        #endregion

        #region Constructors

        public TypeQueryResult() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public TypeQueryResult(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.Results = Helper.GetListFromJsonArray<Type>(data.results);
        }

        #endregion
    }
}
