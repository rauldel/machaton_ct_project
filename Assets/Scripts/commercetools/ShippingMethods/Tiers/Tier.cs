using myCT.Common;
using myCT.Common.Converters;
using Newtonsoft.Json;

namespace myCT.ShippingMethods.Tiers
{
    /// <summary>
    /// The representation to be sent to the server when creating a new shipping rate price tier.
    /// </summary>
    /// <see href="https://docs.commercetools.com/http-api-projects-shippingMethods.html#shippingratepricetier"/>
    [JsonConverter(typeof(TierJsonConverter))]
    public abstract class Tier
    {
        #region Properties

        [JsonProperty(PropertyName = "type")]
        public string Type { get; protected set; }

        [JsonProperty(PropertyName = "price")]
        public Money Price { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.ShippingMethods.Tiers.Tier"/> class.
        /// </summary>
        public Tier() {}

        #endregion
    }
}
