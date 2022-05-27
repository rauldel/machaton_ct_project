using ctLite.Common;
using Newtonsoft.Json;

namespace ctLite.CartDiscounts.UpdateActions
{
    public class ChangeNameAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "name")]
        public LocalizedString Name { get; }

        #endregion

        #region Properties

        /// <summary>
        /// Constructor.
        /// </summary>
        public ChangeNameAction()
        {
            this.Action = "changeName";
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="name">Name.</param>
        public ChangeNameAction(LocalizedString name)
        {
            this.Action = "changeName";
            this.Name = name;
        }

        #endregion
    }
}
