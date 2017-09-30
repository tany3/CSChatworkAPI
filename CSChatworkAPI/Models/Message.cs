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
    public class Message
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

        protected bool Equals(Message other)
        {
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
    /// Account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// account_id
        /// </summary>
        public string account_id { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// avatar_image_url
        /// </summary>
        public string avatar_image_url { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("account_id: {0}, avatar_image_url: {1}, name: {2}", account_id, avatar_image_url, name);
        }

        protected bool Equals(Account other)
        {
            return string.Equals(account_id, other.account_id) && string.Equals(name, other.name) && string.Equals(avatar_image_url, other.avatar_image_url);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Account) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (account_id != null ? account_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (avatar_image_url != null ? avatar_image_url.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Account left, Account right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Account left, Account right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// ResponseMessage
    /// </summary>
    public class ResponseMessage
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
    }

    /// <summary>
    /// ResponseTaskIds
    /// </summary>
    public class ResponseTaskIds
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
    }
}
