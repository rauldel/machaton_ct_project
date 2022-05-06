using myCT.Reviews;

using Newtonsoft.Json;

namespace myCT.Messages
{
    /// <summary>
    /// This message is the result of the create review request.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-messages.html#reviewcreated-message"/>
    public class ReviewCreatedMessage : Message
    {
        #region Properties

        /// <summary>
        /// Review
        /// </summary>
        [JsonProperty(PropertyName = "review")]
        public Review Review { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Messages.ReviewCreatedMessage"/> class.
        /// </summary>
        public ReviewCreatedMessage() : base() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public ReviewCreatedMessage(dynamic data)
            : base((object)data)
        {
            if (data == null)
            {
                return;
            }

            this.Review = new Review(data.review);
        }

        #endregion
    }
}
