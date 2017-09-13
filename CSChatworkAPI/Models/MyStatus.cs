/* See the file "LICENSE" for the full license governing this code. */

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// MyStatus
    /// </summary>
    public class MyStatus
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
    }
}
