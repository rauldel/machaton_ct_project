﻿using myCT.Common;
using Newtonsoft.Json;

namespace myCT.CartDiscounts.UpdateActions
{
    public class ChangeTargetAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "target")]
        public CartDiscountTarget Target { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.CartDiscounts.UpdateActions.ChangeTargetAction"/> class.
        /// </summary>
        public ChangeTargetAction()
        {
            this.Action = "changeTarget";
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="target">Target.</param>
        public ChangeTargetAction(CartDiscountTarget target)
        {
            this.Action = "changeTarget";
            this.Target = target;
        }

        #endregion
    }
}
