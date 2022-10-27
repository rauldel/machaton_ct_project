using ctLite.CartDiscounts;
using ctLite.Common;

namespace ctLite.DiscountCodes
{
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the CartDiscountManager.
        /// </summary>
        /// <returns>CartDiscountManager</returns>
        public static DiscountCodeManager DiscountCodes(this UnityClient client)
        {
            return new DiscountCodeManager(client);
        }
    }
}
