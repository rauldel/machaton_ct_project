using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Products.UpdateActions
{
    /// <summary>
    /// Change name 
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-products.html#change-name"/>
    public class ChangeNameAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public LocalizedString Name { get; set; }

        /// <summary>
        /// Staged
        /// </summary>
        [JsonProperty(PropertyName = "staged")]
        public bool Staged { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Products.UpdateActions.ChangeNameAction"/> class.
        /// </summary>
        public ChangeNameAction() 
        {
            this.Action = "changeName";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name</param>
        public ChangeNameAction(LocalizedString name)
        {
            this.Action = "changeName";
            this.Name = name;
        }

        #endregion
    }
}
