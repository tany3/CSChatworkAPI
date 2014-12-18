/* See the file "LICENSE" for the full license governing this code. */

namespace CSChatworkAPI.Models
{
    public class Contact
    {
        public int account_id { get; set; }
        public int room_id { get; set; }
        public string name { get; set; }
        public string chatwork_id { get; set; }
        public int organization_id { get; set; }
        public string organization_name { get; set; }
        public string department { get; set; }
        public string avatar_image_url { get; set; }

        public override string ToString()
        {
            return string.Format("account_id: {0}, avatar_image_url: {1}, chatwork_id: {2}, department: {3}, name: {4}, organization_id: {5}, organization_name: {6}, room_id: {7}", account_id, avatar_image_url, chatwork_id, department, name, organization_id, organization_name, room_id);
        }
    }
}
