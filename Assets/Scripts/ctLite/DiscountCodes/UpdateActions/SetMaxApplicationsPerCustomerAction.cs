using ctLite.Common;
using Newtonsoft.Json;

namespace ctLite.DiscountCodes.UpdateActions
{
    public class SetMaxApplicationsPerCustomerAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "maxApplicationsPerCustomer")]
        public int? MaxApplicationsPerCustomer { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public SetMaxApplicationsPerCustomerAction()
        {
            this.Action = "setMaxApplicationsPerCustomer";
        }

        #endregion
    }
}
