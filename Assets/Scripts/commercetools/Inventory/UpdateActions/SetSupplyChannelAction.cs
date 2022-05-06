using myCT.Channels;
using myCT.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace myCT.Inventory.UpdateActions
{
    /// <summary>
    /// Set Supply Channel
    /// </summary>   
    /// <see href="http://docs.commercetools.com/http-api-projects-inventory.html#set-supplychannel"/>
    public class SetSupplyChannelAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// SupplyChannel.
        /// </summary>
        [JsonProperty(PropertyName = "supplyChannel")]
        public Reference SupplyChannel { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Inventory.UpdateActions.SetSupplyChannelAction"/> class.
        /// </summary>
        public SetSupplyChannelAction()
        {
            this.Action = "setSupplyChannel";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="supplyChannel">Supply Channel</param>
        public SetSupplyChannelAction(Reference supplyChannel)
        {
            this.Action = "setSupplyChannel";
            this.SupplyChannel = supplyChannel;
        }

        #endregion
    }
}
