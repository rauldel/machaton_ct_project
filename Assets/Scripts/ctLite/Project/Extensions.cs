using ctLite.Common;

namespace ctLite.Project
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
        public static ProjectManager Project(this UnityClient client)
        {
            return new ProjectManager(client);
        }
    }
}
