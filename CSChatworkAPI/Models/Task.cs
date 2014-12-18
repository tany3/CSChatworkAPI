/* See the file "LICENSE" for the full license governing this code. */

namespace CSChatworkAPI.Models
{
    public class Task
    {
        public int task_id { get; set; }
        public Account account { get; set; }
        public AssignedByAccount assigned_by_account { get; set; }
        public int message_id { get; set; }
        public string body { get; set; }
        public int limit_time { get; set; }
        public string status { get; set; }
    }

    public class AssignedByAccount
    {
        public int account_id { get; set; }
        public string name { get; set; }
        public string avatar_image_url { get; set; }
    }
}
