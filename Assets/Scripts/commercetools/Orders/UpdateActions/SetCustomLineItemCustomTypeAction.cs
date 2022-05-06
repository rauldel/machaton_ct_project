using myCT.Common;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace myCT.Orders.UpdateActions
{
    /// <summary>
    /// This action sets, overwrites or removes the existing custom type and fields for an existing order CustomLineItem.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-orders.html#set-customlineitem-custom-type"/>
    public class SetCustomLineItemCustomTypeAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public ResourceIdentifier Type { get; set; }

        /// <summary>
        /// Custom line item ID
        /// </summary>
        [JsonProperty(PropertyName = "customLineItemId")]
        public string CustomLineItemId { get; set; }

        /// <summary>
        /// A valid JSON object, based on the FieldDefinitions of the Type 
        /// </summary>
        /// <remarks>
        /// If set, the custom fields are set to this new value.
        /// </remarks>
        [JsonProperty(PropertyName = "fields")]
        public JObject Fields { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:myCT.Orders.UpdateActions.SetCustomLineItemCustomTypeAction"/> class.
        /// </summary>
        public SetCustomLineItemCustomTypeAction()
        {
            this.Action = "setCustomLineItemCustomType";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="customLineItemId">Custom line item ID</param>
        public SetCustomLineItemCustomTypeAction(string customLineItemId)
        {
            this.Action = "setCustomLineItemCustomType";
            this.CustomLineItemId = customLineItemId;
        }

        #endregion
    }
}
