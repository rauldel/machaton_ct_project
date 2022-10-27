using System;
using System.Collections;

using ctLite.Common;

namespace ctLite.Project
{
    /// <summary>
    /// Provides access to the functions in the Project section of the API.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-project.html"/>    
    public class ProjectManager
    {
        #region Member Variables

        private readonly UnityClient _client;

        #endregion 

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="client">Client</param>
        public ProjectManager(UnityClient client)
        {
            _client = client;
        }

        #endregion

        #region API Methods

        /// <summary>
        /// ets the current project.
        /// </summary>
        /// <see href="http://dev.commercetools.com/http-api-projects-project.html#get-project"/>
        /// <returns>Project</returns>
        public IEnumerator GetProjectAsync(Action<Response<Project>> onSuccess, Action<Response<Project>> onError)
        {
            return _client.GetAsync<Project>(string.Empty, onSuccess, onError);
        }

        #endregion
    }
}
