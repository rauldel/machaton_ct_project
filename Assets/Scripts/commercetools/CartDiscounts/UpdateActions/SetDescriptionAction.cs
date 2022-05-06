using myCT.Common;
using Newtonsoft.Json;

namespace myCT.CartDiscounts.UpdateActions
{
    public class SetDescriptionAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "description")]
        public LocalizedString Description { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.CartDiscounts.UpdateActions.SetDescriptionAction"/> class.
        /// </summary>
        public SetDescriptionAction()
        {
            this.Action = "setDescription";
        }

        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="description">Description.</param>
        public SetDescriptionAction(LocalizedString description)
        {
            this.Action = "setDescription";
            this.Description = description;
        }

        #endregion
    }
}
