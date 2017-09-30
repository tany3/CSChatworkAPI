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
        public string RoomId { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// role
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// sticky
        /// </summary>
        public bool Sticky { get; set; }

        /// <summary>
        /// unread_num
        /// </summary>
        public long UnreadNum { get; set; }

        /// <summary>
        /// mention_num
        /// </summary>
        public long MentionNum { get; set; }

        /// <summary>
        /// mytask_num
        /// </summary>
        public long MyTaskNum { get; set; }

        /// <summary>
        /// message_num
        /// </summary>
        public long MessageNum { get; set; }

        /// <summary>
        /// file_num
        /// </summary>
        public long FileNum { get; set; }

        /// <summary>
        /// task_num
        /// </summary>
        public long TaskNum { get; set; }

        /// <summary>
        /// last_update_time
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// last_update_time
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(RoomId)}: {RoomId}, {nameof(Name)}: {Name}, {nameof(Type)}: {Type}, {nameof(Role)}: {Role}, {nameof(Sticky)}: {Sticky}, {nameof(UnreadNum)}: {UnreadNum}, {nameof(MentionNum)}: {MentionNum}, {nameof(MyTaskNum)}: {MyTaskNum}, {nameof(MessageNum)}: {MessageNum}, {nameof(FileNum)}: {FileNum}, {nameof(TaskNum)}: {TaskNum}, {nameof(IconPath)}: {IconPath}, {nameof(LastUpdateTime)}: {LastUpdateTime}, {nameof(Description)}: {Description}";
        }

        public bool Equals(Room other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(RoomId, other.RoomId) && string.Equals(Name, other.Name) && string.Equals(Type, other.Type) && string.Equals(Role, other.Role) && Sticky == other.Sticky && UnreadNum == other.UnreadNum && MentionNum == other.MentionNum && MyTaskNum == other.MyTaskNum && MessageNum == other.MessageNum && FileNum == other.FileNum && TaskNum == other.TaskNum && string.Equals(IconPath, other.IconPath) && LastUpdateTime.Equals(other.LastUpdateTime) && string.Equals(Description, other.Description);
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
                var hashCode = (RoomId != null ? RoomId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Role != null ? Role.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Sticky.GetHashCode();
                hashCode = (hashCode * 397) ^ UnreadNum.GetHashCode();
                hashCode = (hashCode * 397) ^ MentionNum.GetHashCode();
                hashCode = (hashCode * 397) ^ MyTaskNum.GetHashCode();
                hashCode = (hashCode * 397) ^ MessageNum.GetHashCode();
                hashCode = (hashCode * 397) ^ FileNum.GetHashCode();
                hashCode = (hashCode * 397) ^ TaskNum.GetHashCode();
                hashCode = (hashCode * 397) ^ (IconPath != null ? IconPath.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ LastUpdateTime.GetHashCode();
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
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
        public string RoomId { get; set; }

        /// <summary>
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(RoomId)}: {RoomId}";
        }

        public bool Equals(ResponseRoomId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(RoomId, other.RoomId);
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
            return (RoomId != null ? RoomId.GetHashCode() : 0);
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
