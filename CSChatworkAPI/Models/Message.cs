/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// Message
    /// </summary>
    public class Message : IEquatable<Message>
    {
        /// <summary>
        /// message_id
        /// </summary>
        public string message_id { get; set; }

        /// <summary>
        /// account
        /// </summary>
        public Account account { get; set; }

        /// <summary>
        /// body
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// send_time
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime send_time { get; set; }

        /// <summary>
        /// update_time
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime update_time { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("account: {0}, body: {1}, message_id: {2}, send_time: {3}, update_time: {4}", account, body, message_id, send_time, update_time);
        }

        public bool Equals(Message other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(message_id, other.message_id) && Equals(account, other.account) && string.Equals(body, other.body) && send_time.Equals(other.send_time) && update_time.Equals(other.update_time);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Message) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (message_id != null ? message_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (account != null ? account.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (body != null ? body.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ send_time.GetHashCode();
                hashCode = (hashCode * 397) ^ update_time.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Message left, Message right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Message left, Message right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// ResponseMessage
    /// </summary>
    public class ResponseMessage : IEquatable<ResponseMessage>
    {
        /// <summary>
        /// message_id
        /// </summary>
        public string message_id { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("message_id: {0}", message_id);
        }

        public bool Equals(ResponseMessage other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(message_id, other.message_id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ResponseMessage) obj);
        }

        public override int GetHashCode()
        {
            return (message_id != null ? message_id.GetHashCode() : 0);
        }

        public static bool operator ==(ResponseMessage left, ResponseMessage right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ResponseMessage left, ResponseMessage right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// ResponseTaskIds
    /// </summary>
    public class ResponseTaskIds : IEquatable<ResponseTaskIds>
    {
        /// <summary>
        /// task_ids
        /// </summary>
        public List<string> task_ids { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("task_ids: {0}", task_ids);
        }

        public bool Equals(ResponseTaskIds other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(task_ids, other.task_ids);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ResponseTaskIds) obj);
        }

        public override int GetHashCode()
        {
            return (task_ids != null ? task_ids.GetHashCode() : 0);
        }

        public static bool operator ==(ResponseTaskIds left, ResponseTaskIds right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ResponseTaskIds left, ResponseTaskIds right)
        {
            return !Equals(left, right);
        }
    }
}
