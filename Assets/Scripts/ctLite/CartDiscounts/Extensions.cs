using ctLite.Common;

namespace ctLite.CartDiscounts
{
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the CartDiscountManager.
        /// </summary>
        /// <returns>CartDiscountManager</returns>
        public static CartDiscountManager CartDiscounts(this UnityClient client)
        {
            return new CartDiscountManager(client);
        }
    }
}
