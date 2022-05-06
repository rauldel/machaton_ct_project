using System;

using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Payments.UpdateActions
{
    /// <summary>
    /// Changes timestamp of a transaction. 
    /// </summary>
    /// <remarks>
    /// If this transaction represents an action at the PSP, the time returned by the PSP should be used.
    /// </remarks>
    /// <see href="https://dev.commercetools.com/http-api-projects-payments.html#change-transactiontimestamp"/>
    public class ChangeTransactionTimestampAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// UUID of the transaction to be updated
        /// </summary>
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// The new timestamp
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:myCT.Payments.UpdateActions.ChangeTransactionTimestampAction"/> class.
        /// </summary>
        public ChangeTransactionTimestampAction()
        {
            this.Action = "changeTransactionTimestamp";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="transactionId">UUID of the transaction to be updated</param>
        /// <param name="timestamp">The new timestamp</param>
        public ChangeTransactionTimestampAction(string transactionId, DateTime timestamp)
        {
            this.Action = "changeTransactionTimestamp";
            this.TransactionId = transactionId;
            this.Timestamp = timestamp;
        }

        #endregion
    }
}
