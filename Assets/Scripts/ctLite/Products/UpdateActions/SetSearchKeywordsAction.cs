using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Products.UpdateActions
{
    /// <summary>
    /// Set SearchKeywords
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-products.html#set-searchkeywords"/>
    public class SetSearchKeywordsAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// SearchKeywords
        /// </summary>
        [JsonProperty(PropertyName = "searchKeywords")]
        public SearchKeywords SearchKeywords { get; set; }

        /// <summary>
        /// Staged
        /// </summary>
        /// <remarks>
        /// Defaults to true
        /// </remarks>
        [JsonProperty(PropertyName = "staged")]
        public bool Staged { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Products.UpdateActions.SetSearchKeywordsAction"/> class.
        /// </summary>
        public SetSearchKeywordsAction()
        {
            this.Action = "setSearchKeywords";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="searchKeywords">SearchKeywords</param>
        public SetSearchKeywordsAction(SearchKeywords searchKeywords)
        {
            this.Action = "setSearchKeywords";
            this.SearchKeywords = searchKeywords;
        }

        #endregion
    }
}
