/* See the file "LICENSE" for the full license governing this code. */
using System.Collections.Generic;

namespace CSChatworkAPI.Models
{
    public class Member
    {
        public int account_id { get; set; }
        public string role { get; set; }
        public string name { get; set; }
        public string chatwork_id { get; set; }
        public int organization_id { get; set; }
        public string organization_name { get; set; }
        public string department { get; set; }
        public string avatar_image_url { get; set; }

        public override string ToString()
        {
            return string.Format("account_id: {0}, avatar_image_url: {1}, chatwork_id: {2}, department: {3}, name: {4}, organization_id: {5}, organization_name: {6}, role: {7}", account_id, avatar_image_url, chatwork_id, department, name, organization_id, organization_name, role);
        }
    }

    public class MemberRoles
    {
        public List<int> admin { get; set; }
        public List<int> member { get; set; }
        public List<int> @readonly { get; set; }

        public override string ToString()
        {
            return string.Format("admin: {0}, member: {1}, readonly: {2}", admin, member, @readonly);
        }
    }
}
