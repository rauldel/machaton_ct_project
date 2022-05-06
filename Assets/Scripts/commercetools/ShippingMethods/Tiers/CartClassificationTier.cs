using myCT.Common;
using Newtonsoft.Json;

namespace myCT.ShippingMethods.Tiers
{
    /// <inheritdoc />
    public sealed class CartClassificationTier : Tier
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.ShippingMethods.Tiers.CartClassificationTier"/> class.
        /// </summary>
        public CartClassificationTier() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public CartClassificationTier(dynamic data)
        {
            if (data == null)
            {
                return;
            }

            this.Type = data.type;
            this.Price = new Money(data.price);
            this.Value = data.value;
        }
    }
}