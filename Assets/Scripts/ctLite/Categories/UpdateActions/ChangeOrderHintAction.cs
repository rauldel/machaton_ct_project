using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Categories.UpdateActions
{
    /// <summary>
    /// ChangeOrderHintAction
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-categories.html#change-orderhint"/>
    public class ChangeOrderHintAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Order Hint
        /// </summary>
        [JsonProperty(PropertyName = "orderHint")]
        public string OrderHint { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Categories.UpdateActions.ChangeOrderHintAction"/> class.
        /// </summary>
        public ChangeOrderHintAction()
        {
            this.Action = "changeOrderHint";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="orderHint">Order Hint</param>
        public ChangeOrderHintAction(string orderHint)
        {
            this.Action = "changeOrderHint";
            this.OrderHint = orderHint;
        }

        #endregion
    }
}
