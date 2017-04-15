/* See the file "LICENSE" for the full license governing this code. */
using System.Collections.Generic;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// Member
    /// </summary>
    public class Member
    {
        /// <summary>
        /// account_id
        /// </summary>
        public int account_id { get; set; }

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
        public int organization_id { get; set; }

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
    }

    /// <summary>
    /// MemberRoles
    /// </summary>
    public class MemberRoles
    {
        /// <summary>
        /// admin
        /// </summary>
        public List<int> admin { get; set; }

        /// <summary>
        /// member
        /// </summary>
        public List<int> member { get; set; }

        /// <summary>
        /// @readonly
        /// </summary>
        public List<int> @readonly { get; set; }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("admin: {0}, member: {1}, readonly: {2}", admin, member, @readonly);
        }
    }
}
