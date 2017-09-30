/* See the file "LICENSE" for the full license governing this code. */

using System;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// MyTask
    /// </summary>
    public class MyTask : IEquatable<MyTask>
    {
        /// <summary>
        /// Room
        /// </summary>
        public class Room : IEquatable<Room>
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
            /// icon_path
            /// </summary>
            public string icon_path { get; set; }

            /// <summary>
            /// フォーマット済み文字列を返します
            /// </summary>
            public override string ToString()
            {
                return string.Format("icon_path: {0}, name: {1}, room_id: {2}", icon_path, name, room_id);
            }

            public bool Equals(Room other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return string.Equals(room_id, other.room_id) && string.Equals(name, other.name) && string.Equals(icon_path, other.icon_path);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Room) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (room_id != null ? room_id.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (icon_path != null ? icon_path.GetHashCode() : 0);
                    return hashCode;
                }
            }

            public static bool operator ==(Room left, Room right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(Room left, Room right)
            {
                return !Equals(left, right);
            }
        }

        /// <summary>
        /// AssignedByAccount
        /// </summary>
        public class AssignedByAccount : IEquatable<AssignedByAccount>
        {
            /// <summary>
            /// account_id
            /// </summary>
            public string account_id { get; set; }

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

            public bool Equals(AssignedByAccount other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return string.Equals(account_id, other.account_id) && string.Equals(name, other.name) && string.Equals(avatar_image_url, other.avatar_image_url);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((AssignedByAccount) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (account_id != null ? account_id.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (avatar_image_url != null ? avatar_image_url.GetHashCode() : 0);
                    return hashCode;
                }
            }

            public static bool operator ==(AssignedByAccount left, AssignedByAccount right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(AssignedByAccount left, AssignedByAccount right)
            {
                return !Equals(left, right);
            }
        }

        /// <summary>
        /// task_id
        /// </summary>
        public string task_id { get; set; }

        /// <summary>
        /// room
        /// </summary>
        public Room room { get; set; }

        /// <summary>
        /// assigned_by_account
        /// </summary>
        public AssignedByAccount assigned_by_account { get; set; }

        /// <summary>
        /// message_id
        /// </summary>
        public string message_id { get; set; }

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
            return string.Format("assigned_by_account: {0}, body: {1}, limit_time: {2}, message_id: {3}, room: {4}, status: {5}, task_id: {6}", assigned_by_account, body, limit_time, message_id, room, status, task_id);
        }

        public bool Equals(MyTask other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(task_id, other.task_id) && Equals(room, other.room) && Equals(assigned_by_account, other.assigned_by_account) && string.Equals(message_id, other.message_id) && string.Equals(body, other.body) && limit_time.Equals(other.limit_time) && string.Equals(status, other.status);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MyTask) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (task_id != null ? task_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (room != null ? room.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (assigned_by_account != null ? assigned_by_account.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (message_id != null ? message_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (body != null ? body.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ limit_time.GetHashCode();
                hashCode = (hashCode * 397) ^ (status != null ? status.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(MyTask left, MyTask right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MyTask left, MyTask right)
        {
            return !Equals(left, right);
        }
    }
}
