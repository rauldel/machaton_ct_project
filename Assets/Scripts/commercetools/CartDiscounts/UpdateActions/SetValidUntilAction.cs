using System;
using myCT.Common;
using Newtonsoft.Json;

namespace myCT.CartDiscounts.UpdateActions
{
    public class SetValidUntilAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "validUntil")]
        public DateTime? ValidUntil { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public SetValidUntilAction()
        {
            this.Action = "setValidUntil";
        }

        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="validUntil">Valid until.</param>
        public SetValidUntilAction(DateTime validUntil)
        {
            this.Action = "setValidUntil";
            this.ValidUntil = validUntil;
        }

        #endregion
    }
}
