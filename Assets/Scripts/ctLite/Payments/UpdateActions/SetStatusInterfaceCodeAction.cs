using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Payments.UpdateActions
{
    /// <summary>
    /// Sets the code, given by the PSP, that describes the current status.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-payments.html#set-statusinterfacecode"/>
    public class SetStatusInterfaceCodeAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Interface Code
        /// </summary>
        [JsonProperty(PropertyName = "interfaceCode")]
        public string InterfaceCode { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Payments.UpdateActions.SetStatusInterfaceCodeAction"/> class.
        /// </summary>
        public SetStatusInterfaceCodeAction()
        {
            this.Action = "setStatusInterfaceCode";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="interfaceCode">Interface Code</param>
        public SetStatusInterfaceCodeAction(string interfaceCode)
        {
            this.Action = "setStatusInterfaceCode";
            this.InterfaceCode = interfaceCode;
        }

        #endregion
    }
}
