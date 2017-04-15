/* See the file "LICENSE" for the full license governing this code. */

using System;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// Task
    /// </summary>
    public class Task
    {
        /// <summary>
        /// task_id
        /// </summary>
        public int task_id { get; set; }

        /// <summary>
        /// account
        /// </summary>
        public Account account { get; set; }

        /// <summary>
        /// assigned_by_account
        /// </summary>
        public AssignedByAccount assigned_by_account { get; set; }

        /// <summary>
        /// message_id
        /// </summary>
        public int message_id { get; set; }

        /// <summary>
        /// body
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// limit_time
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime limit_time { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("account: {0}, assigned_by_account: {1}, body: {2}, limit_time: {3}, message_id: {4}, status: {5}, task_id: {6}", account, assigned_by_account, body, limit_time, message_id, status, task_id);
        }
    }

    /// <summary>
    /// AssignedByAccount
    /// </summary>
    public class AssignedByAccount
    {
        /// <summary>
        /// account_id
        /// </summary>
        public int account_id { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// avatar_image_url
        /// </summary>
        public string avatar_image_url { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("account_id: {0}, avatar_image_url: {1}, name: {2}", account_id, avatar_image_url, name);
        }
    }
}
