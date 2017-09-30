/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// role
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }

        /// <summary>
        /// name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// chatwork_id
        /// </summary>
        [JsonProperty("chatwork_id")]
        public string ChatworkId { get; set; }

        /// <summary>
        /// organization_id
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }

        /// <summary>
        /// organization_name
        /// </summary>
        [JsonProperty("organization_name")]
        public string OrganizationName { get; set; }

        /// <summary>
        /// department
        /// </summary>
        [JsonProperty("department")]
        public string Department { get; set; }

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
            return
                $"account_id: {AccountId}, avatar_image_url: {AvatarImageUrl}, chatwork_id: {ChatworkId}, department: {Department}, name: {Name}, organization_id: {OrganizationId}, organization_name: {OrganizationName}, role: {Role}";
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
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return $"admin: {Admin}, member: {Member}, readonly: {Readonly}";
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
