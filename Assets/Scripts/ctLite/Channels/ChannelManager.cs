using ctLite.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ctLite.Channels
{
    /// <summary>
    /// Provides access to the functions in the Channels section of the API.
    /// </summary>
    /// <see href="http://docs.commercetools.com/http-api-projects-channels.html"/>
    public class ChannelManager
    {
        #region Constants

        private const string ENDPOINT_PREFIX = "/channels";

        #endregion

        #region Member Variables

        private UnityClient _client;

        #endregion 

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">Client</param>
        public ChannelManager(UnityClient client)
        {
            _client = client;
        }
        #endregion

        #region API Methods

        /// <summary>
        /// Gets an Channel  by its ID.
        /// </summary>
        /// <param name="channelId">Channel ID</param>
        /// <returns>Channel</returns>
        /// /// <see href="https://docs.commercetools.com/http-api-projects-Channel.html#get-channel-by-id"/>
        public IEnumerator GetChannelByIdAsync(string channelId, Action<Response<Channel>> onSuccess, Action<Response<Channel>> onError)
        {
            if (string.IsNullOrWhiteSpace(channelId))
            {
                throw new ArgumentException("ChannelId is required");
            }

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", channelId);
            return _client.GetAsync<Channel>(endpoint, onSuccess, onError);
        }

        /// <summary>
        /// Queries channels.
        /// </summary>
        /// <param name="where">Where</param>
        /// <param name="sort">Sort</param>
        /// <param name="limit">Limit</param>
        /// <param name="offset">Offset</param>
        /// <returns>ChannelQueryResult</returns>
        /// <see href="docs.commercetools.com/http-api-projects-channels.html#query-channels"/>
        public IEnumerator QueryChannelAsync(Action<Response<ChannelQueryResult>> onSuccess, Action<Response<ChannelQueryResult>> onError, string where = null, string sort = null, int limit = -1, int offset = -1)
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

            return _client.GetAsync<ChannelQueryResult>(ENDPOINT_PREFIX, onSuccess, onError, values);
        }

        /// <summary>
        /// Creates a new Channel.
        /// </summary>
        /// <param name="channelDraft">ChannelDraft object</param>
        /// <returns>Channel</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-channel.html#create-a-channel"/>
        public IEnumerator CreateChannelAsync(ChannelDraft ChannelDraft, Action<Response<Channel>> onSuccess, Action<Response<Channel>> onError)
        {
            if (ChannelDraft == null)
            {
                throw new ArgumentException("ChannelDraft cannot be null");
            }

            if (string.IsNullOrWhiteSpace(ChannelDraft.Key))
            {
                throw new ArgumentException("key is required");
            }

            string payload = JsonConvert.SerializeObject(ChannelDraft, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return _client.PostAsync<Channel>(ENDPOINT_PREFIX, payload, onSuccess, onError);
        }

        /// <summary>
        /// Updates an Channel .
        /// </summary>
        /// <param name="channel">Channel </param>
        /// <param name="action">The update action to be performed on the Channel .</param>
        /// <returns>Channel</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-channel.html#update-channel"/>
        public IEnumerator UpdateChannelAsync(Channel Channel, UpdateAction action, Action<Response<Channel>> onSuccess, Action<Response<Channel>> onError)
        {
            return UpdateChannelAsync(Channel.Id, Channel.Version, new List<UpdateAction> { action }, onSuccess, onError);
        }

        /// <summary>
        /// Updates a Channel .
        /// </summary>
        /// <param name="channel">Channel </param>
        /// <param name="actions">The list of update actions to be performed on the Channel .</param>
        /// <returns>Channel</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-channel.html#update-a-channel"/>
        public IEnumerator UpdateChannelAsync(Channel Channel, List<UpdateAction> actions, Action<Response<Channel>> onSuccess, Action<Response<Channel>> onError)
        {
            return UpdateChannelAsync(Channel.Id, Channel.Version, actions, onSuccess, onError);
        }

        /// <summary>
        /// Updates a Channel .
        /// </summary>
        /// <param name="ChannelId">ID of the Channel </param>
        /// <param name="version">The expected version of the Channel  on which the changes should be applied.</param>
        /// <param name="actions">The list of update actions to be performed on the Channel.</param>
        /// <returns>Channel</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-channel.html#update-channel"/>
        public IEnumerator UpdateChannelAsync(string ChannelId, int version, List<UpdateAction> actions, Action<Response<Channel>> onSuccess, Action<Response<Channel>> onError)
        {
            if (string.IsNullOrWhiteSpace(ChannelId))
            {
                throw new ArgumentException("Channel ID is required");
            }

            if (version < 1)
            {
                throw new ArgumentException("Version is required");
            }

            if (actions == null || actions.Count < 1)
            {
                throw new ArgumentException("One or more update actions is required");
            }

            JObject data = JObject.FromObject(new
            {
                version = version,
                actions = JArray.FromObject(actions, new JsonSerializer { NullValueHandling = NullValueHandling.Ignore })
            });

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", ChannelId);
            return _client.PostAsync<Channel>(endpoint, data.ToString(), onSuccess, onError);
        }

        /// <summary>
        /// Deletes an Channel.
        /// </summary>
        /// <param name="Channel">Channel  object</param>
        /// <returns>Channel</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-channel.html#delete-channel"/>
        public IEnumerator DeleteChannelAsync(Channel Channel, Action<Response<Channel>> onSuccess, Action<Response<Channel>> onError)
        {
            return DeleteChannelAsync(Channel.Id, Channel.Version, onSuccess, onError);
        }

        /// <summary>
        /// Deletes an Channel .
        /// </summary>
        /// <param name="ChannelId">Channel  ID</param>
        /// <param name="version">Channel version</param>
        /// <returns>Channel</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-channel.html#delete-channel"/>
        public IEnumerator DeleteChannelAsync(string ChannelId, int version, Action<Response<Channel>> onSuccess, Action<Response<Channel>> onError)
        {
            if (string.IsNullOrWhiteSpace(ChannelId))
            {
                throw new ArgumentException("Channel  ID is required");
            }

            if (version < 1)
            {
                throw new ArgumentException("Version is required");
            }

            var values = new NameValueCollection
            {
                { "version", version.ToString() }
            };

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", ChannelId);
            return _client.DeleteAsync<Channel>(endpoint, onSuccess, onError, values);
        }

        #endregion
    }
}
