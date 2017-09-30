using System;

namespace CSChatworkAPI.Models.Tasks
{
    /// <summary>
    /// AssignedByAccount
    /// </summary>
    public class AssignedByAccount : IEquatable<AssignedByAccount>
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
        public string AvatarImageUrl { get; set; }

        /// <summary>
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return $"account_id: {account_id}, avatar_image_url: {AvatarImageUrl}, name: {name}";
        }

        public bool Equals(AssignedByAccount other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(account_id, other.account_id) && string.Equals(name, other.name) && string.Equals(AvatarImageUrl, other.AvatarImageUrl);
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
                var hashCode = (account_id != null ? account_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
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
