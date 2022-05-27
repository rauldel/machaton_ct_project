using System.Collections.Generic;

using ctLite.Common;
using ctLite.Types;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ctLite.Carts.UpdateActions
{
    /// <summary>
    /// This action sets, overwrites or removes the custom type and fields for an existing CustomLineItem.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-carts.html#set-customlineitem-custom-type"/>
    public class SetCustomLineItemCustomTypeAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// ResourceIdentifier to a Type
        /// </summary>
        /// <remarks>
        /// If set, the custom type is set to this new value. If absent, the custom type and any existing CustomFields are removed at the same time.
        /// </remarks>
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
        /// <see cref="T:ctLite.Carts.UpdateActions.SetCustomLineItemCustomTypeAction"/> class.
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
