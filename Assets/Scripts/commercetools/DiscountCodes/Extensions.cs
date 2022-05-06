using myCT.CartDiscounts;
using myCT.Common;

namespace myCT.DiscountCodes
{
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the CartDiscountManager.
        /// </summary>
        /// <returns>CartDiscountManager</returns>
        public static DiscountCodeManager DiscountCodes(this IClient client)
        {
            return new DiscountCodeManager(client);
        }
    }
}
