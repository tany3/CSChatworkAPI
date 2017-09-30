using System;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// Account
    /// </summary>
    public class Account : IEquatable<Account>
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
        public string avatar_image_url { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("account_id: {0}, avatar_image_url: {1}, name: {2}", account_id, avatar_image_url, name);
        }

        public bool Equals(Account other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(account_id, other.account_id) && string.Equals(name, other.name) && string.Equals(avatar_image_url, other.avatar_image_url);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Account)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (account_id != null ? account_id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (avatar_image_url != null ? avatar_image_url.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Account left, Account right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Account left, Account right)
        {
            return !Equals(left, right);
        }
    }
}
