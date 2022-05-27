using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Carts.UpdateActions
{
    /// <summary>
    /// This action removes a payment from the PaymentInfo.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-carts.html#add-lineitem"/>
    public class RemovePaymentAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Reference to a Payment.
        /// </summary>
        [JsonProperty(PropertyName = "payment")]
        public Reference Payment { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Carts.UpdateActions.RemovePaymentAction"/> class.
        /// </summary>
        public RemovePaymentAction()
        {
            this.Action = "removePayment";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="payment">Reference to a Payment.</param>
        public RemovePaymentAction(Reference payment)
        {
            this.Action = "removePayment";
            this.Payment = payment;
        }

        #endregion
    }
}
