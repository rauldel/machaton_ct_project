using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Zones.UpdateActions
{
    /// <summary>
    /// AddLocationAction
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-zones.html#add-location"/>
    public class AddLocationAction : UpdateAction
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
        /// Initializes a new instance of the <see cref="T:myCT.Zones.UpdateActions.AddLocationAction"/> class.
        /// </summary>
        public AddLocationAction()
        {
            this.Action = "addLocation";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="location">Location</param>
        public AddLocationAction(Location location)
        {
            this.Action = "addLocation";
            this.Location = location;
        }

        #endregion
    }
}
