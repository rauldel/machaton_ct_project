using System;
using System.Collections.Generic;
using System.Text;

namespace ctLite.GeoLocation
{
    /// <summary>
    /// Base interface for all geolocation objects 
    /// </summary>
    public interface IGeoLocationObject
    {
        GeoLocationTypeEnum Type
        {
            get;
        }
    }
}
