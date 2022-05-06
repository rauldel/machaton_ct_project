using myCT.Common;
using Newtonsoft.Json;

namespace myCT.DiscountCodes.UpdateActions
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
