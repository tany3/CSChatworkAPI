/* See the file "LICENSE" for the full license governing this code. */

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// Me
    /// </summary>
    public class Me
    {
        /// <summary>
        /// account_id
        /// </summary>
        public int account_id { get; set; }

        /// <summary>
        /// room_id
        /// </summary>
        public int room_id { get; set; }

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
    }
}
