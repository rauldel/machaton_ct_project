using Newtonsoft.Json;

namespace myCT.Subscriptions
{
    /// <summary>
    /// ChangeSubscription
    /// </summary>
    /// <remarks>
    /// Different payloads for resource creation, update and deletion are delivered.
    /// </remarks>
    /// <see href="https://dev.commercetools.com/http-api-projects-subscriptions.html#changesubscription"/>
    public class ChangeSubscription 
    {
        #region Properties

        /// <summary>
        /// Resource Type ID
        /// </summary>
        [JsonProperty(PropertyName = "resourceTypeId")]
        public string ResourceTypeId { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Subscriptions.ChangeSubscription"/> class.
        /// </summary>
        public ChangeSubscription() {}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="resourceTypeId">Resource Type ID</param>
        public ChangeSubscription(string resourceTypeId)
        {
            this.ResourceTypeId = resourceTypeId;
        }

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public ChangeSubscription(dynamic data)
        {
            if (data == null)
            {
                return;
            }

            this.ResourceTypeId = data.resourceTypeId;
        }

        #endregion
    }
}
