using System;
using myCT.Common;
using Newtonsoft.Json;

namespace myCT.CartDiscounts.UpdateActions
{
    public class SetValidFromAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "validFrom")]
        public DateTime? ValidFrom { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.CartDiscounts.UpdateActions.SetValidFromAction"/> class.
        /// </summary>
        public SetValidFromAction()
        {
            this.Action = "setValidFrom";
        }

        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="validFrom">Valid from.</param>
        public SetValidFromAction(DateTime validFrom)
        {
            this.Action = "setValidFrom";
            this.ValidFrom = validFrom;
        }

        #endregion
    }
}
