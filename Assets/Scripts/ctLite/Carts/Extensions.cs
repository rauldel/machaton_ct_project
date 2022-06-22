using ctLite.Common;

namespace ctLite.Carts
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the CartManager.
        /// </summary>
        /// <returns>CartManager</returns>
        public static CartManager Carts(this UnityClient client)
        {
            return new CartManager(client);
        }
    }
}
