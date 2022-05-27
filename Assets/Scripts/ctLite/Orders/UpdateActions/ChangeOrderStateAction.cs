using ctLite.Common;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ctLite.Orders.UpdateActions
{
    /// <summary>
    /// ChangeOrderStateAction
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-orders.html#change-orderstate"/>
    public class ChangeOrderStateAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// OrderState
        /// </summary>
        [JsonProperty(PropertyName = "orderState")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderState OrderState { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Orders.UpdateActions.ChangeOrderStateAction"/> class.
        /// </summary>
        public ChangeOrderStateAction()
        {
            this.Action = "changeOrderState";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="orderState">OrderState</param>
        public ChangeOrderStateAction(OrderState orderState)
        {
            this.Action = "changeOrderState";
            this.OrderState = orderState;
        }

        #endregion
    }
}
