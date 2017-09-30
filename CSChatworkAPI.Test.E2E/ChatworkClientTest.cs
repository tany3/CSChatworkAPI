/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using System.Linq;
using CSChatworkAPI.Test.E2E.TestCase;
using NUnit.Framework;

namespace CSChatworkAPI.Test.E2E
{
    [TestFixture]
    public class ChatworkClientTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            TestContext.CleanTestRooms();
            TestContext.SetUp();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            TestContext.TearDown();
        }

        [TestCase]
        public void Test_Constructor()
        {
            Assert.DoesNotThrow(() => new ChatworkClient("dummyApiToken"));
            Assert.Throws<ArgumentException>(() => new ChatworkClient(null));
        }

        #region endpoint /me
        [TestCaseSource(typeof(MeTestCase), nameof(MeTestCase.TestCases))]
        public void Test_Me(string chatworkId)
        {
            var me = TestContext.ChatworkClient.GetMe();

            Assert.IsNotNull(me);
            Assert.IsNotEmpty(me.AccountId);
            Assert.IsNotEmpty(me.ChatworkId);
            Assert.AreEqual(me.ChatworkId, chatworkId);
        }
        #endregion endpoint /me

        #region endpoint /my
        [TestCase]
        public void Test_GetStatus()
        {
            var status = TestContext.ChatworkClient.GetStatus();
            Assert.IsNotNull(status);
        }

        [TestCase]
        public void Test_GetMyTasks()
        {
            // act
            TestContext.ChatworkClient.AddTask(
                TestContext.Me.RoomId,
                $"task body created at {DateTime.Today}",
                DateTime.Today.AddDays(1),
                new[] { TestContext.Me.AccountId }).TaskIds.OrderByDescending(_ => _).LastOrDefault();
            TestContext.ChatworkClient.AddTask(
                TestContext.Me.RoomId,
                $"task body created at {DateTime.Today}",
                DateTime.Today.AddDays(1),
                new[] { TestContext.Me.AccountId }).TaskIds.OrderByDescending(_ => _).LastOrDefault();

            var tasks = TestContext.ChatworkClient.GetTasks(
                TestContext.Me.AccountId,
                new[] {"open", "done"});

            // assert
            Assert.Greater(tasks.Count(), 1);
        }
        #endregion endpoint /my

        #region endpoint /contacts
        [TestCase]
        public void Test_Contact()
        {
            // act
            var contacts = TestContext.ChatworkClient.GetContacts();

            // assert
            Assert.Greater(contacts.Count(), 1);
        }
        #endregion endpoint /contacts

        #region endpoint /rooms

        [TestCase]
        public void Test_GetRooms()
        {
            // prepare
            var room1 = TestCaseUtility.CreateRoomForTest();
            var room2 = TestCaseUtility.CreateRoomForTest();

            // act
            var actual = TestContext.ChatworkClient.GetRooms();

            // assert
            Assert.Greater(actual.Count(), 2);

            // tear down
            TestContext.ChatworkClient.DeleteRoom(room1.RoomId);
            TestContext.ChatworkClient.DeleteRoom(room2.RoomId);
        }

        [TestCase]
        public void Test_AddRoom()
        {
            Assert.IsNotNull(TestContext.TestRoom);
            Assert.IsNotNull(TestContext.TestRoom.RoomId);
        }

        [TestCase]
        public void Test_GetRoom_UpdateRoom()
        {
            // prepare
            var room = TestCaseUtility.CreateRoomForTest();

            // act
            var now = $"{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}";
            var newIcon = "star";
            var newIconPath = "https://appdata.chatwork.com/icon/ico_star.png";
            var newDescription = $"description for test room created at {now}";
            var newRoomName = $"test room created at {now}";
            TestContext.ChatworkClient.UpdateRoom(room.RoomId, newDescription, newIcon, newRoomName);

            // assert
            var actual = TestContext.ChatworkClient.GetRoom(room.RoomId);
            Assert.AreEqual(newIconPath, actual.IconPath);
            Assert.AreEqual(newDescription, actual.Description);
            Assert.AreEqual(newRoomName, actual.Name);

            // tear down
            TestContext.ChatworkClient.DeleteRoom(room.RoomId);
        }

        [TestCase]
        public void Test_LeaveRoom()
        {
            // prepare
            var room = TestCaseUtility.CreateRoomForTest();

            // act
            TestContext.ChatworkClient.LeaveRoom(room.RoomId);

            // assert
            var message = Assert.Throws<Exception>(() => TestContext.ChatworkClient.GetRoom(room.RoomId)).Message;
            Assert.AreEqual(
                "API returns Forbidden. API response is here: {\"errors\":[\"You don't have permission to get this room\"]}",
                message);
        }

        [TestCase]
        public void Test_DeleteRoom()
        {
            // prepare
            var room = TestCaseUtility.CreateRoomForTest();

            // act
            TestContext.ChatworkClient.DeleteRoom(room.RoomId);

            // assert
            var message = Assert.Throws<Exception>(() => TestContext.ChatworkClient.GetRoom(room.RoomId)).Message;
            Assert.AreEqual(
                "API returns Forbidden. API response is here: {\"errors\":[\"You don't have permission to get this room\"]}",
                message);
        }

        [TestCase]
        public void Test_GetRoomMembers()
        {
            // act
            var members = TestContext.ChatworkClient.GetRoomMembers(TestContext.TestRoom.RoomId);

            // assert
            Assert.GreaterOrEqual(members.Count(), 1);
        }

        [TestCase]
        public void Test_UpdateRoomMembers()
        {
            // ユーザを追加しておくのがしんどい
            Assert.Inconclusive();
        }

        [TestCase]
        public void Test_GetMessages()
        {
            // prepare
            var room = TestCaseUtility.CreateRoomForTest();
            var expectMessageList = new List<string>
            {
                TestCaseUtility.SendMessage(room.RoomId),
                TestCaseUtility.SendMessage(room.RoomId),
                TestCaseUtility.SendMessage(room.RoomId),
            };

            // act
            var actualMessages = TestContext.ChatworkClient.GetMessages(room.RoomId).ToList();

            // assert
            Assert.IsTrue(actualMessages.Count == (expectMessageList.Count + 1/* room created message*/));

            // act
            var actualMessagesAfter= TestContext.ChatworkClient.GetMessages(room.RoomId);

            // assert
            Assert.IsNull(actualMessagesAfter);

            // tear down
            TestContext.ChatworkClient.DeleteRoom(room.RoomId);
        }

        [TestCase]
        public void Test_SendMessage()
        {
            // act
            var messageBody = $"message created at {DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}";
            TestContext.ChatworkClient.SendMessage(TestContext.TestRoom.RoomId, messageBody);

            // assert
            var messages = TestContext.ChatworkClient.GetMessages(TestContext.TestRoom.RoomId);
            Assert.IsTrue(messages.Any(_ => _.Body == messageBody));
        }

        [TestCase]
        public void Test_GetMessage()
        {
            // prepare
            var expected = TestContext.ChatworkClient.GetMessages(TestContext.TestRoom.RoomId, true).First();

            // act
            var actual = TestContext.ChatworkClient.GetMessage(TestContext.TestRoom.RoomId, expected.MessageId);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Test_AddTask_GetTasks_GetTask()
        {
            // act
            var responseTaskIds = TestContext.ChatworkClient.AddTask(
                TestContext.TestRoom.RoomId,
                $"task body created at {DateTime.Today}",
                DateTime.Today.AddDays(1),
                new[] { TestContext.Me.AccountId });

            // act
            var tasks = TestContext.ChatworkClient.GetTasks(
                TestContext.TestRoom.RoomId,
                TestContext.Me.AccountId,
                TestContext.Me.AccountId,
                "open").ToList();
            var task = TestContext.ChatworkClient.GetTask(
                TestContext.TestRoom.RoomId,
                tasks.First().TaskId);

            // assert
            Assert.IsNotEmpty(responseTaskIds.TaskIds);
            Assert.IsTrue(responseTaskIds.TaskIds.Any(_ => _ == task.TaskId));
            Assert.GreaterOrEqual(tasks.Count, 1);
        }

        [TestCase]
        public void Test_GetFiles_GetFile()
        {
            // act
            // 予めファイルをアップロードしておくこと
            var files = TestContext.ChatworkClient.GetFiles(
                TestContext.Me.RoomId,
                TestContext.Me.AccountId).ToList();
            var file = TestContext.ChatworkClient.GetFile(
                TestContext.Me.RoomId,
                files.First().FileId,
                false);

            // assert
            Assert.GreaterOrEqual(files.Count, 1);
            Assert.AreEqual(file, files.First());
        }
        #endregion endpoint /rooms
    }
}
