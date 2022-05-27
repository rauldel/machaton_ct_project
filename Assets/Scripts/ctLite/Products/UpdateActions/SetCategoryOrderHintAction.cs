using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Products.UpdateActions
{
    /// <summary>
    /// SetCategoryOrderHintAction
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-products.html#set-category-order-hint"/>
    public class SetCategoryOrderHintAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Id of a Category the product belongs to
        /// </summary>
        [JsonProperty(PropertyName = "categoryId")]
        public string CategoryId { get; set; }

        /// <summary>
        /// String representing a number between 0 and 1
        /// </summary>
        [JsonProperty(PropertyName = "orderHint")]
        public string OrderHint { get; set; }

        /// <summary>
        /// Staged
        /// </summary>
        [JsonProperty(PropertyName = "staged")]
        public bool Staged { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Products.UpdateActions.SetCategoryOrderHintAction"/> class.
        /// </summary>
        public SetCategoryOrderHintAction()
        {
            this.Action = "setCategoryOrderHint";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="categoryId">Id of a Category the product belongs to</param>
        public SetCategoryOrderHintAction(string categoryId)
        {
            this.Action = "setCategoryOrderHint";
            this.CategoryId = categoryId;
        }

        #endregion
    }
}
