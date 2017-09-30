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
        public string account_id { get; set; }

        /// <summary>
        /// room_id
        /// </summary>
        public string room_id { get; set; }

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
            return string.Format("account_id: {0}, avatar_image_url: {1}, chatwork_id: {2}, department: {3}, name: {4}, organization_id: {5}, organization_name: {6}, room_id: {7}", account_id, avatar_image_url, chatwork_id, department, name, organization_id, organization_name, room_id);
        }

        public bool Equals(Contact other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(account_id, other.account_id) && string.Equals(room_id, other.room_id) && string.Equals(name, other.name) && string.Equals(chatwork_id, other.chatwork_id) && string.Equals(organization_id, other.organization_id) && string.Equals(organization_name, other.organization_name) && string.Equals(department, other.department) && string.Equals(avatar_image_url, other.avatar_image_url);
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
                var hashCode = (account_id != null ? account_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (room_id != null ? room_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (chatwork_id != null ? chatwork_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (organization_id != null ? organization_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (organization_name != null ? organization_name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (department != null ? department.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (avatar_image_url != null ? avatar_image_url.GetHashCode() : 0);
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
