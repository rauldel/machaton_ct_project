﻿using myCT.Common;
using Newtonsoft.Json;

namespace myCT.Carts.UpdateActions
{
    /// <summary>
    /// A line item tax amount can be set if the cart has the ExternalAmount TaxMode.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-carts.html#set-lineitem-taxamount"/>
    public class SetLineItemTaxAmountAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Id of an existing LineItem.
        /// </summary>
        [JsonProperty(PropertyName = "lineItemId")]
        public string LineItemId { get; set; }

        /// <summary>
        /// An external tax amount can be set if the cart has the ExternalAmount TaxMode.
        /// </summary>
        [JsonProperty(PropertyName = "externalTaxAmount")]
        public ExternalTaxAmountDraft ExternalTaxAmount { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Carts.UpdateActions.SetLineItemTaxAmountAction"/> class.
        /// </summary>
        public SetLineItemTaxAmountAction()
        {
            this.Action = "setLineItemTaxAmount";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="lineItemId">Id of an existing Product.</param>
        public SetLineItemTaxAmountAction(string lineItemId)
        {
            this.Action = "setLineItemTaxAmount";
            this.LineItemId = lineItemId;
        }

        #endregion
    }
}
