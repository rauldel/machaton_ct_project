using ctLite.Common;
using Newtonsoft.Json;

namespace ctLite.DiscountCodes.UpdateActions
{
    public class SetDescriptionAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "description")]
        public LocalizedString Description { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public SetDescriptionAction()
        {
            this.Action = "setDescription";
        }

        #endregion
    }
}
