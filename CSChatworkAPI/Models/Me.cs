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
        /// title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// mail
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// tel_organization
        /// </summary>
        public string TelOrganization { get; set; }

        /// <summary>
        /// tel_extension
        /// </summary>
        public string TelExtension { get; set; }

        /// <summary>
        /// tel_mobile
        /// </summary>
        public string TelMobile { get; set; }

        /// <summary>
        /// skype
        /// </summary>
        public string Skype { get; set; }

        /// <summary>
        /// facebook
        /// </summary>
        public string Facebook { get; set; }

        /// <summary>
        /// twitter
        /// </summary>
        public string Twitter { get; set; }

        /// <summary>
        /// avatar_image_url
        /// </summary>
        public string AvatarImageUrl { get; set; }

        /// <summary>
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return
                $"account_id: {AccountId}, avatar_image_url: {AvatarImageUrl}, chatwork_id: {ChatworkId}, department: {Department}, facebook: {Facebook}, introduction: {Introduction}, mail: {Mail}, name: {Name}, organization_id: {OrganizationId}, organization_name: {OrganizationName}, room_id: {RoomId}, skype: {Skype}, tel_extension: {TelExtension}, tel_mobile: {TelMobile}, tel_organization: {TelOrganization}, title: {Title}, twitter: {Twitter}, url: {Url}";
        }

        public bool Equals(Me other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(AccountId, other.AccountId) && string.Equals(RoomId, other.RoomId) && string.Equals(Name, other.Name) && string.Equals(ChatworkId, other.ChatworkId) && string.Equals(OrganizationId, other.OrganizationId) && string.Equals(OrganizationName, other.OrganizationName) && string.Equals(Department, other.Department) && string.Equals(Title, other.Title) && string.Equals(Url, other.Url) && string.Equals(Introduction, other.Introduction) && string.Equals(Mail, other.Mail) && string.Equals(TelOrganization, other.TelOrganization) && string.Equals(TelExtension, other.TelExtension) && string.Equals(TelMobile, other.TelMobile) && string.Equals(Skype, other.Skype) && string.Equals(Facebook, other.Facebook) && string.Equals(Twitter, other.Twitter) && string.Equals(AvatarImageUrl, other.AvatarImageUrl);
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
                var hashCode = (AccountId != null ? AccountId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (RoomId != null ? RoomId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ChatworkId != null ? ChatworkId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OrganizationId != null ? OrganizationId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OrganizationName != null ? OrganizationName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Department != null ? Department.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Url != null ? Url.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Introduction != null ? Introduction.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Mail != null ? Mail.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TelOrganization != null ? TelOrganization.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TelExtension != null ? TelExtension.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TelMobile != null ? TelMobile.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Skype != null ? Skype.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Facebook != null ? Facebook.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Twitter != null ? Twitter.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AvatarImageUrl != null ? AvatarImageUrl.GetHashCode() : 0);
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
