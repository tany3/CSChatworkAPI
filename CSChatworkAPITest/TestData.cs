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

        public List<int> members_admin_ids { get; set; }
        public List<int> members_member_ids { get; set; }
        public List<int> members_readonly_ids { get; set; } 

        public int AddTaskTestRoomId { get; set; }
        public List<int> AddTaskTestToIDs { get; set; }

        public int GetFileTestRoomId { get; set; }
        public int GetFileTestFileId { get; set; }

        public int GetFilesTestRoomId { get; set; }
        public int GetFilesTestAccountId { get; set; }
        
        public int GetMessageTestRoomId { get; set; }
        public int GetMessageTestMessageId { get; set; }

        public int GetMessagesTestRoomId { get; set; }

        public int GetRoomTestRoomId { get; set; }

        public int GetRoomMembersTestRoomId { get; set; }

        public int GetTaskTestRoomId { get; set; }
        public int GetTaskTestTaskId { get; set; }

        public int GetTasksTestRoomId { get; set; }
        public int GetTasksTestAccountId { get; set; }
        public int GetTasksTestAssignedByAccountId { get; set; }

        public int LeaveRoomTestRoomId { get; set; }

        public int SendMessageTestRoomId { get; set; }

        public int UpdateRoomTestRoomId { get; set; }

        public int UpdateRoomMembersTestRoomId { get; set; }
        public int UpdateRoomMembersTestAddAdminAccountId { get; set; }
        public int UpdateRoomMembersTestAddMemberAccountId { get; set; }
        public int UpdateRoomMembersTestAddReadOnlyAccountId { get; set; }

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
