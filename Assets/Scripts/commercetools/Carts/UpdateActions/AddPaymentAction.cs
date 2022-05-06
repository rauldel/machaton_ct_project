using myCT.Common;
using myCT.CustomFields;

using Newtonsoft.Json;

namespace myCT.Carts.UpdateActions
{
    /// <summary>
    /// This action adds a payment to the PaymentInfo.
    /// </summary>
    /// <remarks>
    /// The payment must not be assigned to another Order or active Cart yet.
    /// </remarks>
    /// <see href="https://dev.commercetools.com/http-api-projects-carts.html#add-payment"/>
    public class AddPaymentAction : UpdateAction
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
        /// Initializes a new instance of the <see cref="T:myCT.Carts.UpdateActions.AddPaymentAction"/> class.
        /// </summary>
        public AddPaymentAction()
        {
            this.Action = "addPayment";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="payment">Reference to a Payment.</param>
        public AddPaymentAction(Reference payment)
        {
            this.Action = "addPayment";
            this.Payment = payment;
        }

        #endregion
    }
}
