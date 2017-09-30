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
        /// description
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(room_id)}: {room_id}, {nameof(name)}: {name}, {nameof(type)}: {type}, {nameof(role)}: {role}, {nameof(sticky)}: {sticky}, {nameof(unread_num)}: {unread_num}, {nameof(mention_num)}: {mention_num}, {nameof(mytask_num)}: {mytask_num}, {nameof(message_num)}: {message_num}, {nameof(file_num)}: {file_num}, {nameof(task_num)}: {task_num}, {nameof(icon_path)}: {icon_path}, {nameof(last_update_time)}: {last_update_time}, {nameof(description)}: {description}";
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
