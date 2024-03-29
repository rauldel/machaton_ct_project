﻿using myCT.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace myCT.Inventory.UpdateActions
{
    /// <summary>
    /// In order to remove a Quantity, it decrements quantityOnStock and updates availableQuantity according to the new quantity and amount of active reservations.
    /// </summary>
    /// <see href="http://docs.commercetools.com/http-api-projects-inventory.html#remove-quantity"/>
    public class RemoveQuantityAction : UpdateAction
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
        /// Initializes a new instance of the <see cref="T:myCT.Inventory.UpdateActions.RemoveQuantityAction"/> class.
        /// </summary>
        public RemoveQuantityAction()
        {
            this.Action = "removeQuantity";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="quantity">Quantity</param>
        public RemoveQuantityAction(int quantity)
        {
            this.Action = "removeQuantity";
            this.Quantity = quantity;
        }

        #endregion
    }
}
