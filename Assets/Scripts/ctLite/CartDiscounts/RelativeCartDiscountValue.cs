using Newtonsoft.Json;

namespace ctLite.CartDiscounts
{
    public class RelativeCartDiscountValue : CartDiscountValue
    {
        #region Properties

        [JsonProperty(PropertyName = "permyriad")]
        public int? Permyriad { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.CartDiscounts.RelativeCartDiscountValue"/> class.
        /// </summary>
        public RelativeCartDiscountValue() : base() {}

        /// <summary>
        /// constructor.
        /// </summary>
        /// <param name="permyriad">Permyriad.</param>
        public RelativeCartDiscountValue(int permyriad) : base(CartDiscountType.Relative)
        {
            Permyriad = permyriad;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">Data.</param>
        public RelativeCartDiscountValue(dynamic data) : base((object)data)
        {
            this.Permyriad = data.permyriad;
        }

        #endregion
    }
}
