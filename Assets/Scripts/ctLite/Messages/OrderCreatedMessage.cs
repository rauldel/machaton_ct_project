using ctLite.Orders;

using Newtonsoft.Json;

namespace ctLite.Messages
{
    /// <summary>
    /// This message is created when a cart is ordered.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-messages.html#ordercreated-message"/>
    public class OrderCreatedMessage : Message
    {
        #region Properties

        /// <summary>
        /// Order
        /// </summary>
        [JsonProperty(PropertyName = "order")]
        public Order Order { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Messages.OrderCreatedMessage"/> class.
        /// </summary>
        public OrderCreatedMessage() : base() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public OrderCreatedMessage(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.Order = new Order(data.order);
        }

        #endregion
    }
}
