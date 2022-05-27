using System;
using System.Collections.Generic;

using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Products.UpdateActions
{
    /// <summary>
    /// Set Asset Tags
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-products.html#set-asset-tags"/>
    public class SetAssetTagsAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Variant ID
        /// </summary>
        [JsonProperty(PropertyName = "variantId")]
        public int? VariantId { get; set; }

        /// <summary>
        /// Sku
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Staged
        /// </summary>
        /// <remarks>
        /// Defaults to true
        /// </remarks>
        [JsonProperty(PropertyName = "staged")]
        public bool Staged { get; set; }

        /// <summary>
        /// Asset ID
        /// </summary>
        [JsonProperty(PropertyName = "assetId")]
        public string AssetId { get; set; }

        /// <summary>
        /// Tags
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Products.UpdateActions.SetAssetTagsAction"/> class.
        /// </summary>
        public SetAssetTagsAction()
        {
            this.Action = "setAssetTags";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="assetId">Asset ID</param>
        /// <param name="variantId">Variant ID</param>
        /// <param name="sku">Sku</param>
        public SetAssetTagsAction(string assetId, int? variantId = null, string sku = null)
        {
            if (!variantId.HasValue && string.IsNullOrWhiteSpace(sku))
            {
                throw new ArgumentException("Either variantId or sku are required");
            }

            this.Action = "setAssetTags";
            this.AssetId = assetId;
            this.VariantId = variantId;
            this.Sku = sku;
        }

        #endregion
    }
}
