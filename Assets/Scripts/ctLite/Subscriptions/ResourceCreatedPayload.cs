using Newtonsoft.Json;

namespace ctLite.Subscriptions
{
    /// <summary>
    /// This payload will be sent for a ChangeSubscription if a resource was updated.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-subscriptions.html#resourcecreated-payload"/>
    public class ResourceCreatedPayload : DeliveryPayload
    {
        #region Properties

        /// <summary>
        /// The version of the resource after it was created
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public int? Version { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ctLite.Subscriptions.ResourceCreatedPayload"/> class.
        /// </summary>
        public ResourceCreatedPayload() : base() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public ResourceCreatedPayload(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.Version = data.version;
        }

        #endregion
    }
}
