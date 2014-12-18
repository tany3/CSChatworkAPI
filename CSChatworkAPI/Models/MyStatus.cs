/* See the file "LICENSE" for the full license governing this code. */

namespace CSChatworkAPI.Models
{
    public class MyStatus
    {
        public int unread_room_num { get; set; }
        public int mention_room_num { get; set; }
        public int mytask_room_num { get; set; }
        public int unread_num { get; set; }
        public int mention_num { get; set; }
        public int mytask_num { get; set; }

        public override string ToString()
        {
            return string.Format("mention_num: {0}, mention_room_num: {1}, mytask_num: {2}, mytask_room_num: {3}, unread_num: {4}, unread_room_num: {5}", mention_num, mention_room_num, mytask_num, mytask_room_num, unread_num, unread_room_num);
        }
    }
}
