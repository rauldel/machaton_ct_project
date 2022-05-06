using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Zones.UpdateActions
{
    /// <summary>
    /// RemoveLocationAction
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-zones.html#remove-location"/>
    public class RemoveLocationAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Location
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Zones.UpdateActions.RemoveLocationAction"/> class.
        /// </summary>
        public RemoveLocationAction()
        {
            this.Action = "removeLocation";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="location">Location</param>
        public RemoveLocationAction(Location location)
        {
            this.Action = "removeLocation";
            this.Location = location;
        }

        #endregion
    }
}
