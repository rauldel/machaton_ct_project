﻿using System;
using System.Collections.Generic;

using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Subscriptions
{
    /// <summary>
    /// Subscription
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-subscriptions.html#subscription"/>
    public class Subscription
    {
        #region Properties

        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Version
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public int Version { get; private set; }

        /// <summary>
        /// User-specific unique identifier for the subscription
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; private set; }

        /// <summary>
        /// The Message Queue into which the notifications are to be sent
        /// </summary>
        [JsonProperty(PropertyName = "destination")]
        public Destination Destination { get; private set; }

        /// <summary>
        /// The messages subscribed to
        /// </summary>
        [JsonProperty(PropertyName = "messages")]
        public List<MessageSubscription> Messages { get; private set; }

        /// <summary>
        /// The change notifications subscribed to
        /// </summary>
        [JsonProperty(PropertyName = "changes")]
        public List<ChangeSubscription> Changes { get; private set; }

        /// <summary>
        /// CreatedAt
        /// </summary>
        [JsonProperty(PropertyName = "createdAt")]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// LastModifiedAt
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedAt")]
        public DateTime? LastModifiedAt { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Subscriptions.Subscription"/> class.
        /// </summary>
        public Subscription() {}

        /// <summary>
        /// Initializes this instance with JSON data from an API response.
        /// </summary>
        /// <param name="data">JSON object</param>
        public Subscription(dynamic data)
        {
            if (data == null)
            {
                return;
            }

            this.Id = data.id;
            this.Version = data.version;
            this.Key = data.key;
            this.Destination = DestinationFactory.Create(data.destination);
            this.Messages = Helper.GetListFromJsonArray<MessageSubscription>(data.messages);
            this.Changes = Helper.GetListFromJsonArray<ChangeSubscription>(data.changes);
            this.CreatedAt = data.createdAt;
            this.LastModifiedAt = data.lastModifiedAt;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Subscription subscription = obj as Subscription;

            if (subscription == null)
            {
                return false;
            }

            return subscription.Id.Equals(this.Id);
        }

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion
    }
}
