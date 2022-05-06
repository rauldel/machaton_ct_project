using myCT.Common;

using Newtonsoft.Json;

namespace myCT.ProductTypes.UpdateActions
{
    /// <summary>
    /// Add Attribute Definition
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-productTypes.html#add-attributedefinition"/>
    public class AddAttributeDefinitionAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// AttributeDefinitionDraft
        /// </summary>
        [JsonProperty(PropertyName = "attribute")]
        public AttributeDefinitionDraft Attribute { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:myCT.ProductTypes.UpdateActions.AddAttributeDefinitionAction"/> class.
        /// </summary>
        public AddAttributeDefinitionAction()
        {
            this.Action = "addAttributeDefinition";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="attribute">AttributeDefinitionDraft</param>
        public AddAttributeDefinitionAction(AttributeDefinitionDraft attribute)
        {
            this.Action = "addAttributeDefinition";
            this.Attribute = attribute;
        }

        #endregion
    }
}
