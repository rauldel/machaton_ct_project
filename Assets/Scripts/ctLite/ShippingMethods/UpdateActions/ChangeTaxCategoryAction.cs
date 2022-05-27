using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.ShippingMethods.UpdateActions
{
    /// <summary>
    /// Change Tax Category
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-shippingMethods.html#change-taxcategory"/>
    public class ChangeTaxCategoryAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Reference to a TaxCategory
        /// </summary>
        [JsonProperty(PropertyName = "taxCategory")]
        public Reference TaxCategory { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:ctLite.ShippingMethods.UpdateActions.ChangeTaxCategoryAction"/> class.
        /// </summary>
        public ChangeTaxCategoryAction()
        {
            this.Action = "changeTaxCategory";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="taxCategory">Reference to a TaxCategory</param>
        public ChangeTaxCategoryAction(Reference taxCategory)
        {
            this.Action = "changeTaxCategory";
            this.TaxCategory = taxCategory;
        }

        #endregion
    }
}
