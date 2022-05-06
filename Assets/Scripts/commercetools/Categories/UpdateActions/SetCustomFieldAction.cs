using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Categories.UpdateActions
{
    /// <summary>
    /// SetCustomFieldAction 
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-categories.html#set-customfield"/>
    public class SetCustomFieldAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Field name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public object Value { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Categories.UpdateActions.SetCustomFieldAction"/> class.
        /// </summary>
        public SetCustomFieldAction()
        {
            this.Action = "setCustomField";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Field name</param>
        public SetCustomFieldAction(string name)
        {
            this.Action = "setCustomField";
            this.Name = name;
        }

        #endregion
    }
}
