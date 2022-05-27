using ctLite.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ctLite.Carts.UpdateActions
{
    /// <summary>
    /// The total tax amount of the cart can be set if it has the ExternalAmount TaxMode.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-carts.html#set-cart-total-tax"/>
    public class SetCartTotalTaxAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "externalTotalGross")]
        public Money ExternalTotalGross { get; set; }

        [JsonProperty(PropertyName = "externalTaxPortions")]
        public List<TaxPortion> ExternalTaxPortions { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Carts.UpdateActions.SetCartTotalTaxAction"/> class.
        /// </summary>
        public SetCartTotalTaxAction()
        {
            this.Action = "setCartTotalTax";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public SetCartTotalTaxAction(Money externalTotalGross)
        {
            this.Action = "setCartTotalTax";
            this.ExternalTotalGross = externalTotalGross;
        }

        #endregion
    }
}
