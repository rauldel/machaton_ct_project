using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Carts.UpdateActions
{
    /// <summary>
    /// A line item tax rate can be set if the cart has the External TaxMode.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-carts.html#set-lineitem-taxrate"/>
    public class SetLineItemTaxRateAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Id of an existing LineItem.
        /// </summary>
        [JsonProperty(PropertyName = "lineItemId")]
        public string LineItemId { get; set; }

        /// <summary>
        /// An external tax rate can be set if the cart has the External TaxMode.
        /// </summary>
        [JsonProperty(PropertyName = "externalTaxRate")]
        public ExternalTaxRateDraft ExternalTaxRate { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Carts.UpdateActions.SetLineItemTaxRateAction"/> class.
        /// </summary>
        public SetLineItemTaxRateAction()
        {
            this.Action = "setLineItemTaxRate";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="lineItemId">Id of an existing Product.</param>
        public SetLineItemTaxRateAction(string lineItemId)
        {
            this.Action = "setLineItemTaxRate";
            this.LineItemId = lineItemId;
        }

        #endregion
    }
}
