/* See the file "LICENSE" for the full license governing this code. */

using System;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// Contact
    /// </summary>
    public class Contact : IEquatable<Contact>
    {
        /// <summary>
        /// account_id
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// room_id
        /// </summary>
        public string RoomId { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// chatwork_id
        /// </summary>
        public string ChatworkId { get; set; }

        /// <summary>
        /// organization_id
        /// </summary>
        public string OrganizationId { get; set; }

        /// <summary>
        /// organization_name
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// department
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// avatar_image_url
        /// </summary>
        public string AvatarImageUrl { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return
                $"account_id: {AccountId}, avatar_image_url: {AvatarImageUrl}, chatwork_id: {ChatworkId}, department: {Department}, name: {Name}, organization_id: {OrganizationId}, organization_name: {OrganizationName}, room_id: {RoomId}";
        }

        public bool Equals(Contact other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(AccountId, other.AccountId) && string.Equals(RoomId, other.RoomId) && string.Equals(Name, other.Name) && string.Equals(ChatworkId, other.ChatworkId) && string.Equals(OrganizationId, other.OrganizationId) && string.Equals(OrganizationName, other.OrganizationName) && string.Equals(Department, other.Department) && string.Equals(AvatarImageUrl, other.AvatarImageUrl);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Contact) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (AccountId != null ? AccountId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (RoomId != null ? RoomId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ChatworkId != null ? ChatworkId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OrganizationId != null ? OrganizationId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OrganizationName != null ? OrganizationName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Department != null ? Department.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AvatarImageUrl != null ? AvatarImageUrl.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Contact left, Contact right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Contact left, Contact right)
        {
            return !Equals(left, right);
        }
    }
}
