using System.Collections.Generic;

using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Orders.UpdateActions
{
    /// <summary>
    /// These import of states does not follow any predefined rules and should be only used if no transitions are defined.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-carts.html#add-lineitem"/>
    public class ImportCustomLineItemStateAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Custom line item ID
        /// </summary>
        [JsonProperty(PropertyName = "customLineItemId")]
        public string CustomLineItemId { get; set; }

        /// <summary>
        /// List of item states
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public List<ItemState> State { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:ctLite.Orders.UpdateActions.ImportCustomLineItemStateAction"/> class.
        /// </summary>
        public ImportCustomLineItemStateAction()
        {
            this.Action = "importCustomLineItemState";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="customLineItemId">Custom line item ID</param>
        /// <param name="state">List of item states</param>
        public ImportCustomLineItemStateAction(string customLineItemId, List<ItemState> state)
        {
            this.Action = "importCustomLineItemState";
            this.CustomLineItemId = customLineItemId;
            this.State = state;
        }

        #endregion
    }
}
