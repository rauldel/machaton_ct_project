using ctLite.Common;
using Newtonsoft.Json;

namespace ctLite.DiscountCodes.UpdateActions
{
    public class SetMaxApplicationsAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "maxApplications")]
        public int? MaxApplications { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public SetMaxApplicationsAction()
        {
            this.Action = "setMaxApplications";
        }

        #endregion
    }
}
