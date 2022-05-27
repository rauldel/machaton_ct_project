using ctLite.Common;
using Newtonsoft.Json;

namespace ctLite.DiscountCodes.UpdateActions
{
    public class ChangeIsActiveAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.DiscountCodes.UpdateActions.ChangeIsActiveAction"/> class.
        /// </summary>
        public ChangeIsActiveAction()
        {
            this.Action = "changeIsActive";
        }

        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="isActive">If set to <c>true</c> is active.</param>
        public ChangeIsActiveAction(bool isActive)
        {
            this.Action = "changeIsActive";
            this.IsActive = isActive;
        }

        #endregion
    }
}
