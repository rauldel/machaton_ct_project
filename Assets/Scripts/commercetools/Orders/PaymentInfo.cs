using System.Collections.Generic;

using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Orders
{
    /// <summary>
    /// PaymentInfo
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-orders.html#paymentinfo"/>
    public class PaymentInfo
    {
        #region Properties

        [JsonProperty(PropertyName = "payments")]
        public List<Reference> Payments { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Orders.PaymentInfo"/> class.
        /// </summary>
        public PaymentInfo() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public PaymentInfo(dynamic data = null)
        {
            if (data == null)
            {
                return;
            }

            this.Payments = Helper.GetListFromJsonArray<Reference>(data.payments);
        }

        #endregion
    }
}
