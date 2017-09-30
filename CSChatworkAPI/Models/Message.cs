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
        [JsonProperty("message_id")]
        public string MessageId { get; set; }

        /// <summary>
        /// account
        /// </summary>
        [JsonProperty("account")]
        public Account Account { get; set; }

        /// <summary>
        /// body
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// send_time
        /// </summary>
        [JsonProperty("send_time")]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime SendTime { get; set; }

        /// <summary>
        /// update_time
        /// </summary>
        [JsonProperty("update_time")]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return
                $"account: {Account}, body: {Body}, message_id: {MessageId}, send_time: {SendTime}, update_time: {UpdateTime}";
        }

        public bool Equals(Message other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(MessageId, other.MessageId) && Equals(Account, other.Account) && string.Equals(Body, other.Body) && SendTime.Equals(other.SendTime) && UpdateTime.Equals(other.UpdateTime);
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
                var hashCode = (MessageId != null ? MessageId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Account != null ? Account.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Body != null ? Body.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ SendTime.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdateTime.GetHashCode();
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
        public string MessageId { get; set; }

        /// <summary>
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return $"message_id: {MessageId}";
        }

        public bool Equals(ResponseMessage other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(MessageId, other.MessageId);
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
            return (MessageId != null ? MessageId.GetHashCode() : 0);
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
        public List<string> TaskIds { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("task_ids: {0}", TaskIds);
        }

        public bool Equals(ResponseTaskIds other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(TaskIds, other.TaskIds);
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
            return (TaskIds != null ? TaskIds.GetHashCode() : 0);
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
