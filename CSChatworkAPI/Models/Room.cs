/* See the file "LICENSE" for the full license governing this code. */

using System;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    public class Room
    {
        public int room_id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string role { get; set; }
        public bool sticky { get; set; }
        public int unread_num { get; set; }
        public int mention_num { get; set; }
        public int mytask_num { get; set; }
        public int message_num { get; set; }
        public int file_num { get; set; }
        public int task_num { get; set; }
        public string icon_path { get; set; }
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime last_update_time { get; set; }

        public override string ToString()
        {
            return string.Format("file_num: {0}, icon_path: {1}, last_update_time: {2}, mention_num: {3}, message_num: {4}, mytask_num: {5}, name: {6}, role: {7}, room_id: {8}, sticky: {9}, task_num: {10}, type: {11}, unread_num: {12}", file_num, icon_path, last_update_time, mention_num, message_num, mytask_num, name, role, room_id, sticky, task_num, type, unread_num);
        }
    }
}
