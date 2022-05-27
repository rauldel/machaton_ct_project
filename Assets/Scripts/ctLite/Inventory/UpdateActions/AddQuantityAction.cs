using ctLite.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ctLite.Inventory.UpdateActions
{
    /// <summary>
    /// In order to add a Quantity, it increments quantityOnStock and updates availableQuantity according to the new quantity and amount of active reservations.
    /// </summary>
    /// <see href="http://docs.commercetools.com/http-api-projects-inventory.html#add-quantity"/>
    public class AddQuantityAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Quantity.
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Inventory.UpdateActions.AddQuantityAction"/> class.
        /// </summary>
        public AddQuantityAction()
        {
            this.Action = "addQuantity";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="quantity">Quantity</param>
        public AddQuantityAction(int quantity)
        {
            this.Action = "addQuantity";
            this.Quantity = quantity;
        }

        #endregion
    }
}
