﻿using myCT.Common;

namespace myCT.CartDiscounts
{
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the CartDiscountManager.
        /// </summary>
        /// <returns>CartDiscountManager</returns>
        public static CartDiscountManager CartDiscounts(this IClient client)
        {
            return new CartDiscountManager(client);
        }
    }
}
