using ctLite.Common;

namespace ctLite.Orders
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the OrderManager.
        /// </summary>
        /// <returns>OrderManager</returns>
        public static OrderManager Orders(this UnityClient client)
        {
            return new OrderManager(client);
        }
    }
}
