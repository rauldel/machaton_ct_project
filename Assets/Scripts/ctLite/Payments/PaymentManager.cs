using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using ctLite.Common;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ctLite.Payments
{
    /// <summary>
    ///Provides access to the functions in the Payments section of the API.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-payments.html"/>
    public class PaymentManager
    {
        #region Constants

        private const string ENDPOINT_PREFIX = "/payments";

        #endregion

        #region Member Variables

        private readonly UnityClient _client;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">Client</param>
        public PaymentManager(UnityClient client)
        {
            _client = client;
        }

        #endregion

        #region API Methods

        /// <summary>
        /// Gets an Payment by its ID.
        /// </summary>
        /// <param name="paymentId">Payment ID</param>
        /// <returns>Payment</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-payments.html#get-payment-by-id"/>
        public IEnumerator GetPaymentByIdAsync(string paymentId, Action<Response<Payment>> onSuccess, Action<Response<Payment>> onError)
        {
            if (string.IsNullOrWhiteSpace(paymentId))
            {
                throw new ArgumentException("paymentId is required");
            }

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", paymentId);
            return _client.GetAsync<Payment>(endpoint, onSuccess, onError);
        }

        /// <summary>
        /// Queries for Payments.
        /// </summary>
        /// <param name="where">Where</param>
        /// <param name="sort">Sort</param>
        /// <param name="limit">Limit</param>
        /// <param name="offset">Offset</param>
        /// <returns>PaymentQueryResult</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-payments.html#query-payments"/>
        public IEnumerator QueryPaymentsAsync(Action<Response<PaymentQueryResult>> onSuccess, Action<Response<PaymentQueryResult>> onError, string where = null, string sort = null, int limit = -1, int offset = -1)
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

            return _client.GetAsync<PaymentQueryResult>(ENDPOINT_PREFIX, onSuccess, onError, values);
        }

        /// <summary>
        /// To create a payment object a payment draft object has to be given
        /// with the request.
        /// </summary>
        /// <param name="draft">PaymentDraft</param>
        /// <returns>Payment</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-payments.html#create-a-payment"/>
        public IEnumerator CreatePaymentAsync(PaymentDraft draft, Action<Response<Payment>> onSuccess, Action<Response<Payment>> onError)
        {
            if (draft == null)
            {
                throw new ArgumentException("draft is required");
            }

            string payload = JsonConvert.SerializeObject(draft, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return _client.PostAsync<Payment>(ENDPOINT_PREFIX, payload, onSuccess, onError);
        }

        /// <summary>
        /// Updates a Payment.
        /// </summary>
        /// <param name="payment">Payment</param>
        /// <param name="action">The update action to be performed on the payment.</param>
        /// <returns>Payment</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-payments.html#update-payment"/>
        public IEnumerator UpdatePaymentAsync(Payment payment, UpdateAction action, Action<Response<Payment>> onSuccess, Action<Response<Payment>> onError)
        {
            return UpdatePaymentAsync(payment.Id, payment.Version, new List<UpdateAction> { action }, onSuccess, onError);
        }

        /// <summary>
        /// Updates a Payment.
        /// </summary>
        /// <param name="payment">Payment</param>
        /// <param name="actions">The list of update actions to be performed on the payment.</param>
        /// <returns>Payment</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-payments.html#update-payment"/>
        public IEnumerator UpdatePaymentAsync(Payment payment, List<UpdateAction> actions, Action<Response<Payment>> onSuccess, Action<Response<Payment>> onError)
        {
            return UpdatePaymentAsync(payment.Id, payment.Version, actions, onSuccess, onError);
        }

        /// <summary>
        /// Updates a Payment.
        /// </summary>
        /// <param name="paymentId">ID of the payment</param>
        /// <param name="version">The expected version of the payment resource on which the changes should be applied.</param>
        /// <param name="actions">The list of update actions to be performed on the payment.</param>
        /// <returns>Payment</returns>
        /// <see href="http://dev.commercetools.com/http-api-projects-payments.html#update-payment"/>
        public IEnumerator UpdatePaymentAsync(string paymentId, int version, List<UpdateAction> actions, Action<Response<Payment>> onSuccess, Action<Response<Payment>> onError)
        {
            if (string.IsNullOrWhiteSpace(paymentId))
            {
                throw new ArgumentException("Payment ID is required");
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

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", paymentId);
            return _client.PostAsync<Payment>(endpoint, data.ToString(), onSuccess, onError);
        }

        /// <summary>
        /// Removes a Payment.
        /// </summary>
        /// <param name="payment">Payment</param>
        /// <see href="http://dev.commercetools.com/http-api-projects-payments.html#delete-payment"/>
        public IEnumerator DeletePaymentAsync(Payment payment, Action<Response<JObject>> onSuccess, Action<Response<JObject>> onError)
        {
            return DeletePaymentAsync(payment.Id, payment.Version, onSuccess, onError);
        }

        /// <summary>
        /// Removes a Payment.
        /// </summary>
        /// <param name="paymentId">Payment ID</param>
        /// <param name="version">Payment version</param>
        /// <see href="http://dev.commercetools.com/http-api-projects-payments.html#delete-payment"/>
        public IEnumerator DeletePaymentAsync(string paymentId, int version, Action<Response<JObject>> onSuccess, Action<Response<JObject>> onError)
        {
            if (string.IsNullOrWhiteSpace(paymentId))
            {
                throw new ArgumentException("paymentId is required");
            }

            if (version < 1)
            {
                throw new ArgumentException("Version is required");
            }

            var values = new NameValueCollection
            {
                { "version", version.ToString() }
            };

            string endpoint = string.Concat(ENDPOINT_PREFIX, "/", paymentId);
            return _client.DeleteAsync<JObject>(endpoint, onSuccess, onError, values);
        }

        #endregion
    }
}
