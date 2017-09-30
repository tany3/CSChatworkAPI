using System;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// AssignedByAccount
    /// </summary>
    public class AssignedByAccount : IEquatable<AssignedByAccount>
    {
        /// <summary>
        /// account_id
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// avatar_image_url
        /// </summary>
        [JsonProperty("avatar_image_url")]
        public string AvatarImageUrl { get; set; }

        /// <summary>
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return $"account_id: {AccountId}, avatar_image_url: {AvatarImageUrl}, name: {Name}";
        }

        public bool Equals(AssignedByAccount other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(AccountId, other.AccountId) && string.Equals(Name, other.Name) && string.Equals(AvatarImageUrl, other.AvatarImageUrl);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AssignedByAccount)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (AccountId != null ? AccountId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AvatarImageUrl != null ? AvatarImageUrl.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(AssignedByAccount left, AssignedByAccount right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AssignedByAccount left, AssignedByAccount right)
        {
            return !Equals(left, right);
        }
    }
}
