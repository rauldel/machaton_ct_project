using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Orders.UpdateActions
{
    /// <summary>
    /// This action removes a payment from the PaymentInfo.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-orders.html#remove-payment"/>
    public class RemovePaymentAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Reference to a Payment
        /// </summary>
        [JsonProperty(PropertyName = "payment")]
        public Reference Payment { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Orders.UpdateActions.RemovePaymentAction"/> class.
        /// </summary>
        public RemovePaymentAction()
        {
            this.Action = "removePayment";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="payment">Reference to a Payment</param>
        public RemovePaymentAction(Reference payment)
        {
            this.Action = "removePayment";
            this.Payment = payment;
        }

        #endregion
    }
}
