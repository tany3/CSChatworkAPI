using System;

namespace CSChatworkAPI.Models.MyTasks
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
        /// icon_path
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return $"icon_path: {IconPath}, name: {Name}, room_id: {RoomId}";
        }

        public bool Equals(Room other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(RoomId, other.RoomId) && string.Equals(Name, other.Name) && string.Equals(IconPath, other.IconPath);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Room)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (RoomId != null ? RoomId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (IconPath != null ? IconPath.GetHashCode() : 0);
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
}
