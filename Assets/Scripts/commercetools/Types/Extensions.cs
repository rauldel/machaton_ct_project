using myCT.Common;

namespace myCT.Types
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
        public static TypeManager Types(this IClient client)
        {
            return new TypeManager(client);
        }
    }
}
