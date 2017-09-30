/* See the file "LICENSE" for the full license governing this code. */

using System;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
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

        public bool Equals(Room other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(room_id, other.room_id) && string.Equals(name, other.name) && string.Equals(type, other.type) && string.Equals(role, other.role) && sticky == other.sticky && unread_num == other.unread_num && mention_num == other.mention_num && mytask_num == other.mytask_num && message_num == other.message_num && file_num == other.file_num && task_num == other.task_num && string.Equals(icon_path, other.icon_path) && last_update_time.Equals(other.last_update_time) && string.Equals(description, other.description);
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
                hashCode = (hashCode * 397) ^ (type != null ? type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (role != null ? role.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ sticky.GetHashCode();
                hashCode = (hashCode * 397) ^ unread_num.GetHashCode();
                hashCode = (hashCode * 397) ^ mention_num.GetHashCode();
                hashCode = (hashCode * 397) ^ mytask_num.GetHashCode();
                hashCode = (hashCode * 397) ^ message_num.GetHashCode();
                hashCode = (hashCode * 397) ^ file_num.GetHashCode();
                hashCode = (hashCode * 397) ^ task_num.GetHashCode();
                hashCode = (hashCode * 397) ^ (icon_path != null ? icon_path.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ last_update_time.GetHashCode();
                hashCode = (hashCode * 397) ^ (description != null ? description.GetHashCode() : 0);
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
    /// ResponseRoomId
    /// </summary>
    public class ResponseRoomId : IEquatable<ResponseRoomId>
    {
        /// <summary>
        /// room_id
        /// </summary>
        public string room_id { get; set; }

        public bool Equals(ResponseRoomId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(room_id, other.room_id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ResponseRoomId) obj);
        }

        public override int GetHashCode()
        {
            return (room_id != null ? room_id.GetHashCode() : 0);
        }

        public static bool operator ==(ResponseRoomId left, ResponseRoomId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ResponseRoomId left, ResponseRoomId right)
        {
            return !Equals(left, right);
        }
    }
}
