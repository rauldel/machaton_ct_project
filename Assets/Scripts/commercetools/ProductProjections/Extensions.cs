using myCT.Common;

namespace myCT.ProductProjections
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the ProductProjectionManager.
        /// </summary>
        /// <returns>ProductProjectionManager</returns>
        public static ProductProjectionManager ProductProjections(this IClient client)
        {
            return new ProductProjectionManager(client);
        }
    }
}
