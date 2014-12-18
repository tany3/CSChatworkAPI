/* See the file "LICENSE" for the full license governing this code. */

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
            int roomId = TestData.AddTaskTestRID;
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
            int roomId = TestData.AddTaskTestRID;
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
            int roomId = TestData.GetFileTestRoomID;
            int fileId = TestData.GetFileTestFileID;
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
            int roomId = TestData.GetFilesTestRoomID;
            int account_id = TestData.GetFilesTestAccountID;
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
            int roomId = TestData.GetMessageTestRoomID;
            int messageId = TestData.GetMessageTestMessageID;
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
            int roomId = TestData.GetMessagesTestRoomID;
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
            string apiToken = string.Empty; // TODO: 適切な値に初期化してください
            ChatworkClient target = new ChatworkClient(apiToken); // TODO: 適切な値に初期化してください
            int roomId = 0; // TODO: 適切な値に初期化してください
            IEnumerable<Member> expected = null; // TODO: 適切な値に初期化してください
            IEnumerable<Member> actual;
            actual = target.GetRoomMembers(roomId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///GetRooms のテスト
        ///</summary>
        [TestMethod]
        public void GetRoomsTest()
        {
            string apiToken = string.Empty; // TODO: 適切な値に初期化してください
            ChatworkClient target = new ChatworkClient(apiToken); // TODO: 適切な値に初期化してください
            IEnumerable<Room> expected = null; // TODO: 適切な値に初期化してください
            IEnumerable<Room> actual;
            actual = target.GetRooms();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///GetStatus のテスト
        ///</summary>
        [TestMethod]
        public void GetStatusTest()
        {
            string apiToken = string.Empty; // TODO: 適切な値に初期化してください
            ChatworkClient target = new ChatworkClient(apiToken); // TODO: 適切な値に初期化してください
            MyStatus expected = null; // TODO: 適切な値に初期化してください
            MyStatus actual;
            actual = target.GetStatus();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///GetTask のテスト
        ///</summary>
        [TestMethod]
        public void GetTaskTest()
        {
            string apiToken = string.Empty; // TODO: 適切な値に初期化してください
            ChatworkClient target = new ChatworkClient(apiToken); // TODO: 適切な値に初期化してください
            int roomId = 0; // TODO: 適切な値に初期化してください
            int taskId = 0; // TODO: 適切な値に初期化してください
            Task expected = null; // TODO: 適切な値に初期化してください
            Task actual;
            actual = target.GetTask(roomId, taskId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///GetTasks のテスト
        ///</summary>
        [TestMethod]
        public void GetTasksTest()
        {
            string apiToken = string.Empty; // TODO: 適切な値に初期化してください
            ChatworkClient target = new ChatworkClient(apiToken); // TODO: 適切な値に初期化してください
            int roomId = 0; // TODO: 適切な値に初期化してください
            int account_id = 0; // TODO: 適切な値に初期化してください
            int assigned_by_account_id = 0; // TODO: 適切な値に初期化してください
            int status = 0; // TODO: 適切な値に初期化してください
            IEnumerable<Task> expected = null; // TODO: 適切な値に初期化してください
            IEnumerable<Task> actual;
            actual = target.GetTasks(roomId, account_id, assigned_by_account_id, status);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///GetTasks のテスト
        ///</summary>
        [TestMethod]
        public void GetTasksTest1()
        {
            string apiToken = string.Empty; // TODO: 適切な値に初期化してください
            ChatworkClient target = new ChatworkClient(apiToken); // TODO: 適切な値に初期化してください
            int assigned_by_account_id = 0; // TODO: 適切な値に初期化してください
            IEnumerable<string> statuses = null; // TODO: 適切な値に初期化してください
            IEnumerable<MyTask> expected = null; // TODO: 適切な値に初期化してください
            IEnumerable<MyTask> actual;
            actual = target.GetTasks(assigned_by_account_id, statuses);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///LeaveRoom のテスト
        ///</summary>
        [TestMethod]
        public void LeaveRoomTest()
        {
            string apiToken = string.Empty; // TODO: 適切な値に初期化してください
            ChatworkClient target = new ChatworkClient(apiToken); // TODO: 適切な値に初期化してください
            int roomId = 0; // TODO: 適切な値に初期化してください
            target.LeaveRoom(roomId);
            Assert.Inconclusive("値を返さないメソッドは確認できません。");
        }

        /// <summary>
        ///SendMessage のテスト
        ///</summary>
        [TestMethod]
        public void SendMessageTest()
        {
            string apiToken = string.Empty; // TODO: 適切な値に初期化してください
            ChatworkClient target = new ChatworkClient(apiToken); // TODO: 適切な値に初期化してください
            int roomId = 0; // TODO: 適切な値に初期化してください
            string messageBody = string.Empty; // TODO: 適切な値に初期化してください
            ResponseMessage expected = null; // TODO: 適切な値に初期化してください
            ResponseMessage actual;
            actual = target.SendMessage(roomId, messageBody);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///UpdateRoom のテスト
        ///</summary>
        [TestMethod]
        public void UpdateRoomTest()
        {
            string apiToken = string.Empty; // TODO: 適切な値に初期化してください
            ChatworkClient target = new ChatworkClient(apiToken); // TODO: 適切な値に初期化してください
            int roomId = 0; // TODO: 適切な値に初期化してください
            string description = string.Empty; // TODO: 適切な値に初期化してください
            string icon_preset = string.Empty; // TODO: 適切な値に初期化してください
            string name = string.Empty; // TODO: 適切な値に初期化してください
            ResponseMessage expected = null; // TODO: 適切な値に初期化してください
            ResponseMessage actual;
            actual = target.UpdateRoom(roomId, description, icon_preset, name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///UpdateRoomMembers のテスト
        ///</summary>
        [TestMethod]
        public void UpdateRoomMembersTest()
        {
            string apiToken = string.Empty; // TODO: 適切な値に初期化してください
            ChatworkClient target = new ChatworkClient(apiToken); // TODO: 適切な値に初期化してください
            int roomId = 0; // TODO: 適切な値に初期化してください
            IEnumerable<int> members_admin_ids = null; // TODO: 適切な値に初期化してください
            IEnumerable<int> members_member_ids = null; // TODO: 適切な値に初期化してください
            IEnumerable<int> members_readonly_ids = null; // TODO: 適切な値に初期化してください
            MemberRoles expected = null; // TODO: 適切な値に初期化してください
            MemberRoles actual;
            actual = target.UpdateRoomMembers(roomId, members_admin_ids, members_member_ids, members_readonly_ids);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }
    }
}
