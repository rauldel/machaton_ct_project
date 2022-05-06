using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Categories.UpdateActions
{
    /// <summary>
    /// Set description
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-categories.html#set-description"/>
    public class SetDescriptionAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public LocalizedString Description { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Categories.UpdateActions.SetDescriptionAction"/> class.
        /// </summary>
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
