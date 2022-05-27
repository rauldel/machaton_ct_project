using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.ShippingMethods.UpdateActions
{
    /// <summary>
    /// Add Zone
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-shippingMethods.html#add-zone"/>
    public class AddZoneAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Reference to a Zone
        /// </summary>
        [JsonProperty(PropertyName = "zone")]
        public Reference Zone { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.ShippingMethods.UpdateActions.AddZoneAction"/> class.
        /// </summary>
        public AddZoneAction()
        {
            this.Action = "addZone";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="zone">Reference to a Zone</param>
        public AddZoneAction(Reference zone)
        {
            this.Action = "addZone";
            this.Zone = zone;
        }

        #endregion
    }
}
