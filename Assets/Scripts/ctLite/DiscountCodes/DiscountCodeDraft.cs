using System;
using System.Collections.Generic;
using ctLite.Common;
using ctLite.CustomFields;
using Newtonsoft.Json;

namespace ctLite.DiscountCodes
{
    public class DiscountCodeDraft
    {
        #region properties

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public LocalizedString Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public LocalizedString Description { get; set; }

        /// <summary>
        /// Cart Discount Predicate
        /// </summary>
        [JsonProperty(PropertyName = "cartPredicate")]
        public string CartPredicate { get; set; }

        /// <summary>
        /// Array of Reference to a CartDiscount.
        /// </summary>
        [JsonProperty(PropertyName = "cartDiscounts")]
        public List<Reference> CartDiscounts { get; private set; }

        /// <summary>
        /// Unique identifier of this discount code. 
        /// This value is added to the cart to enable the related cart discounts in the cart.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; private set; }

        [JsonProperty(PropertyName = "maxApplications")]
        public int? MaxApplications { get; set; }

        [JsonProperty(PropertyName = "maxApplicationsPerCustomer")]
        public int? MaxApplicationsPerCustomer { get; set; }

        /// <summary>
        /// The custom fields.
        /// </summary>
        [JsonProperty(PropertyName = "custom")]
        public CustomFieldsDraft Custom { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.DiscountCodes.DiscountCodeDraft"/> class.
        /// </summary>
        public DiscountCodeDraft() {}

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="code">Code.</param>
        /// <param name="cartDiscounts">Cart discounts.</param>
        /// <param name="isActive">If set to <c>true</c> is active.</param>
        public DiscountCodeDraft(
            string code,
            List<Reference> cartDiscounts,
            bool isActive)
        {
            if (code == null)
                throw new ArgumentNullException(nameof(code));

            if (cartDiscounts == null || cartDiscounts.Count == 0)
                throw new ArgumentException($"{nameof(cartDiscounts)} cannot be null or empty.");

            Code = code;
            CartDiscounts = cartDiscounts;
            IsActive = isActive;
        }

        #endregion
    }
}
