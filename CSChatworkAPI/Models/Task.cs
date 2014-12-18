/* See the file "LICENSE" for the full license governing this code. */

using System;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    public class Task
    {
        public int task_id { get; set; }
        public Account account { get; set; }
        public AssignedByAccount assigned_by_account { get; set; }
        public int message_id { get; set; }
        public string body { get; set; }
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime limit_time { get; set; }
        public string status { get; set; }

        public override string ToString()
        {
            return string.Format("account: {0}, assigned_by_account: {1}, body: {2}, limit_time: {3}, message_id: {4}, status: {5}, task_id: {6}", account, assigned_by_account, body, limit_time, message_id, status, task_id);
        }
    }

    public class AssignedByAccount
    {
        public int account_id { get; set; }
        public string name { get; set; }
        public string avatar_image_url { get; set; }

        public override string ToString()
        {
            return string.Format("account_id: {0}, avatar_image_url: {1}, name: {2}", account_id, avatar_image_url, name);
        }
    }
}
