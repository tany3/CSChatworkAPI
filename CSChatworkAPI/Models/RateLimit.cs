/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Linq;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;
using RestSharp;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// RateLimit
    /// </summary>
    public class RateLimit
    {
        /// <summary>
        /// limit
        /// </summary>
        [JsonProperty("limit")]
        public long Limit { get; set; }

        /// <summary>
        /// remaining
        /// </summary>
        [JsonProperty("remaining")]
        public long Remaining { get; set; }

        /// <summary>
        /// reset
        /// </summary>
        [JsonProperty("reset")]
        public DateTime Reset { get; set; }

        /// <summary>
        /// RateLimit
        /// </summary>
        public RateLimit(IRestResponse response)
        {
            var remaining = response.Headers.FirstOrDefault(x => x.Name.Equals("X-RateLimit-Remaining"));
            var limit = response.Headers.FirstOrDefault(x => x.Name.Equals("X-RateLimit-Limit"));
            var reset = response.Headers.FirstOrDefault(x => x.Name.Equals("X-RateLimit-Reset"));

            if (remaining != null)
                Remaining = int.Parse(remaining.Value.ToString());

            if (limit != null)
                Limit = int.Parse(limit.Value.ToString());

            if (reset != null)
            {
                var tzi = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
                var utc = DateTimeExtensions.ToDateTime(long.Parse(reset.Value.ToString()));
                Reset = TimeZoneInfo.ConvertTimeFromUtc(utc, tzi);
            }    
        }

        #region ReSharper Generated
        /// <summary>
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return $"Limit: {Limit}, Remaining: {Remaining}, Reset: {Reset}";
        }
        #endregion
    }
}
