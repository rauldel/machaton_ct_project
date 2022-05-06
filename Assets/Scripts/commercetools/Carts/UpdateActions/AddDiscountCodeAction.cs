using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Carts.UpdateActions
{
    /// <summary>
    /// Adds a DiscountCode to the cart to enable the related CartDiscounts.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-carts.html#add-discountcode"/>
    public class AddDiscountCodeAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// The code of an existing DiscountCode.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Carts.UpdateActions.AddDiscountCodeAction"/> class.
        /// </summary>
        public AddDiscountCodeAction()
        {
            this.Action = "addDiscountCode";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">The code of an existing DiscountCode.</param>
        public AddDiscountCodeAction(string code)
        {
            this.Action = "addDiscountCode";
            this.Code = code;
        }

        #endregion
    }
}
