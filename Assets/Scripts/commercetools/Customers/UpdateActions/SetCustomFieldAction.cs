using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Customers.UpdateActions
{
    /// <summary>
    /// SetCustomFieldAction
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-customers.html#set-customfield"/>
    public class SetCustomFieldAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Field name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Field value
        /// </summary>
        /// <remarks>
        /// If absent or null, this field is removed if it exists.
        /// </remarks>
        [JsonProperty(PropertyName = "value")]
        public object Value { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Customers.UpdateActions.SetCustomFieldAction"/> class.
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
