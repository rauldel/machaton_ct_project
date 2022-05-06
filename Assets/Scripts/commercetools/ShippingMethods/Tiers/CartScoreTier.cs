using myCT.Common;
using Newtonsoft.Json;

namespace myCT.ShippingMethods.Tiers
{
    /// <inheritdoc />
    public sealed class CartScoreTier : Tier
    {
        [JsonProperty(PropertyName = "score")]
        public int Score { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.ShippingMethods.Tiers.CartScoreTier"/> class.
        /// </summary>
        public CartScoreTier() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public CartScoreTier(dynamic data)
        {
            if (data == null)
            {
                return;
            }

            this.Type = data.type;
            this.Price = new Money(data.price);
            this.Score = data.score;
        }
    }
}
