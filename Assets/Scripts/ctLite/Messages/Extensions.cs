using ctLite.Common;

namespace ctLite.Messages
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the MessageManager.
        /// </summary>
        /// <returns>MessageManager</returns>
        public static MessageManager Messages(this IClient client)
        {
            return new MessageManager(client);
        }
    }
}