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
        public string account_id { get; set; }

        /// <summary>
        /// role
        /// </summary>
        public string role { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// chatwork_id
        /// </summary>
        public string chatwork_id { get; set; }

        /// <summary>
        /// organization_id
        /// </summary>
        public string organization_id { get; set; }

        /// <summary>
        /// organization_name
        /// </summary>
        public string organization_name { get; set; }

        /// <summary>
        /// department
        /// </summary>
        public string department { get; set; }

        /// <summary>
        /// avatar_image_url
        /// </summary>
        public string avatar_image_url { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("account_id: {0}, avatar_image_url: {1}, chatwork_id: {2}, department: {3}, name: {4}, organization_id: {5}, organization_name: {6}, role: {7}", account_id, avatar_image_url, chatwork_id, department, name, organization_id, organization_name, role);
        }

        public bool Equals(Member other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(account_id, other.account_id) && string.Equals(role, other.role) && string.Equals(name, other.name) && string.Equals(chatwork_id, other.chatwork_id) && string.Equals(organization_id, other.organization_id) && string.Equals(organization_name, other.organization_name) && string.Equals(department, other.department) && string.Equals(avatar_image_url, other.avatar_image_url);
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
                var hashCode = (account_id != null ? account_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (role != null ? role.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (chatwork_id != null ? chatwork_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (organization_id != null ? organization_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (organization_name != null ? organization_name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (department != null ? department.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (avatar_image_url != null ? avatar_image_url.GetHashCode() : 0);
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
        public List<string> admin { get; set; }

        /// <summary>
        /// member
        /// </summary>
        public List<string> member { get; set; }

        /// <summary>
        /// @readonly
        /// </summary>
        public List<string> @readonly { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("admin: {0}, member: {1}, readonly: {2}", admin, member, @readonly);
        }

        public bool Equals(MemberRoles other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(admin, other.admin) && Equals(member, other.member) && Equals(@readonly, other.@readonly);
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
                var hashCode = (admin != null ? admin.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (member != null ? member.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (@readonly != null ? @readonly.GetHashCode() : 0);
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
