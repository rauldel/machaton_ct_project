using myCT.Common;

using Newtonsoft.Json;

namespace myCT.TaxCategories.UpdateActions
{
    /// <summary>
    /// Remove TaxRate
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-taxCategories.html#remove-taxrate"/>
    public class RemoveTaxRateAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// TaxRateId
        /// </summary>
        [JsonProperty(PropertyName = "taxRateId")]
        public string TaxRateId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.TaxCategories.UpdateActions.RemoveTaxRateAction"/> class.
        /// </summary>
        public RemoveTaxRateAction()
        {
            this.Action = "removeTaxRate";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="taxRateId">TaxRateId</param>
        public RemoveTaxRateAction(string taxRateId)
        {
            this.Action = "removeTaxRate";
            this.TaxRateId = taxRateId;
        }

        #endregion
    }
}
