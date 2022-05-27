using ctLite.Common;
using Newtonsoft.Json;

namespace ctLite.ShippingMethods.Tiers
{
    /// <inheritdoc />
    public sealed class CartValueTier : Tier
    {
        [JsonProperty(PropertyName = "minimumCentAmount")]
        public long? MinimumCentAmount { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.ShippingMethods.Tiers.CartValueTier"/> class.
        /// </summary>
        public CartValueTier() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public CartValueTier(dynamic data)
        {
            if (data == null)
            {
                return;
            }

            this.Type = data.type;
            this.Price = new Money(data.price);
            this.MinimumCentAmount = data.minimumCentAmount;
        }
    }
}
