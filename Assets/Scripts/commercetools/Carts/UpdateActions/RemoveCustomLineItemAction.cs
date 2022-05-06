using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Carts.UpdateActions
{
    /// <summary>
    /// Removes the custom CustomLineItem from the cart.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-carts.html#remove-customlineitem"/>
    public class RemoveCustomLineItemAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// ID of an existing CustomLineItem in the cart.
        /// </summary>
        [JsonProperty(PropertyName = "customLineItemId")]
        public string CustomLineItemId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Carts.UpdateActions.RemoveCustomLineItemAction"/> class.
        /// </summary>
        public RemoveCustomLineItemAction()
        {
            this.Action = "removeCustomLineItem";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="customLineItemId">ID of an existing CustomLineItem in the cart.</param>
        public RemoveCustomLineItemAction(string customLineItemId)
        {
            this.Action = "removeCustomLineItem";
            this.CustomLineItemId = customLineItemId;
        }

        #endregion
    }
}
