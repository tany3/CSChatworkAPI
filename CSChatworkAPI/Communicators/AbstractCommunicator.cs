/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace CSChatworkAPI.Communicators
{
    public abstract class AbstractCommunicator
    {
        protected string ApiToken { get; private set; }

        protected AbstractCommunicator(string apiToken)
        {
            if (string.IsNullOrWhiteSpace(apiToken)) { throw new ArgumentNullException(apiToken); }
            ApiToken = apiToken;
        }

        protected string BaseUri
        {
            get { return @"https://api.chatwork.com/v1/"; }
        }

        protected T GetT<T>(string resource, Dictionary<string, object> parameters = null)
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
            var content = response.Content;

            return JsonConvert.DeserializeObject<T>(content);
        }

        protected T PostT<T>(string resource, Dictionary<string, object> parameters)
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
            var content = response.Content;

            return JsonConvert.DeserializeObject<T>(content);
        }

        protected T SendT<T>(string resource, Dictionary<string, object> parameters, Method method)
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
            var content = response.Content;

            return JsonConvert.DeserializeObject<T>(content);
        }

        private void BuildParameters(RestRequest request, Dictionary<string, object> parameters)
        {
            if (parameters == null || !parameters.Any()) return;

            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }
        }
    }
}
