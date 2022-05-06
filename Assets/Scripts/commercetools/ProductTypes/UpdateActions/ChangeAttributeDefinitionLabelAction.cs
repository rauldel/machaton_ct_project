using myCT.Common;

using Newtonsoft.Json;

namespace myCT.ProductTypes.UpdateActions
{
    /// <summary>
    /// Change Attribute Definition Label
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-productTypes.html#change-attributedefinition-label"/>
    public class ChangeAttributeDefinitionLabelAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// The name of the attribute definition to update.
        /// </summary>
        [JsonProperty(PropertyName = "attributeName")]
        public string AttributeName { get; set; }

        /// <summary>
        /// Label
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public LocalizedString Label { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:myCT.ProductTypes.UpdateActions.ChangeAttributeDefinitionLabelAction"/> class.
        /// </summary>
        public ChangeAttributeDefinitionLabelAction()
        {
            this.Action = "changeLabel";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="attributeName">The name of the attribute definition to update.</param>
        /// <param name="label">Label</param>
        public ChangeAttributeDefinitionLabelAction(string attributeName, LocalizedString label)
        {
            this.Action = "changeLabel";
            this.AttributeName = attributeName;
            this.Label = label;
        }

        #endregion
    }
}
