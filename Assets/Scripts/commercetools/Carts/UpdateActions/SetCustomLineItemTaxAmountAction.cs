using myCT.Common;
using Newtonsoft.Json;

namespace myCT.Carts.UpdateActions
{
    /// <summary>
    /// A custom line item tax amount can be set if the cart has the ExternalAmount TaxMode.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-carts.html#set-customlineitem-taxamount"/>
    public class SetCustomLineItemTaxAmountAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// CustomLineItemId
        /// </summary>
        [JsonProperty(PropertyName = "customLineItemId")]
        public string CustomLineItemId  { get; set; }

        /// <summary>
        /// An external tax amount can be set if the cart has the ExternalAmount TaxMode.
        /// </summary>
        [JsonProperty(PropertyName = "externalTaxAmount")]
        public ExternalTaxAmountDraft ExternalTaxAmount { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:myCT.Carts.UpdateActions.SetCustomLineItemTaxAmountAction"/> class.
        /// </summary>
        public SetCustomLineItemTaxAmountAction()
        {
            this.Action = "setCustomLineItemTaxAmount";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="customLineItemId">CustomLineItemId</param>
        public SetCustomLineItemTaxAmountAction(string customLineItemId)
        {
            this.Action = "setCustomLineItemTaxAmount";
            this.CustomLineItemId = customLineItemId;
        }

        #endregion
    }
}
