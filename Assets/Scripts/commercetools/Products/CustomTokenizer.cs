using System.Collections.Generic;

using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Products
{
    /// <summary>
    /// CustomTokenizer
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-products.html#suggesttokenizer"/>
    public class CustomTokenizer : SuggestTokenizer
    {
        #region Properties

        [JsonProperty(PropertyName = "inputs")]
        public List<string> Inputs { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public CustomTokenizer()
            : base()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomTokenizer(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.Inputs = Helper.GetListFromJsonArray<string>(data.inputs);
        }

        #endregion
    }
}
