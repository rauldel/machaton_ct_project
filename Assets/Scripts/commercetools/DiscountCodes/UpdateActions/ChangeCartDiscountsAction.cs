using System;
using System.Collections.Generic;
using myCT.Common;
using Newtonsoft.Json;

namespace myCT.DiscountCodes.UpdateActions
{
    public class ChangeCartDiscountsAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "cartDiscounts")]
        public List<Reference> CartDiscounts { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:myCT.DiscountCodes.UpdateActions.ChangeCartDiscountsAction"/> class.
        /// </summary>
        public ChangeCartDiscountsAction()
        {
            this.Action = "changeCartDiscounts";
        }

        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="cartDiscounts">Cart discounts.</param>
        public ChangeCartDiscountsAction(List<Reference> cartDiscounts)
        {
            if (cartDiscounts == null || cartDiscounts.Count == 0)
            {
                throw new ArgumentException($"{nameof(cartDiscounts)} cannot be null or empty");
            }

            this.Action = "changeCartDiscounts";
            this.CartDiscounts = cartDiscounts;
        }

        #endregion
    }
}
