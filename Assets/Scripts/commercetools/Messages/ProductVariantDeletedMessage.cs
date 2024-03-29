﻿using System.Collections.Generic;

using myCT.Common;
using myCT.Products;

using Newtonsoft.Json;

namespace myCT.Messages
{
    /// <summary>
    /// This message is the result of the removeProductvariant update action.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-messages.html#productvariantdeleted-message"/>
    public class ProductVariantDeletedMessage : Message
    {
        #region Properties

        /// <summary>
        /// List of images which were removed with this action.
        /// </summary>
        [JsonProperty(PropertyName = "removedImageUrls")]
        public List<string> RemovedImageUrls { get; private set; }

        /// <summary>
        /// The variant which was deleted.
        /// </summary>
        [JsonProperty(PropertyName = "variant")]
        public ProductVariant Variant { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Messages.ProductVariantDeletedMessage"/> class.
        /// </summary>
        public ProductVariantDeletedMessage() : base() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public ProductVariantDeletedMessage(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.RemovedImageUrls = Helper.GetListFromJsonArray<string>(data.removedImageUrls);
            this.Variant = new ProductVariant(data.variant);
        }

        #endregion
    }
}
