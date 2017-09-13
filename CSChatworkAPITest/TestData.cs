/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace CSChatworkAPITest
{
    public class TestData
    {
        public string APIToken { get; set; }

        public List<string> members_admin_ids { get; set; }
        public List<string> members_member_ids { get; set; }
        public List<string> members_readonly_ids { get; set; } 

        public string AddTaskTestRoomId { get; set; }
        public List<string> AddTaskTestToIDs { get; set; }

        public string GetFileTestRoomId { get; set; }
        public string GetFileTestFileId { get; set; }

        public string GetFilesTestRoomId { get; set; }
        public string GetFilesTestAccountId { get; set; }
        
        public string GetMessageTestRoomId { get; set; }
        public string GetMessageTestMessageId { get; set; }

        public string GetMessagesTestRoomId { get; set; }

        public string GetRoomTestRoomId { get; set; }

        public string GetRoomMembersTestRoomId { get; set; }

        public string GetTaskTestRoomId { get; set; }
        public string GetTaskTestTaskId { get; set; }

        public string GetTasksTestRoomId { get; set; }
        public string GetTasksTestAccountId { get; set; }
        public string GetTasksTestAssignedByAccountId { get; set; }

        public string LeaveRoomTestRoomId { get; set; }

        public string SendMessageTestRoomId { get; set; }

        public string UpdateRoomTestRoomId { get; set; }

        public string UpdateRoomMembersTestRoomId { get; set; }
        public string UpdateRoomMembersTestAddAdminAccountId { get; set; }
        public string UpdateRoomMembersTestAddMemberAccountId { get; set; }
        public string UpdateRoomMembersTestAddReadOnlyAccountId { get; set; }

        /// <summary>
        /// Return new TestData.
        /// </summary>
        public static TestData CreateNew(string filename, string encodingName = "UTF-8")
        {
            if (string.IsNullOrWhiteSpace(filename)) { throw new ArgumentNullException(@"filename"); }
            
            string json;
            using (var sr = new StreamReader(filename, Encoding.GetEncoding(encodingName)))
            {
                json = sr.ReadToEnd();
                sr.Close();
            }
            if (string.IsNullOrWhiteSpace(json)) { throw new Exception(@"file is empty."); }

            return JsonConvert.DeserializeObject<TestData>(json);
        }
    }
}
