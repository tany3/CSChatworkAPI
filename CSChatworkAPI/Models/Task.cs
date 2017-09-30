/* See the file "LICENSE" for the full license governing this code. */

using System;
using CSChatworkAPI.Extensions;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// Task
    /// </summary>
    public class Task : IEquatable<Task>
    {
        /// <summary>
        /// task_id
        /// </summary>
        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        /// <summary>
        /// account
        /// </summary>
        [JsonProperty("account")]
        public Account Account { get; set; }

        /// <summary>
        /// assigned_by_account
        /// </summary>
        [JsonProperty("assigned_by_account")]
        public AssignedByAccount AssignedByAccount { get; set; }

        /// <summary>
        /// message_id
        /// </summary>
        [JsonProperty("message_id")]
        public string MessageId { get; set; }

        /// <summary>
        /// body
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// limit_time
        /// </summary>
        [JsonProperty("limit_time")]
        [JsonConverter(typeof(DateTimeExtensions.UnixDateTimeConverter))]
        public DateTime LimitTime { get; set; }

        /// <summary>
        /// status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return
                $"account: {Account}, assigned_by_account: {AssignedByAccount}, body: {Body}, limit_time: {LimitTime}, message_id: {MessageId}, status: {Status}, task_id: {TaskId}";
        }

        public bool Equals(Task other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(TaskId, other.TaskId) && Equals(Account, other.Account) && Equals(AssignedByAccount, other.AssignedByAccount) && string.Equals(MessageId, other.MessageId) && string.Equals(Body, other.Body) && LimitTime.Equals(other.LimitTime) && string.Equals(Status, other.Status);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Task) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (TaskId != null ? TaskId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Account != null ? Account.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AssignedByAccount != null ? AssignedByAccount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MessageId != null ? MessageId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Body != null ? Body.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ LimitTime.GetHashCode();
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Task left, Task right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Task left, Task right)
        {
            return !Equals(left, right);
        }
    }
}
