/* See the file "LICENSE" for the full license governing this code. */

using System;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    public class File
    {
        public int file_id { get; set; }
        public Account account { get; set; }
        public int message_id { get; set; }
        public string filename { get; set; }
        public int filesize { get; set; }
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime upload_time { get; set; }

        public override string ToString()
        {
            return string.Format("account: {0}, file_id: {1}, filename: {2}, filesize: {3}, message_id: {4}, upload_time: {5}", account, file_id, filename, filesize, message_id, upload_time);
        }
    }
}
