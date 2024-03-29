﻿using System.Collections.Generic;

using myCT.Common;
using myCT.ProductProjections;

using Newtonsoft.Json;

namespace myCT.Messages
{
    /// <summary>
    /// This message is the result of the delete Product command.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-messages.html#productdeleted-message"/>
    public class ProductDeletedMessage : Message
    {
        #region Properties

        /// <summary>
        /// List of images which were removed with this action.
        /// </summary>
        [JsonProperty(PropertyName = "removedImageUrls")]
        public List<string> RemovedImageUrls { get; private set; }

        /// <summary>
        /// The current projection of the deleted product.
        /// </summary>
        [JsonProperty(PropertyName = "currentProjection")]
        public ProductProjection CurrentProjection { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Messages.ProductDeletedMessage"/> class.
        /// </summary>
        public ProductDeletedMessage() : base() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public ProductDeletedMessage(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.RemovedImageUrls = Helper.GetListFromJsonArray<string>(data.removedImageUrls);
            this.CurrentProjection = new ProductProjection(data.currentProjection);
        }

        #endregion
    }
}
