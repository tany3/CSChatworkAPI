/* See the file "LICENSE" for the full license governing this code. */

namespace CSChatworkAPI.Models
{
    public class Me
    {
        public int account_id { get; set; }
        public int room_id { get; set; }
        public string name { get; set; }
        public string chatwork_id { get; set; }
        public int organization_id { get; set; }
        public string organization_name { get; set; }
        public string department { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string introduction { get; set; }
        public string mail { get; set; }
        public string tel_organization { get; set; }
        public string tel_extension { get; set; }
        public string tel_mobile { get; set; }
        public string skype { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string avatar_image_url { get; set; }

        public override string ToString()
        {
            return string.Format("account_id: {0}, avatar_image_url: {1}, chatwork_id: {2}, department: {3}, facebook: {4}, introduction: {5}, mail: {6}, name: {7}, organization_id: {8}, organization_name: {9}, room_id: {10}, skype: {11}, tel_extension: {12}, tel_mobile: {13}, tel_organization: {14}, title: {15}, twitter: {16}, url: {17}", account_id, avatar_image_url, chatwork_id, department, facebook, introduction, mail, name, organization_id, organization_name, room_id, skype, tel_extension, tel_mobile, tel_organization, title, twitter, url);
        }
    }
}
