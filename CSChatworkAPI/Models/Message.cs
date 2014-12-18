/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    public class Message
    {
        public int message_id { get; set; }
        public Account account { get; set; }
        public string body { get; set; }
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime send_time { get; set; }
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime update_time { get; set; }

        public override string ToString()
        {
            return string.Format("account: {0}, body: {1}, message_id: {2}, send_time: {3}, update_time: {4}", account, body, message_id, send_time, update_time);
        }
    }

    public class Account
    {
        public int account_id { get; set; }
        public string name { get; set; }
        public string avatar_image_url { get; set; }

        public override string ToString()
        {
            return string.Format("account_id: {0}, avatar_image_url: {1}, name: {2}", account_id, avatar_image_url, name);
        }
    }

    public class ResponseMessage
    {
        public int message_id { get; set; }

        public override string ToString()
        {
            return string.Format("message_id: {0}", message_id);
        }
    }

    public class ResponseTaskIds
    {
        public List<int> task_ids { get; set; }

        public override string ToString()
        {
            return string.Format("task_ids: {0}", task_ids);
        }
    }
}
