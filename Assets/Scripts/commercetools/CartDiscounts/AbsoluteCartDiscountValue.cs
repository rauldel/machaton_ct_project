using System;
using System.Collections.Generic;
using myCT.Common;
using Newtonsoft.Json;

namespace myCT.CartDiscounts
{
    public class AbsoluteCartDiscountValue : CartDiscountValue
    {
        #region Properties

        [JsonProperty(PropertyName = "money")]
        public List<Money> Money { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.CartDiscounts.AbsoluteCartDiscountValue"/> class.
        /// </summary>
        public AbsoluteCartDiscountValue() : base() {}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="money">Money.</param>
        public AbsoluteCartDiscountValue(List<Money> money) : base(CartDiscountType.Absolute)
        {
            if (money == null || money.Count == 0)
            {
                throw new ArgumentException($"{nameof(money)} cannot be null or empty.");
            }

            this.Money = money;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">Data.</param>
        public AbsoluteCartDiscountValue(dynamic data) : base((object)data)
        {
            List<Money> money = Helper.GetListFromJsonArray<Money>(data.money);

            if (money == null || money.Count == 0)
            {
                throw new ArgumentException($"{nameof(money)} cannot be null or empty.");
            }

            this.Money = money;
        }

        #endregion
    }
}
