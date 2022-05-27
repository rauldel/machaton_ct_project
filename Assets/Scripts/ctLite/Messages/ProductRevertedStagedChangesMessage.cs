using System.Collections.Generic;

using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Messages
{
    /// <summary>
    /// This message is the result of the revertStagedChanges update action. 
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-messages.html#productrevertedstagedchanges-message"/>
    public class ProductRevertedStagedChangesMessage : Message
    {
        #region Properties

        /// <summary>
        /// List of images which were removed with this action.
        /// </summary>
        [JsonProperty(PropertyName = "removedImageUrls")]
        public List<string> RemovedImageUrls { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Messages.ProductRevertedStagedChangesMessage"/> class.
        /// </summary>
        public ProductRevertedStagedChangesMessage() : base() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public ProductRevertedStagedChangesMessage(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.RemovedImageUrls = Helper.GetListFromJsonArray<string>(data.removedImageUrls);
        }

        #endregion
    }
}
