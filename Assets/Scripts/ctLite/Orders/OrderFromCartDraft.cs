using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using ctLite.Carts;

namespace ctLite.Orders
{
    /// <summary>
    /// OrderFromCartDraft
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-orders.html#orderfromcartdraft"/>
    public class OrderFromCartDraft
    {
        #region Properties

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        [JsonProperty(PropertyName = "orderNumber")]
        public string OrderNumber { get; set; }

        [JsonProperty(PropertyName = "paymentState")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentState? PaymentState { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Orders.OrderFromCartDraft"/> class.
        /// </summary>
        public OrderFromCartDraft() {}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="cart">Cart from which an order is created.</param>
        public OrderFromCartDraft(Cart cart)
        {
            this.Id = cart.Id;
            this.Version = cart.Version;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">The unique id of the cart from which an order is created.</param>
        /// <param name="version">Cart version</param>
        public OrderFromCartDraft(string id, int version)
        {
            this.Id = id;
            this.Version = version;
        }

        #endregion
    }
}
