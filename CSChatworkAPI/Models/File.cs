/* See the file "LICENSE" for the full license governing this code. */

namespace CSChatworkAPI.Models
{
    public class File
    {
        public int file_id { get; set; }
        public Account account { get; set; }
        public int message_id { get; set; }
        public string filename { get; set; }
        public int filesize { get; set; }
        public int upload_time { get; set; }
    }
}
