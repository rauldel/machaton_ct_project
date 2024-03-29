﻿using System.Collections.Generic;

using myCT.Common;

using Newtonsoft.Json;

namespace myCT.ShippingMethods
{
    /// <summary>
    /// The representation to be sent to the server when creating a new shipping method.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-shippingMethods.html#shippingmethoddraft"/>
    public class ShippingMethodDraft
    {
        #region Properties

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "taxCategory")]
        public Reference TaxCategory { get; set; }

        [JsonProperty(PropertyName = "zoneRates")]
        public List<ZoneRate> ZoneRates { get; set; }

        [JsonProperty(PropertyName = "isDefault")]
        public bool IsDefault { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:commmyCTercetools.ShippingMethods.ShippingMethodDraft"/> class.
        /// </summary>
        public ShippingMethodDraft() {}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="taxCategory">Tax category</param>
        /// <param name="zoneRates">Zone rates</param>
        public ShippingMethodDraft(string name, Reference taxCategory, List<ZoneRate> zoneRates)
        {
            this.Name = name;
            this.TaxCategory = taxCategory;
            this.ZoneRates = zoneRates;
        }

        #endregion
    }
}
