using System;
using ctLite.Common;
using Newtonsoft.Json;

namespace ctLite.CartDiscounts
{
    public class GiftLineItemCartDiscountValue : CartDiscountValue
    {
        #region Properties

        [JsonProperty(PropertyName = "product")]
        public ResourceIdentifier Product { get; private set; }

        [JsonProperty(PropertyName = "variantId")]
        public int VariantId { get; private set; }

        [JsonProperty(PropertyName = "supplyChannel")]
        public ResourceIdentifier SupplyChannel { get; set; }

        [JsonProperty(PropertyName = "distributionChannel")]
        public ResourceIdentifier DistributionChannel { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.CartDiscounts.GiftLineItemCartDiscountValue"/> class.
        /// </summary>
        public GiftLineItemCartDiscountValue() : base() {}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="product">Product.</param>
        /// <param name="variantId">Variant identifier.</param>
        public GiftLineItemCartDiscountValue(
            ResourceIdentifier product,
            int variantId) : base(CartDiscountType.GiftLineItem)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            Product = product;
            VariantId = variantId;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">Data.</param>
        public GiftLineItemCartDiscountValue(dynamic data) : base((object)data)
        {
            this.Product = new ResourceIdentifier(data.product);
            this.VariantId = data.variantId;
            this.SupplyChannel = new ResourceIdentifier(data.supplyChannel);
            this.DistributionChannel = new ResourceIdentifier(data.distributionChannel);
        }

        #endregion
    }
}
