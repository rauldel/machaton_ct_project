using System;
using System.Collections;
using System.Collections.Specialized;

using ctLite.Common;

namespace ctLite.Messages
{
    /// <summary>
    /// Provides access to the functions in the Messages section of the API.
    /// </summary>
    public class MessageManager
    {
        #region Constants

        private const string ENDPOINT_PREFIX = "/messages";

        #endregion

        #region Member Variables

        private readonly UnityClient _client;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">Client</param>
        public MessageManager(UnityClient client)
        {
            _client = client;
        }

        #endregion

        #region API Methods

        /// <summary>
        /// Gets a Message by its ID.
        /// </summary>
        /// <param name="messageId">Message ID</param>
        /// <see href="http://dev.commercetools.com/http-api-projects-messages.html#get-message-by-id"/>
        /// <returns>Message</returns>
        public IEnumerator GetMessageByIdAsync(string messageId, Action<Response<Message>> onSuccess, Action<Response<Message>> onError)
        {
            if (string.IsNullOrWhiteSpace(messageId))
            {
                throw new ArgumentException("messageId is required");
            }

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", messageId);
            return _client.GetAsync<Message>(endpoint, onSuccess, onError);
        }

        /// <summary>
        /// Queries for Messages.
        /// </summary>
        /// <param name="where">Where</param>
        /// <param name="sort">Sort</param>
        /// <param name="limit">Limit</param>
        /// <param name="offset">Offset</param>
        /// <returns>MessageQueryResult</returns>
        public IEnumerator QueryMessagesAsync(Action<Response<MessageQueryResult>> onSuccess, Action<Response<MessageQueryResult>> onError, string where = null, string sort = null, int limit = -1, int offset = -1)
        {
            NameValueCollection values = new NameValueCollection();

            if (!string.IsNullOrWhiteSpace(where))
            {
                values.Add("where", where);
            }

            if (!string.IsNullOrWhiteSpace(sort))
            {
                values.Add("sort", sort);
            }

            if (limit > 0)
            {
                values.Add("limit", limit.ToString());
            }

            if (offset >= 0)
            {
                values.Add("offset", offset.ToString());
            }

            return _client.GetAsync<MessageQueryResult>(ENDPOINT_PREFIX, onSuccess, onError, values);
        }

        #endregion
    }
}
