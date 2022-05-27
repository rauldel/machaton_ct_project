using System;
using System.Collections.Generic;
using ctLite.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ctLite.CartDiscounts
{
    public abstract class CartDiscountValue
    {
        #region Properties
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CartDiscountType? Type { get; private set; }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.CartDiscounts.CartDiscountValue"/> class.
        /// </summary>
        public CartDiscountValue() {}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="type">Type.</param>
        protected CartDiscountValue(CartDiscountType type)
        {
            Type = type;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">Data.</param>
        protected CartDiscountValue(dynamic data)
        {
            if (data == null)
            {
                return;
            }

            CartDiscountType discountType;
            string discountTypeStr = (data.type != null ? data.type.ToString() : string.Empty);
            this.Type = Enum.TryParse(discountTypeStr, true, out discountType) ? (CartDiscountType?)discountType : null;
        }
        #endregion
    }
}
