using ctLite.Common;

namespace ctLite.ProductProjections
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
        public static ProductProjectionManager ProductProjections(this UnityClient client)
        {
            return new ProductProjectionManager(client);
        }
    }
}
