/* See the file "LICENSE" for the full license governing this code. */

using System;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// File
    /// </summary>
    public class File
    {
        /// <summary>
        /// file_id
        /// </summary>
        public string file_id { get; set; }

        /// <summary>
        /// account
        /// </summary>
        public Account account { get; set; }

        /// <summary>
        /// account
        /// </summary>
        public string message_id { get; set; }

        /// <summary>
        /// filename
        /// </summary>
        public string filename { get; set; }

        /// <summary>
        /// filesize
        /// </summary>
        public int filesize { get; set; }

        /// <summary>
        /// upload_time
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime upload_time { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("account: {0}, file_id: {1}, filename: {2}, filesize: {3}, message_id: {4}, upload_time: {5}", account, file_id, filename, filesize, message_id, upload_time);
        }
    }
}
