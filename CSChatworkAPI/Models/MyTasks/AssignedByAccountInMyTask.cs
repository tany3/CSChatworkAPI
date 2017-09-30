using System;

namespace CSChatworkAPI.Models.MyTasks
{
    /// <summary>
    /// AssignedByAccount
    /// </summary>
    public class AssignedByAccountInMyTask : IEquatable<AssignedByAccountInMyTask>
    {
        /// <summary>
        /// account_id
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// avatar_image_url
        /// </summary>
        public string AvatarImageUrl { get; set; }

        /// <summary>
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return $"account_id: {AccountId}, avatar_image_url: {AvatarImageUrl}, name: {Name}";
        }

        public bool Equals(AssignedByAccountInMyTask other)
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
            return Equals((AssignedByAccountInMyTask)obj);
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

        public static bool operator ==(AssignedByAccountInMyTask left, AssignedByAccountInMyTask right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AssignedByAccountInMyTask left, AssignedByAccountInMyTask right)
        {
            return !Equals(left, right);
        }
    }
}
