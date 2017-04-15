/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// Message
    /// </summary>
    public class Message
    {
        /// <summary>
        /// message_id
        /// </summary>
        public int message_id { get; set; }

        /// <summary>
        /// account
        /// </summary>
        public Account account { get; set; }

        /// <summary>
        /// body
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// send_time
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime send_time { get; set; }

        /// <summary>
        /// update_time
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime update_time { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("account: {0}, body: {1}, message_id: {2}, send_time: {3}, update_time: {4}", account, body, message_id, send_time, update_time);
        }
    }

    /// <summary>
    /// Account
    /// </summary>
    public class Account
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

    /// <summary>
    /// ResponseMessage
    /// </summary>
    public class ResponseMessage
    {
        /// <summary>
        /// message_id
        /// </summary>
        public int message_id { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("message_id: {0}", message_id);
        }
    }

    /// <summary>
    /// ResponseTaskIds
    /// </summary>
    public class ResponseTaskIds
    {
        /// <summary>
        /// task_ids
        /// </summary>
        public List<int> task_ids { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("task_ids: {0}", task_ids);
        }
    }
}
