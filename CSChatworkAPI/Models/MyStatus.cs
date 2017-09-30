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
        public long unread_room_num { get; set; }

        /// <summary>
        /// mention_room_num
        /// </summary>
        public long mention_room_num { get; set; }

        /// <summary>
        /// mytask_room_num
        /// </summary>
        public long mytask_room_num { get; set; }

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
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("mention_num: {0}, mention_room_num: {1}, mytask_num: {2}, mytask_room_num: {3}, unread_num: {4}, unread_room_num: {5}", mention_num, mention_room_num, mytask_num, mytask_room_num, unread_num, unread_room_num);
        }

        public bool Equals(MyStatus other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return unread_room_num == other.unread_room_num && mention_room_num == other.mention_room_num && mytask_room_num == other.mytask_room_num && unread_num == other.unread_num && mention_num == other.mention_num && mytask_num == other.mytask_num;
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
                var hashCode = unread_room_num.GetHashCode();
                hashCode = (hashCode * 397) ^ mention_room_num.GetHashCode();
                hashCode = (hashCode * 397) ^ mytask_room_num.GetHashCode();
                hashCode = (hashCode * 397) ^ unread_num.GetHashCode();
                hashCode = (hashCode * 397) ^ mention_num.GetHashCode();
                hashCode = (hashCode * 397) ^ mytask_num.GetHashCode();
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
