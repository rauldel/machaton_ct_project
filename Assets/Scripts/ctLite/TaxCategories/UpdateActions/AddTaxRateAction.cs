using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.TaxCategories.UpdateActions
{
    /// <summary>
    /// Add TaxRate
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-taxCategories.html#add-taxrate"/>
    public class AddTaxRateAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// TaxRateDraft
        /// </summary>
        [JsonProperty(PropertyName = "taxRate")]
        public TaxRateDraft TaxRate { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.TaxCategories.UpdateActions.AddTaxRateAction"/> class.
        /// </summary>
        public AddTaxRateAction() 
        {
            this.Action = "addTaxRate";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="taxRate">TaxRateDraft</param>
        public AddTaxRateAction(TaxRateDraft taxRate)
        {
            this.Action = "addTaxRate";
            this.TaxRate = taxRate;
        }

        #endregion
    }
}
