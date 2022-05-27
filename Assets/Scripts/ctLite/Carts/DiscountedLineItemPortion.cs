using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Carts
{
    /// <summary>
    /// DiscountedLineItemPortion
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-carts.html#discountedlineitemportion"/>
    public class DiscountedLineItemPortion
    {
        #region Properties

        [JsonProperty(PropertyName = "discount")]
        public Reference Discount { get; private set; }

        [JsonProperty(PropertyName = "discountedAmount")]
        public Money DiscountedAmount { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Carts.DiscountedLineItemPortion"/> class.
        /// </summary>
        public DiscountedLineItemPortion() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public DiscountedLineItemPortion(dynamic data)
        {
            if (data == null)
            {
                return;
            }

            this.Discount = new Reference(data.discount);
            this.DiscountedAmount = new Money(data.discountedAmount);
        }

        #endregion
    }
}
