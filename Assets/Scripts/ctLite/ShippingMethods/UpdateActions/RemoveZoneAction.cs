using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.ShippingMethods.UpdateActions
{
    /// <summary>
    /// Remove Zone
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-shippingMethods.html#remove-zone"/>
    public class RemoveZoneAction : UpdateAction
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
        /// Initializes a new instance of the <see cref="T:ctLite.ShippingMethods.UpdateActions.RemoveZoneAction"/> class.
        /// </summary>
        public RemoveZoneAction()
        {
            this.Action = "removeZone";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="zone">Reference to a Zone</param>
        public RemoveZoneAction(Reference zone)
        {
            this.Action = "removeZone";
            this.Zone = zone;
        }

        #endregion
    }
}
