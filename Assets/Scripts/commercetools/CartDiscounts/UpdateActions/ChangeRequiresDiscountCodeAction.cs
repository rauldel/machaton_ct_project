using myCT.Common;
using Newtonsoft.Json;

namespace myCT.CartDiscounts.UpdateActions
{
    public class ChangeRequiresDiscountCodeAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "requiresDiscountCode")]
        public bool RequiresDiscountCode { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:myCT.CartDiscounts.UpdateActions.ChangeRequiresDiscountCodeAction"/> class.
        /// </summary>
        public ChangeRequiresDiscountCodeAction()
        {
            this.Action = "changeRequiresDiscountCode";
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="requiresDiscountCode">If set to <c>true</c> requires discount code.</param>
        public ChangeRequiresDiscountCodeAction(bool requiresDiscountCode)
        {
            this.Action = "changeRequiresDiscountCode";
            this.RequiresDiscountCode = requiresDiscountCode;
        }

        #endregion
    }
}
