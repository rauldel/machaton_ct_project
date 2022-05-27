using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.ShippingMethods.UpdateActions
{
    /// <summary>
    /// Change isDefault
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-shippingMethods.html#change-isdefault"/>
    public class ChangeIsDefaultAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// IsDefault
        /// </summary>
        [JsonProperty(PropertyName = "isDefault")]
        public bool IsDefault { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.ShippingMethods.UpdateActions.ChangeIsDefaultAction"/> class.
        /// </summary>
        public ChangeIsDefaultAction()
        {
            this.Action = "changeIsDefault";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="isDefault">IsDefault</param>
        public ChangeIsDefaultAction(bool isDefault)
        {
            this.Action = "changeIsDefault";
            this.IsDefault = isDefault;
        }

        #endregion
    }
}
