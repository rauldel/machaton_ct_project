﻿using System.Collections.Generic;

using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Carts
{
    /// <summary>
    /// DiscountedLineItemPriceForQuantity
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-carts.html#discountedlineitempriceforquantity"/>
    public class DiscountedLineItemPriceForQuantity
    {
        #region Properties

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; private set; }

        [JsonProperty(PropertyName = "discountedPrice")]
        public DiscountedLineItemPrice DiscountedPrice { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Carts.DiscountedLineItemPriceForQuantity"/> class.
        /// </summary>
        public DiscountedLineItemPriceForQuantity() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public DiscountedLineItemPriceForQuantity(dynamic data)
        {
            if (data == null)
            {
                return;
            }
            this.Quantity = data.quantity;
            this.DiscountedPrice = new DiscountedLineItemPrice(data.discountedPrice);
        }

        #endregion
    }
}
