using Newtonsoft.Json;
using myCT.Common;

namespace myCT.Carts
{
    /// <summary>
    /// ExternalTaxAmountDraft
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-carts.html#externaltaxamountdraft"/>
    public class ExternalTaxAmountDraft
    {
        #region Properties

        [JsonProperty(PropertyName = "totalGross")]
        public Money TotalGross { get; set; }

        [JsonProperty(PropertyName = "taxRate")]
        public ExternalTaxRateDraft TaxRate { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Carts.ExternalTaxAmountDraft"/> class.
        /// </summary>
        public ExternalTaxAmountDraft() {}

        /// <summary>
        /// Constructor.
        /// </summary>
        public ExternalTaxAmountDraft(Money totalGross, ExternalTaxRateDraft taxRate)
        {
            this.TotalGross = totalGross;
            this.TaxRate = taxRate;
        }

        #endregion
    }
}
