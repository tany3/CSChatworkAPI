/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using System.Linq;
using CSChatworkAPI;
using CSChatworkAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSChatworkAPITest
{
    public class ChatworkClientTest
    {
        public TestContext TestContext { get; set; }

        public static TestData TestData { get; set; }
        
        public void AddRoomTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var description = @"description Test @" + DateTime.Now;
            var icon_preset = @"star";
            var members_admin_ids = TestData.members_admin_ids;
            var members_member_ids = TestData.members_member_ids;
            var members_readonly_ids = TestData.members_readonly_ids;
            var name = "Test @" + DateTime.Now;
            Room actual = target.AddRoom(description, icon_preset, members_admin_ids, members_member_ids, members_readonly_ids, name);
            Assert.AreNotEqual(actual.room_id, 0);
        }
        
        public void AddTaskTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var roomId = TestData.AddTaskTestRoomId;
            var body = "Test @" + DateTime.Now;
            DateTime? limit = DateTime.Now.AddDays(7);
            var to_ids = TestData.AddTaskTestToIDs;
            var actual = target.AddTask(roomId, body, limit, to_ids);
            Assert.IsNotNull(actual.task_ids);
            Assert.AreEqual(actual.task_ids.Any(), true);
        }
        
        public void DeleteRoomTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var roomId = TestData.AddTaskTestRoomId;
            target.DeleteRoom(roomId);
        }
        
        public void GetContactsTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var actual = target.GetContacts();
            Assert.AreEqual(actual.Any(), true);
        }
        
        public void GetFileTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var roomId = TestData.GetFileTestRoomId;
            var fileId = TestData.GetFileTestFileId;
            bool createDownloadUrl = false;
            File actual = target.GetFile(roomId, fileId, createDownloadUrl);
            Assert.AreNotEqual(actual.file_id, 0);
        }
        
        public void GetFilesTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var roomId = TestData.GetFilesTestRoomId;
            var account_id = TestData.GetFilesTestAccountId;
            var actual = target.GetFiles(roomId, account_id);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }
        
        public void GetMeTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var actual = target.GetMe();
            Assert.IsNotNull(actual);
            Assert.AreNotEqual(actual.account_id, 0);
        }
        
        public void GetMessageTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var roomId = TestData.GetMessageTestRoomId;
            var messageId = TestData.GetMessageTestMessageId;
            var actual = target.GetMessage(roomId, messageId);
            Assert.IsNotNull(actual);
            Assert.AreNotEqual(actual.message_id, 0);
        }
        
        public void GetMessagesTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var roomId = TestData.GetMessagesTestRoomId;
            bool force = false;
            var actual = target.GetMessages(roomId, force);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }
        
        public void GetRoomTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var roomId = TestData.GetRoomTestRoomId;
            var actual = target.GetRoom(roomId);
            Assert.IsNotNull(actual);
            Assert.AreNotEqual(actual.room_id, 0);
        }
        
        public void GetRoomMembersTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var roomId = TestData.GetRoomMembersTestRoomId;
            var actual = target.GetRoomMembers(roomId);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }
        
        public void GetRoomsTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var actual = target.GetRooms();
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }
        
        public void GetStatusTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var actual = target.GetStatus();
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.mention_num != 0
                || actual.mention_room_num != 0
                || actual.mytask_num != 0
                || actual.mytask_room_num != 0
                || actual.unread_num != 0
                || actual.unread_room_num != 0);
        }
        
        public void GetTaskTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var roomId = TestData.GetTaskTestRoomId;
            var taskId = TestData.GetTaskTestTaskId;
            var actual = target.GetTask(roomId, taskId);
            Assert.IsNotNull(actual);
            Assert.AreNotEqual(actual.task_id, 0);
        }
        
        public void GetTasksTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var roomId = TestData.GetTasksTestRoomId;
            var account_id = TestData.GetTasksTestAccountId;
            var assigned_by_account_id = TestData.GetTasksTestAssignedByAccountId;
            string status = "done";
            var actual = target.GetTasks(roomId, account_id, assigned_by_account_id, status);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }
        
        public void GetTasksTest1()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var assigned_by_account_id = "0";
            IEnumerable<string> statuses = new List<string> {"open", "done"};
            var actual = target.GetTasks(assigned_by_account_id, statuses);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }
        
        public void LeaveRoomTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var roomId = TestData.LeaveRoomTestRoomId;
            target.LeaveRoom(roomId);
        }
        
        public void SendMessageTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var roomId = TestData.SendMessageTestRoomId;
            string messageBody = "SendMessageTest @" + DateTime.Now;
            var actual = target.SendMessage(roomId, messageBody);
            Assert.IsNotNull(actual);
            Assert.AreNotEqual(actual.message_id, 0);
        }
        
        public void UpdateRoomTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var roomId = TestData.UpdateRoomTestRoomId;
            string description = "UpdateRoomTest @" + DateTime.Now;
            string icon_preset = "star";
            string name = "UpdateRoomTest @" + DateTime.Now;
            var actual = target.UpdateRoom(roomId, description, icon_preset, name);
            Assert.IsNotNull(actual);
            Assert.AreNotEqual(actual.room_id, 0);
        }
        
        public void UpdateRoomMembersTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var roomId = TestData.UpdateRoomMembersTestRoomId;
            var members = target.GetRoomMembers(roomId);
            var members_admin_ids = members.Where(x => x.role.Equals("admin")).ToList();
            var members_member_ids = members.Where(x => x.role.Equals("member")).ToList();
            var members_readonly_ids = members.Where(x => x.role.Equals("readonly")).ToList();

            members_admin_ids.Add(new Member { account_id = TestData.UpdateRoomMembersTestAddAdminAccountId });
            members_member_ids.Add(new Member { account_id = TestData.UpdateRoomMembersTestAddMemberAccountId });
            members_readonly_ids.Add(new Member { account_id = TestData.UpdateRoomMembersTestAddReadOnlyAccountId });

            var actual = target.UpdateRoomMembers(
                roomId,
                members_admin_ids.Select(x => x.account_id),
                members_member_ids.Select(x => x.account_id),
                members_readonly_ids.Select(x => x.account_id));

            Assert.IsNotNull(actual);
            Assert.AreNotEqual(actual.admin.Any(), 0);
            Assert.AreNotEqual(actual.member.Any(), 0);
        }
    }
}
