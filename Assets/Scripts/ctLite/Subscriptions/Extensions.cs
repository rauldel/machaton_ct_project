using ctLite.Common;

namespace ctLite.Subscriptions
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the SubscriptionManager.
        /// </summary>
        /// <returns>SubscriptionManager</returns>
        public static SubscriptionManager Subscriptions(this UnityClient client)
        {
            return new SubscriptionManager(client);
        }
    }
}
