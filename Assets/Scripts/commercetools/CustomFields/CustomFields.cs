using myCT.Common;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace myCT.CustomFields
{
    /// <summary>
    /// CustomFields
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-custom-fields.html#customfields"/>
    public class CustomFields
    {
        #region Properties

        [JsonProperty(PropertyName = "type")]
        public Reference Type { get; private set; }

        [JsonProperty(PropertyName = "fields")]
        public JObject Fields { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.CustomFields.CustomFields"/> class.
        /// </summary>
        public CustomFields() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public CustomFields(dynamic data)
        {
            if (data == null)
            {
                return;
            }

            this.Type = new Reference(data.type);
            this.Fields = data.fields;
        }

        #endregion
    }
}
