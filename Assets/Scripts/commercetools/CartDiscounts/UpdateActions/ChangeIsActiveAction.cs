using myCT.Common;
using Newtonsoft.Json;

namespace myCT.CartDiscounts.UpdateActions
{
    public class ChangeIsActiveAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.CartDiscounts.UpdateActions.ChangeIsActiveAction"/> class.
        /// </summary>
        public ChangeIsActiveAction()
        {
            this.Action = "changeIsActive";
        }

        /// <summary>
        /// Constructor with parameters.
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
