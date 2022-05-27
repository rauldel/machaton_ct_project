using System.Collections.Generic;

using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Subscriptions.UpdateActions
{
    /// <summary>
    /// Set Changes
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-subscriptions.html#set-changes"/>
    public class SetChangesAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Changes
        /// </summary>
        [JsonProperty(PropertyName = "changes")]
        public List<ChangeSubscription> Changes { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public SetChangesAction()
        {
            this.Action = "setChanges";
        }

        #endregion
    }
}
