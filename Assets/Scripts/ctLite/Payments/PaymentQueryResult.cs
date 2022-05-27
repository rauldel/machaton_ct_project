using System.Collections.Generic;

using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Payments
{
    /// <summary>
    /// An implementation of PagedQueryResult that provides access to the results as a List of Payment objects.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api.html#pagedqueryresult"/>
    public class PaymentQueryResult : PagedQueryResult
    {
        #region Properties

        /// <summary>
        /// Results
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public List<Payment> Results { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Payments.PaymentQueryResult"/> class.
        /// </summary>
        public PaymentQueryResult() : base() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public PaymentQueryResult(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.Results = Helper.GetListFromJsonArray<Payment>(data.results);
        }

        #endregion
    }
}
