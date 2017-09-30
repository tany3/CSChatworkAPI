/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CSChatworkAPI.Models;
using Newtonsoft.Json;
using RestSharp;

namespace CSChatworkAPI.Communicators
{
    internal class ApiCommunicator
    {
        protected string ApiToken { get; }

        public ApiCommunicator(string apiToken)
        {
            if (string.IsNullOrWhiteSpace(apiToken)) { throw new ArgumentNullException(apiToken); }
            ApiToken = apiToken;
        }

        private static string BaseUri => @"https://api.chatwork.com/v2/";

        public T Get<T>(string resource, Dictionary<string, object> parameters = null)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(BaseUri + resource)
            };
            var request = new RestRequest(Method.GET)
            {
                RequestFormat = DataFormat.Json,
            };
            request.AddHeader("X-ChatWorkToken", ApiToken);

            BuildParameters(request, parameters);

            var response = client.Execute(request);

            ThrowExceptionIfNeed(response);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public T Post<T>(string resource, Dictionary<string, object> parameters)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(BaseUri + resource)
            };
            var request = new RestRequest(Method.POST)
            {
                RequestFormat = DataFormat.Json,
            };
            request.AddHeader("X-ChatWorkToken", ApiToken);

            BuildParameters(request, parameters);

            var response = client.Execute(request);

            ThrowExceptionIfNeed(response);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public T Send<T>(string resource, Dictionary<string, object> parameters, Method method)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(BaseUri + resource)
            };
            var request = new RestRequest(method)
            {
                RequestFormat = DataFormat.Json,
            };
            request.AddHeader("X-ChatWorkToken", ApiToken);

            BuildParameters(request, parameters);

            var response = client.Execute(request);

            ThrowExceptionIfNeed(response);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        private static void BuildParameters(RestRequest request, Dictionary<string, object> parameters)
        {
            if (parameters == null || !parameters.Any()) return;

            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }
        }

        private static void ThrowExceptionIfNeed(IRestResponse response)
        {
            var rl = new RateLimit(response);
            if ((int)response.StatusCode == 429)
                throw new TooManyRequestsException(rl);

            if (response.StatusCode != HttpStatusCode.NoContent && (int)response.StatusCode != 200)
                throw new Exception($"API returns {response.StatusCode}. API response is here: {response.Content}");
        }
    }
}
