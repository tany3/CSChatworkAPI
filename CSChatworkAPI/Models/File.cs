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
        public string FileId { get; set; }

        /// <summary>
        /// account
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// account
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// filename
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// filesize
        /// </summary>
        public int Filesize { get; set; }

        /// <summary>
        /// upload_time
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime UploadTime { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("account: {0}, file_id: {1}, filename: {2}, filesize: {3}, message_id: {4}, upload_time: {5}", Account, FileId, Filename, Filesize, MessageId, UploadTime);
        }

        public bool Equals(File other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(FileId, other.FileId) && Equals(Account, other.Account) && string.Equals(MessageId, other.MessageId) && string.Equals(Filename, other.Filename) && Filesize == other.Filesize && UploadTime.Equals(other.UploadTime);
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
                var hashCode = (FileId != null ? FileId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Account != null ? Account.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MessageId != null ? MessageId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Filename != null ? Filename.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Filesize;
                hashCode = (hashCode * 397) ^ UploadTime.GetHashCode();
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
