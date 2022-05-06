using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Products.UpdateActions
{
    /// <summary>
    /// SetDescriptionAction
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-products.html#set-description"/>
    public class SetDescriptionAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public LocalizedString Description { get; set; }

        /// <summary>
        /// Staged
        /// </summary>
        [JsonProperty(PropertyName = "staged")]
        public bool Staged { get; set; }

        #endregion

        #region Constructors

        public SetDescriptionAction()
        {
            this.Action = "setDescription";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="description">Description</param>
        public SetDescriptionAction(LocalizedString description)
        {
            this.Action = "setDescription";
            this.Description = description;
        }

        #endregion
    }
}
