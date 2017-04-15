using System;
using System.Linq;
using CSChatworkAPI.Extensions;
using RestSharp;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// RateLimit
    /// </summary>
    public class RateLimit
    {
        /// <summary>
        /// Limit
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Remaining
        /// </summary>
        public int Remaining { get; set; }

        /// <summary>
        /// Reset
        /// </summary>
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

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("Limit: {0}, Remaining: {1}, Reset: {2}", Limit, Remaining, Reset);
        }
    }
}
