using myCT.Common;

namespace myCT.Categories
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the CategoryManager.
        /// </summary>
        /// <returns>CategoryManager</returns>
        public static CategoryManager Categories(this IClient client)
        {
            return new CategoryManager(client);
        }
    }
}
