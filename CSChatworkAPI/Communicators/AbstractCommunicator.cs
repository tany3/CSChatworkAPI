/* See the file "LICENSE" for the full license governing this code. */
using System;
using Newtonsoft.Json;
using RestSharp;

namespace CSChatworkAPI.Communicators
{
    public abstract class AbstractCommunicator
    {
        public string ApiToken { get; private set; }

        protected AbstractCommunicator(string apiToken)
        {
            if (string.IsNullOrWhiteSpace(apiToken)) { throw new ArgumentNullException(apiToken); }
            ApiToken = apiToken;
        }

        protected string BaseUri
        {
            get { return @"https://api.chatwork.com/v1/"; }
        }

        protected T GetT<T>(string resource)
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

            var response = client.Execute(request);
            var content = response.Content;

            return JsonConvert.DeserializeObject<T>(content);
        }

        protected T PostT<T>(string resource, object value)
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
            request.AddParameter("body", value);

            var response = client.Execute(request);
            var content = response.Content;

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
