using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Products.UpdateActions
{
    /// <summary>
    /// Change slug
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-products.html#change-slug"/>
    public class ChangeSlugAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Every slug must be unique across a project, but a product can have the same slug for different languages. Allowed are alphabetic, numeric, underscore (_) and hyphen (-) characters. Maximum size is 256.
        /// </summary>
        [JsonProperty(PropertyName = "slug")]
        public LocalizedString Slug { get; set; }

        /// <summary>
        /// Staged
        /// </summary>
        [JsonProperty(PropertyName = "staged")]
        public bool Staged { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Products.UpdateActions.ChangeSlugAction"/> class.
        /// </summary>
        public ChangeSlugAction() 
        {
            this.Action = "changeSlug";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="slug">Slug</param>
        public ChangeSlugAction(LocalizedString slug)
        {
            this.Action = "changeSlug";
            this.Slug = slug;
        }

        #endregion
    }
}
