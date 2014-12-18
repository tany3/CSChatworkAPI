/* See the file "LICENSE" for the full license governing this code. */

using System;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    public class MyTask
    {
        public class Room
        {
            public int room_id { get; set; }
            public string name { get; set; }
            public string icon_path { get; set; }

            public override string ToString()
            {
                return string.Format("icon_path: {0}, name: {1}, room_id: {2}", icon_path, name, room_id);
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

        public int task_id { get; set; }
        public Room room { get; set; }
        public AssignedByAccount assigned_by_account { get; set; }
        public int message_id { get; set; }
        public string body { get; set; }
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime limit_time { get; set; }
        public string status { get; set; }

        public override string ToString()
        {
            return string.Format("assigned_by_account: {0}, body: {1}, limit_time: {2}, message_id: {3}, room: {4}, status: {5}, task_id: {6}", assigned_by_account, body, limit_time, message_id, room, status, task_id);
        }
    }
}
