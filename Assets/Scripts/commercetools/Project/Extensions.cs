using myCT.Common;

namespace myCT.Project
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the ProjectManager.
        /// </summary>
        /// <returns>ProjectManager</returns>
        public static ProjectManager Project(this IClient client)
        {
            return new ProjectManager(client);
        }
    }
}
