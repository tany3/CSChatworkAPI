/* See the file "LICENSE" for the full license governing this code. */

using System;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// MyStatus
    /// </summary>
    public class MyStatus : IEquatable<MyStatus>
    {
        /// <summary>
        /// unread_room_num
        /// </summary>
        public long UnreadRoomNum { get; set; }

        /// <summary>
        /// mention_room_num
        /// </summary>
        public long MentionRoomNum { get; set; }

        /// <summary>
        /// mytask_room_num
        /// </summary>
        public long MyTaskRoomNum { get; set; }

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
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return
                $"mention_num: {MentionNum}, mention_room_num: {MentionRoomNum}, mytask_num: {MyTaskNum}, mytask_room_num: {MyTaskRoomNum}, unread_num: {UnreadNum}, unread_room_num: {UnreadRoomNum}";
        }

        public bool Equals(MyStatus other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return UnreadRoomNum == other.UnreadRoomNum && MentionRoomNum == other.MentionRoomNum && MyTaskRoomNum == other.MyTaskRoomNum && UnreadNum == other.UnreadNum && MentionNum == other.MentionNum && MyTaskNum == other.MyTaskNum;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MyStatus) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = UnreadRoomNum.GetHashCode();
                hashCode = (hashCode * 397) ^ MentionRoomNum.GetHashCode();
                hashCode = (hashCode * 397) ^ MyTaskRoomNum.GetHashCode();
                hashCode = (hashCode * 397) ^ UnreadNum.GetHashCode();
                hashCode = (hashCode * 397) ^ MentionNum.GetHashCode();
                hashCode = (hashCode * 397) ^ MyTaskNum.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(MyStatus left, MyStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MyStatus left, MyStatus right)
        {
            return !Equals(left, right);
        }
    }
}
