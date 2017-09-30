/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// Member
    /// </summary>
    public class Member : IEquatable<Member>
    {
        /// <summary>
        /// account_id
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// role
        /// </summary>
        public string Role { get; set; }

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
            return string.Format("account_id: {0}, avatar_image_url: {1}, chatwork_id: {2}, department: {3}, name: {4}, organization_id: {5}, organization_name: {6}, role: {7}", AccountId, AvatarImageUrl, ChatworkId, Department, Name, OrganizationId, OrganizationName, Role);
        }

        public bool Equals(Member other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(AccountId, other.AccountId) && string.Equals(Role, other.Role) && string.Equals(Name, other.Name) && string.Equals(ChatworkId, other.ChatworkId) && string.Equals(OrganizationId, other.OrganizationId) && string.Equals(OrganizationName, other.OrganizationName) && string.Equals(Department, other.Department) && string.Equals(AvatarImageUrl, other.AvatarImageUrl);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Member) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (AccountId != null ? AccountId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Role != null ? Role.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ChatworkId != null ? ChatworkId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OrganizationId != null ? OrganizationId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OrganizationName != null ? OrganizationName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Department != null ? Department.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AvatarImageUrl != null ? AvatarImageUrl.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Member left, Member right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Member left, Member right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// MemberRoles
    /// </summary>
    public class MemberRoles : IEquatable<MemberRoles>
    {
        /// <summary>
        /// admin
        /// </summary>
        public List<string> Admin { get; set; }

        /// <summary>
        /// member
        /// </summary>
        public List<string> Member { get; set; }

        /// <summary>
        /// @readonly
        /// </summary>
        public List<string> Readonly { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("admin: {0}, member: {1}, readonly: {2}", Admin, Member, Readonly);
        }

        public bool Equals(MemberRoles other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Admin, other.Admin) && Equals(Member, other.Member) && Equals(Readonly, other.Readonly);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MemberRoles) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Admin != null ? Admin.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Member != null ? Member.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Readonly != null ? Readonly.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(MemberRoles left, MemberRoles right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MemberRoles left, MemberRoles right)
        {
            return !Equals(left, right);
        }
    }
}
