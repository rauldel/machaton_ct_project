using ctLite.Common;

using Newtonsoft.Json;

namespace ctLite.Customers.UpdateActions
{
    /// <summary>
    /// ChangeEmailAction
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-customers.html#change-email"/>
    public class ChangeEmailAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Customers.UpdateActions.ChangeEmailAction"/> class.
        /// </summary>
        public ChangeEmailAction()
        {
            this.Action = "changeEmail";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="email">Email</param>
        public ChangeEmailAction(string email)
        {
            this.Action = "changeEmail";
            this.Email = email;
        }

        #endregion
    }
}
