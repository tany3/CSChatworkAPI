/* See the file "LICENSE" for the full license governing this code. */

using System;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// Room
    /// </summary>
    public class Room
    {
        /// <summary>
        /// room_id
        /// </summary>
        public string room_id { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// type
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// role
        /// </summary>
        public string role { get; set; }

        /// <summary>
        /// sticky
        /// </summary>
        public bool sticky { get; set; }

        /// <summary>
        /// unread_num
        /// </summary>
        public long unread_num { get; set; }

        /// <summary>
        /// mention_num
        /// </summary>
        public long mention_num { get; set; }

        /// <summary>
        /// mytask_num
        /// </summary>
        public long mytask_num { get; set; }

        /// <summary>
        /// message_num
        /// </summary>
        public long message_num { get; set; }

        /// <summary>
        /// file_num
        /// </summary>
        public long file_num { get; set; }

        /// <summary>
        /// task_num
        /// </summary>
        public long task_num { get; set; }

        /// <summary>
        /// last_update_time
        /// </summary>
        public string icon_path { get; set; }

        /// <summary>
        /// last_update_time
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime last_update_time { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("file_num: {0}, icon_path: {1}, last_update_time: {2}, mention_num: {3}, message_num: {4}, mytask_num: {5}, name: {6}, role: {7}, room_id: {8}, sticky: {9}, task_num: {10}, type: {11}, unread_num: {12}", file_num, icon_path, last_update_time, mention_num, message_num, mytask_num, name, role, room_id, sticky, task_num, type, unread_num);
        }
    }

    /// <summary>
    /// ResponseRoomId
    /// </summary>
    public class ResponseRoomId
    {
        /// <summary>
        /// room_id
        /// </summary>
        public int room_id { get; set; }
    }
}
