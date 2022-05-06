using myCT.Common;
using myCT.CustomFields;
using myCT.GeoLocation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace myCT.Channels
{
    /// <summary>
    /// API representation for creating a new channel.
    /// </summary>
    /// <see href="https://docs.commercetools.com/http-api-projects-channels.html#channeldraft"/>
    public class ChannelDraft
    {
        #region Properties
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "roles")]        
        public List<ChannelRoleEnum> Roles { get; set; }

        [JsonProperty(PropertyName = "name")]
        public LocalizedString Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public LocalizedString Description { get; set; }

        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        [JsonProperty(PropertyName = "custom")]
        public CustomFieldsDraft Custom { get; set; }

        [JsonProperty(PropertyName = "geoLocation")]
        public IGeoLocationObject GeoLocation { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Channels.ChannelDraft"/> class.
        /// </summary>
        public ChannelDraft() {}

        /// <summary>
        ///Constructor.
        /// </summary>
        /// <param name="sku">SKU</param>
        public ChannelDraft(string key)
        {
            this.Key = key;           
        }
        #endregion
    }
}
