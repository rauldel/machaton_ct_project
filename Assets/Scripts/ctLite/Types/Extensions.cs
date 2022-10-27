using ctLite.Common;

namespace ctLite.Types
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the TypeManager.
        /// </summary>
        /// <returns>TypeManager</returns>
        public static TypeManager Types(this UnityClient client)
        {
            return new TypeManager(client);
        }
    }
}
