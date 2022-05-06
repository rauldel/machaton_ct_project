using System.Collections.Generic;

using myCT.CustomFields;

using Newtonsoft.Json;

namespace myCT.Common
{
    /// <summary>
    /// The representation to be sent to the server when creating a new asset.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-types.html#assetdraft"/>
    public class AssetDraft
    {
        #region Properties

        [JsonProperty(PropertyName = "sources")]
        public List<ArraySource> Sources { get; set; }

        [JsonProperty(PropertyName = "name")]
        public LocalizedString Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public LocalizedString Description { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public string Tags { get; set; }

        [JsonProperty(PropertyName = "custom")]
        public CustomFieldsDraft Custom { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Common.AssetDraft"/> class.
        /// </summary>
        public AssetDraft() {}

        /// <summary>
        /// Constructor.
        /// </summary>
        public AssetDraft(List<ArraySource> sources)
        {
            this.Sources = sources;
        }

        #endregion
    }
}
