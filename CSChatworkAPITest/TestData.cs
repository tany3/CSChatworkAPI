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

        public int AddTaskTestRID { get; set; }
        public List<int> AddTaskTestToIDs { get; set; }

        public int GetFileTestRoomID { get; set; }
        public int GetFileTestFileID { get; set; }

        public int GetFilesTestRoomID { get; set; }
        public int GetFilesTestAccountID { get; set; }
        
        public int GetMessageTestRoomID { get; set; }
        public int GetMessageTestMessageID { get; set; }

        public int GetMessagesTestRoomID { get; set; }

        public int GetRoomTestRoomId { get; set; }

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
