using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.ProductTypes.UpdateActions
{
    /// <summary>
    /// Remove an attribute definition.
    /// </summary>
    /// <remarks>
    /// This removal also deletes all corresponding attributes on all Products with this product type. The removal of the attributes is eventually consistent.
    /// </remarks>
    /// <see href="https://dev.commercetools.com/http-api-projects-productTypes.html#remove-attributedefinition"/>
    public class RemoveAttributeDefinitionAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// The name of the attribute to remove.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:ctLite.ProductTypes.UpdateActions.RemoveAttributeDefinitionAction"/> class.
        /// </summary>
        public RemoveAttributeDefinitionAction()
        {
            this.Action = "removeAttributeDefinition";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name of the attribute to remove.</param>
        public RemoveAttributeDefinitionAction(string name)
        {
            this.Action = "removeAttributeDefinition";
            this.Name = name;
        }

        #endregion
    }
}
