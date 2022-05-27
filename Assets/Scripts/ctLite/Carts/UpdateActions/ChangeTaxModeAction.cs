using ctLite.Common;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ctLite.Carts.UpdateActions
{
    /// <summary>
    /// Changes the TaxMode of a cart.
    /// </summary>
    /// <remarks>
    /// When a tax mode is changed from External to Platform or Disabled, all previously set external tax rates will be removed. When changing the tax mode to Platform, line items, custom line items and shipping method require a tax category with a tax rate for the given shipping address.
    /// </remarks>
    /// <see href="https://dev.commercetools.com/http-api-projects-carts.html#change-taxmode"/>
    public class ChangeTaxModeAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// TaxMode
        /// </summary>
        [JsonProperty(PropertyName = "taxMode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TaxMode TaxMode { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Carts.UpdateActions.ChangeTaxModeAction"/> class.
        /// </summary>
        public ChangeTaxModeAction()
        {
            this.Action = "changeTaxMode";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="taxMode">TaxMode</param>
        public ChangeTaxModeAction(TaxMode taxMode)
        {
            this.Action = "changeTaxMode";
            this.TaxMode = taxMode;
        }

        #endregion
    }
}
