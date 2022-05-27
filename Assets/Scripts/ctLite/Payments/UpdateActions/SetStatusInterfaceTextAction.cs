using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Payments.UpdateActions
{
    /// <summary>
    /// Sets a text, given by the PSP, that describes the current status.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-payments.html#set-statusinterfacetext"/>
    public class SetStatusInterfaceTextAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Interface Text
        /// </summary>
        [JsonProperty(PropertyName = "interfaceText")]
        public string InterfaceText { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Payments.UpdateActions.SetStatusInterfaceTextAction"/> class.
        /// </summary>
        public SetStatusInterfaceTextAction()
        {
            this.Action = "setStatusInterfaceText";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="interfaceText">Interface Text</param>
        public SetStatusInterfaceTextAction(string interfaceText)
        {
            this.Action = "setStatusInterfaceText";
            this.InterfaceText = interfaceText;
        }

        #endregion
    }
}
