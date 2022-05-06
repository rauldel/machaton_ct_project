using System.Collections.Generic;
using myCT.Common;
using Newtonsoft.Json;

namespace myCT.DiscountCodes
{
    public class DiscountCodeQueryResult : PagedQueryResult
    {
        #region Properties

        /// <summary>
        /// Results
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public List<DiscountCode> Results { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public DiscountCodeQueryResult() : base() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public DiscountCodeQueryResult(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.Results = Helper.GetListFromJsonArray<DiscountCode>(data.results);
        }

        #endregion
    }
}
