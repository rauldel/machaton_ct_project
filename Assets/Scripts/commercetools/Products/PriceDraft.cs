using System;

using myCT.Common;
using myCT.CustomFields;

using Newtonsoft.Json;

namespace myCT.Products
{
    /// <summary>
    /// The representation to be sent to the server when creating a new price.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-products.html#pricedraft"/>
    public class PriceDraft
    {
        #region Properties

        [JsonProperty(PropertyName = "value")]
        public Money Value { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "customerGroup")]
        public Reference CustomerGroup { get; set; }

        [JsonProperty(PropertyName = "channel")]
        public Reference Channel { get; set; }

        [JsonProperty(PropertyName = "validFrom")]
        public DateTime? ValidFrom { get; set; }

        [JsonProperty(PropertyName = "validUntil")]
        public DateTime? ValidUntil { get; set; }

        [JsonProperty(PropertyName = "custom")]
        public CustomFieldsDraft Custom { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Products.PriceDraft"/> class.
        /// </summary>
        public PriceDraft() {}

        /// <summary>
        /// Constructor.
        /// </summary>
        public PriceDraft(Money value)
        {
            this.Value = value;
        }

        #endregion
    }
}