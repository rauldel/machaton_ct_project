using myCT.Common;
using myCT.GeoLocation;
using Newtonsoft.Json;

namespace myCT.Channels.UpdateActions
{
    /// <summary>
    /// Set GeoLocation
    /// </summary>
    /// <see href="http://docs.commercetools.com/http-api-projects-channels.html#set-geolocation"/>
    public class SetGeoLocationAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// GeoLocation
        /// </summary>
        [JsonProperty(PropertyName = "geoLocation")]
        public IGeoLocationObject GeoLocation { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Channels.UpdateActions.SetGeoLocationAction"/> class.
        /// </summary>
        public SetGeoLocationAction()
        {
            this.Action = "setGeoLocation";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="geoLocation">GeoLocation</param>
        public SetGeoLocationAction(IGeoLocationObject geoLocation)
        {
            this.Action = "setGeoLocation";
            this.GeoLocation = geoLocation;
        }

        #endregion
    }
}
