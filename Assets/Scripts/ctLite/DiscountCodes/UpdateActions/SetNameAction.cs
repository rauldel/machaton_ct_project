using ctLite.Common;
using Newtonsoft.Json;

namespace ctLite.DiscountCodes.UpdateActions
{
    public class SetNameAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "name")]
        public LocalizedString Name { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public SetNameAction()
        {
            this.Action = "setName";
        }

        #endregion
    }
}
