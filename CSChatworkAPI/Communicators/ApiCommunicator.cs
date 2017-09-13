/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using System.Linq;
using CSChatworkAPI.Models;
using Newtonsoft.Json;
using RestSharp;

namespace CSChatworkAPI.Communicators
{
    internal class ApiCommunicator
    {
        protected string ApiToken { get; private set; }

        public ApiCommunicator(string apiToken)
        {
            if (string.IsNullOrWhiteSpace(apiToken)) { throw new ArgumentNullException(apiToken); }
            ApiToken = apiToken;
        }

        private string BaseUri
        {
            get { return @"https://api.chatwork.com/v2/"; }
        }

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
            var content = response.Content;

            var rl = new RateLimit(response);
            if (rl.Remaining == 0)
            {
                throw new TooManyRequestsException(rl);
            }

            //var errors = JsonConvert.DeserializeObject<Errors>(content);
            //if (errors.errors != null && errors.errors.Any())
            //{
            //    throw new Exception(errors.ToString());
            //}

            return JsonConvert.DeserializeObject<T>(content);
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
            var content = response.Content;

            var rl = new RateLimit(response);
            if (rl.Remaining == 0)
            {
                throw new TooManyRequestsException(rl);
            }

            //var errors = JsonConvert.DeserializeObject<Errors>(content);
            //if (errors.errors != null && errors.errors.Any())
            //{
            //    throw new Exception(errors.ToString());
            //}

            return JsonConvert.DeserializeObject<T>(content);
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
            var content = response.Content;
            
            var rl = new RateLimit(response);
            if (rl.Remaining == 0)
            {
                throw new TooManyRequestsException(rl);
            }

            //var errors = JsonConvert.DeserializeObject<Errors>(content);
            //if (errors.errors != null && errors.errors.Any())
            //{
            //    throw new Exception(errors.ToString());
            //}

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
