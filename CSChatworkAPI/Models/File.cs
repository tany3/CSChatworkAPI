/* See the file "LICENSE" for the full license governing this code. */

using System;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// File
    /// </summary>
    public class File : IEquatable<File>
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

        public bool Equals(File other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(file_id, other.file_id) && Equals(account, other.account) && string.Equals(message_id, other.message_id) && string.Equals(filename, other.filename) && filesize == other.filesize && upload_time.Equals(other.upload_time);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((File) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (file_id != null ? file_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (account != null ? account.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (message_id != null ? message_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (filename != null ? filename.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ filesize;
                hashCode = (hashCode * 397) ^ upload_time.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(File left, File right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(File left, File right)
        {
            return !Equals(left, right);
        }
    }
}
