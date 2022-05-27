using ctLite.Common;
using Newtonsoft.Json;

namespace ctLite.CartDiscounts.UpdateActions
{
    public class ChangeValueAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "value")]
        public CartDiscountValue Value { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.CartDiscounts.UpdateActions.ChangeValueAction"/> class.
        /// </summary>
        public ChangeValueAction()
        {
            this.Action = "changeValue";
        }

        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="value">Value.</param>
        public ChangeValueAction(CartDiscountValue value)
        {
            this.Action = "changeValue";
            this.Value = value;
        }

        #endregion
    }
}
