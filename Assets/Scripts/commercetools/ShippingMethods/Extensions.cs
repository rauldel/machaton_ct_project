using myCT.Common;

namespace myCT.ShippingMethods
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the ShippingMethodManager.
        /// </summary>
        /// <returns>ShippingMethodManager</returns>
        public static ShippingMethodManager ShippingMethods(this IClient client)
        {
            return new ShippingMethodManager(client);
        }
    }
}
