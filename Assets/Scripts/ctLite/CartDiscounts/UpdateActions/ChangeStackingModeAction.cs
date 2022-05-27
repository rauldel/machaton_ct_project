using ctLite.Common;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ctLite.CartDiscounts.UpdateActions
{
    /// <summary>
    /// ChangeStackingModeAction
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-cartDiscounts.html#change-stacking-mode"/>
    public class ChangeStackingModeAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// StackingMode
        /// </summary>
        [JsonProperty(PropertyName = "stackingMode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StackingMode StackingMode { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:ctLite.CartDiscounts.UpdateActions.ChangeStackingModeAction"/> class.
        /// </summary>
        public ChangeStackingModeAction()
        {
            this.Action = "changeStackingMode";
        }
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stackingMode">StackingMode</param>
        public ChangeStackingModeAction(StackingMode stackingMode)
        {
            this.Action = "changeStackingMode";
            this.StackingMode = stackingMode;
        }

        #endregion
    }
}
