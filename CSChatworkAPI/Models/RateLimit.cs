using System;
using System.Linq;
using CSChatworkAPI.Extensions;
using RestSharp;

namespace CSChatworkAPI.Models
{
    public class RateLimit
    {
        public int Limit { get; set; }
        public int Remaining { get; set; }
        public DateTime Reset { get; set; }

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

        public override string ToString()
        {
            return string.Format("Limit: {0}, Remaining: {1}, Reset: {2}", Limit, Remaining, Reset);
        }
    }
}
