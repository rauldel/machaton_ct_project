using ctLite.Common;

namespace ctLite.Payments
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the PaymentManager.
        /// </summary>
        /// <returns>PaymentManager</returns>
        public static PaymentManager Payments(this UnityClient client)
        {
            return new PaymentManager(client);
        }
    }
}
