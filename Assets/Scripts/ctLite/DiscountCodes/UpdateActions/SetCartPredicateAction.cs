using ctLite.Common;
using Newtonsoft.Json;

namespace ctLite.DiscountCodes.UpdateActions
{
    public class SetCartPredicateAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "cartPredicate")]
        public string CartPredicate { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public SetCartPredicateAction()
        {
            this.Action = "setCartPredicate";
        }

        #endregion
    }
}
