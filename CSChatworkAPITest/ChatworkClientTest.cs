﻿/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using System.Linq;
using CSChatworkAPI;
using CSChatworkAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSChatworkAPITest
{
    /// <summary>
    ///ChatworkClientTest のテスト クラスです。すべての
    ///ChatworkClientTest 単体テストをここに含めます
    ///</summary>
    [TestClass]
    public class ChatworkClientTest
    {
        /// <summary>
        ///現在のテストの実行についての情報および機能を
        ///提供するテスト コンテキストを取得または設定します。
        ///</summary>
        public TestContext TestContext { get; set; }

        public static TestData TestData { get; set; }

        #region 追加のテスト属性
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestData = TestData.CreateNew("ChatworkClientTestData.json");
        }
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion



        #region ConstructorTest
        /// <summary>
        ///ChatworkClient コンストラクター のテスト1
        ///</summary>
        [TestMethod]
        public void ChatworkClientConstructorTest1()
        {
            try
            {
                var target = new ChatworkClient(null);
            }
            catch (ArgumentNullException)
            {
                return;
            }
            Assert.Fail("unexpected exception.");
        }

        /// <summary>
        ///ChatworkClient コンストラクター のテスト2
        ///</summary>
        [TestMethod]
        public void ChatworkClientConstructorTest2()
        {
            try
            {
                var target = new ChatworkClient(TestData.APIToken);
            }
            catch (ArgumentNullException)
            {
                Assert.Fail("unexpected exception.");
            }
        }
        #endregion ConstructorTest



        /// <summary>
        ///AddRoom のテスト
        ///</summary>
        [TestMethod]
        public void AddRoomTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            string description = @"description Test @" + DateTime.Now;
            string icon_preset = @"star";
            var members_admin_ids = TestData.members_admin_ids;
            var members_member_ids = TestData.members_member_ids;
            var members_readonly_ids = TestData.members_readonly_ids;
            string name = "Test @" + DateTime.Now;
            Room actual = target.AddRoom(description, icon_preset, members_admin_ids, members_member_ids, members_readonly_ids, name);
            Assert.AreNotEqual(actual.room_id, 0);
        }

        /// <summary>
        ///AddTask のテスト
        ///</summary>
        [TestMethod]
        public void AddTaskTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int roomId = TestData.AddTaskTestRoomId;
            string body = "Test @" + DateTime.Now;
            DateTime? limit = DateTime.Now.AddDays(7);
            var to_ids = TestData.AddTaskTestToIDs;
            var actual = target.AddTask(roomId, body, limit, to_ids);
            Assert.IsNotNull(actual.task_ids);
            Assert.AreEqual(actual.task_ids.Any(), true);
        }

        /// <summary>
        ///DeleteRoom のテスト
        ///</summary>
        [TestMethod]
        public void DeleteRoomTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int roomId = TestData.AddTaskTestRoomId;
            target.DeleteRoom(roomId);
        }

        /// <summary>
        ///GetContacts のテスト
        ///</summary>
        [TestMethod]
        public void GetContactsTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var actual = target.GetContacts();
            Assert.AreEqual(actual.Any(), true);
        }

        /// <summary>
        ///GetFile のテスト
        ///</summary>
        [TestMethod]
        public void GetFileTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int roomId = TestData.GetFileTestRoomId;
            int fileId = TestData.GetFileTestFileId;
            bool createDownloadUrl = false;
            File actual = target.GetFile(roomId, fileId, createDownloadUrl);
            Assert.AreNotEqual(actual.file_id, 0);
        }

        /// <summary>
        ///GetFiles のテスト
        ///</summary>
        [TestMethod]
        public void GetFilesTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int roomId = TestData.GetFilesTestRoomId;
            int account_id = TestData.GetFilesTestAccountId;
            var actual = target.GetFiles(roomId, account_id);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }

        /// <summary>
        ///GetMe のテスト
        ///</summary>
        [TestMethod]
        public void GetMeTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var actual = target.GetMe();
            Assert.IsNotNull(actual);
            Assert.AreNotEqual(actual.account_id, 0);
        }

        /// <summary>
        ///GetMessage のテスト
        ///</summary>
        [TestMethod]
        public void GetMessageTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int roomId = TestData.GetMessageTestRoomId;
            int messageId = TestData.GetMessageTestMessageId;
            var actual = target.GetMessage(roomId, messageId);
            Assert.IsNotNull(actual);
            Assert.AreNotEqual(actual.message_id, 0);
        }

        /// <summary>
        ///GetMessages のテスト
        ///</summary>
        [TestMethod]
        public void GetMessagesTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int roomId = TestData.GetMessagesTestRoomId;
            bool force = false;
            var actual = target.GetMessages(roomId, force);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }

        /// <summary>
        ///GetRoom のテスト
        ///</summary>
        [TestMethod]
        public void GetRoomTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int roomId = TestData.GetRoomTestRoomId;
            var actual = target.GetRoom(roomId);
            Assert.IsNotNull(actual);
            Assert.AreNotEqual(actual.room_id, 0);
        }

        /// <summary>
        ///GetRoomMembers のテスト
        ///</summary>
        [TestMethod]
        public void GetRoomMembersTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int roomId = TestData.GetRoomMembersTestRoomId;
            var actual = target.GetRoomMembers(roomId);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }

        /// <summary>
        ///GetRooms のテスト
        ///</summary>
        [TestMethod]
        public void GetRoomsTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            var actual = target.GetRooms();
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }

        /// <summary>
        ///GetStatus のテスト
        ///</summary>
        [TestMethod]
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

        /// <summary>
        ///GetTask のテスト
        ///</summary>
        [TestMethod]
        public void GetTaskTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int roomId = TestData.GetTaskTestRoomId;
            int taskId = TestData.GetTaskTestTaskId;
            var actual = target.GetTask(roomId, taskId);
            Assert.IsNotNull(actual);
            Assert.AreNotEqual(actual.task_id, 0);
        }

        /// <summary>
        ///GetTasks のテスト
        ///</summary>
        [TestMethod]
        public void GetTasksTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int roomId = TestData.GetTasksTestRoomId;
            int account_id = TestData.GetTasksTestAccountId;
            int assigned_by_account_id = TestData.GetTasksTestAssignedByAccountId;
            string status = "done";
            var actual = target.GetTasks(roomId, account_id, assigned_by_account_id, status);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }

        /// <summary>
        ///GetTasks のテスト
        ///</summary>
        [TestMethod]
        public void GetTasksTest1()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int assigned_by_account_id = 0;
            IEnumerable<string> statuses = new List<string> {"open", "done"};
            var actual = target.GetTasks(assigned_by_account_id, statuses);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }

        /// <summary>
        ///LeaveRoom のテスト
        ///</summary>
        [TestMethod]
        public void LeaveRoomTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int roomId = TestData.LeaveRoomTestRoomId;
            target.LeaveRoom(roomId);
        }

        /// <summary>
        ///SendMessage のテスト
        ///</summary>
        [TestMethod]
        public void SendMessageTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int roomId = TestData.SendMessageTestRoomId;
            string messageBody = "SendMessageTest @" + DateTime.Now;
            var actual = target.SendMessage(roomId, messageBody);
            Assert.IsNotNull(actual);
            Assert.AreNotEqual(actual.message_id, 0);
        }

        /// <summary>
        ///UpdateRoom のテスト
        ///</summary>
        [TestMethod]
        public void UpdateRoomTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int roomId = TestData.UpdateRoomTestRoomId;
            string description = "UpdateRoomTest @" + DateTime.Now;
            string icon_preset = "star";
            string name = "UpdateRoomTest @" + DateTime.Now;
            var actual = target.UpdateRoom(roomId, description, icon_preset, name);
            Assert.IsNotNull(actual);
            Assert.AreNotEqual(actual.room_id, 0);
        }

        /// <summary>
        ///UpdateRoomMembers のテスト
        ///</summary>
        [TestMethod]
        public void UpdateRoomMembersTest()
        {
            var target = new ChatworkClient(TestData.APIToken);
            int roomId = TestData.UpdateRoomMembersTestRoomId;
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