/* See the file "LICENSE" for the full license governing this code. */

using System;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// Me
    /// </summary>
    public class Me : IEquatable<Me>
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
        /// title
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string introduction { get; set; }

        /// <summary>
        /// mail
        /// </summary>
        public string mail { get; set; }

        /// <summary>
        /// tel_organization
        /// </summary>
        public string tel_organization { get; set; }

        /// <summary>
        /// tel_extension
        /// </summary>
        public string tel_extension { get; set; }

        /// <summary>
        /// tel_mobile
        /// </summary>
        public string tel_mobile { get; set; }

        /// <summary>
        /// skype
        /// </summary>
        public string skype { get; set; }

        /// <summary>
        /// facebook
        /// </summary>
        public string facebook { get; set; }

        /// <summary>
        /// twitter
        /// </summary>
        public string twitter { get; set; }

        /// <summary>
        /// avatar_image_url
        /// </summary>
        public string avatar_image_url { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("account_id: {0}, avatar_image_url: {1}, chatwork_id: {2}, department: {3}, facebook: {4}, introduction: {5}, mail: {6}, name: {7}, organization_id: {8}, organization_name: {9}, room_id: {10}, skype: {11}, tel_extension: {12}, tel_mobile: {13}, tel_organization: {14}, title: {15}, twitter: {16}, url: {17}", account_id, avatar_image_url, chatwork_id, department, facebook, introduction, mail, name, organization_id, organization_name, room_id, skype, tel_extension, tel_mobile, tel_organization, title, twitter, url);
        }

        public bool Equals(Me other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(account_id, other.account_id) && string.Equals(room_id, other.room_id) && string.Equals(name, other.name) && string.Equals(chatwork_id, other.chatwork_id) && string.Equals(organization_id, other.organization_id) && string.Equals(organization_name, other.organization_name) && string.Equals(department, other.department) && string.Equals(title, other.title) && string.Equals(url, other.url) && string.Equals(introduction, other.introduction) && string.Equals(mail, other.mail) && string.Equals(tel_organization, other.tel_organization) && string.Equals(tel_extension, other.tel_extension) && string.Equals(tel_mobile, other.tel_mobile) && string.Equals(skype, other.skype) && string.Equals(facebook, other.facebook) && string.Equals(twitter, other.twitter) && string.Equals(avatar_image_url, other.avatar_image_url);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Me) obj);
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
                hashCode = (hashCode * 397) ^ (title != null ? title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (url != null ? url.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (introduction != null ? introduction.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (mail != null ? mail.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (tel_organization != null ? tel_organization.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (tel_extension != null ? tel_extension.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (tel_mobile != null ? tel_mobile.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (skype != null ? skype.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (facebook != null ? facebook.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (twitter != null ? twitter.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (avatar_image_url != null ? avatar_image_url.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Me left, Me right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Me left, Me right)
        {
            return !Equals(left, right);
        }
    }
}
