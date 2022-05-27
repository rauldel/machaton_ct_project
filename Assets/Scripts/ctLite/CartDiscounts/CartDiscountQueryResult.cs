using System.Collections.Generic;
using ctLite.Common;
using Newtonsoft.Json;

namespace ctLite.CartDiscounts
{
    public class CartDiscountQueryResult: PagedQueryResult
    {
        #region Properties

        /// <summary>
        /// Results
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public List<CartDiscount> Results { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.CartDiscounts.CartDiscountQueryResult"/> class.
        /// </summary>
        public CartDiscountQueryResult() : base() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public CartDiscountQueryResult(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.Results = Helper.GetListFromJsonArray<CartDiscount>(data.results);
        }

        #endregion
    }
}
