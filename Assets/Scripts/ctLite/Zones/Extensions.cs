using ctLite.Common;

namespace ctLite.Zones
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the ZoneManager.
        /// </summary>
        /// <returns>ZoneManager</returns>
        public static ZoneManager Zones(this UnityClient client)
        {
            return new ZoneManager(client);
        }
    }
}
