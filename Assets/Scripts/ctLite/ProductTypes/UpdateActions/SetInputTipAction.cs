using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.ProductTypes.UpdateActions
{
    /// <summary>
    /// Allows to set additional information about the specified attribute that aids content managers when setting product details.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-productTypes.html#set-attributedefinition-inputtip"/>
    public class SetInputTipAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// The name of the attribute definition to update.
        /// </summary>
        [JsonProperty(PropertyName = "attributeName")]
        public string AttributeName { get; set; }

        /// <summary>
        /// Input Tip
        /// </summary>
        [JsonProperty(PropertyName = "inputTip")]
        public LocalizedString InputTip { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.ProductTypes.UpdateActions.SetInputTipAction"/> class.
        /// </summary>
        public SetInputTipAction()
        {
            this.Action = "setInputTip";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="attributeName">The name of the attribute definition to update.</param>
        public SetInputTipAction(string attributeName)
        {
            this.Action = "setInputTip";
            this.AttributeName = attributeName;
        }

        #endregion
    }
}
