/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using CSChatworkAPI.Models;
using CSChatworkAPI.Test.E2E.TestCase;
using CSChatworkAPI.Test.E2E.TestCaseSource;
using NUnit.Framework;

namespace CSChatworkAPI.Test.E2E
{
    [TestFixture]
    public class ChatworkClientTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.TearDown();
        }

        [TestCase]
        public void Test_Constructor()
        {
            Assert.DoesNotThrow(() => new ChatworkClient("dummyApiToken"));
            Assert.Throws<ArgumentNullException>(() => new ChatworkClient(null));
        }

        #region endpoint /me
        [TestCaseSource(typeof(MeTestCase), nameof(MeTestCase.TestCases))]
        public void Test_Me(string chatworkId)
        {
            var me = TestContext.ChatworkClient.GetMe();

            Assert.IsNotNull(me);
            Assert.IsNotEmpty(me.account_id);
            Assert.IsNotEmpty(me.chatwork_id);
            Assert.AreEqual(me.chatwork_id, chatworkId);
        }
        #endregion endpoint /me

        #region endpoint /my
        [TestCase]
        public void Test_GetStatus()
        {
            var status = TestContext.ChatworkClient.GetStatus();
            Assert.IsNotNull(status);
        }

        [TestCaseSource(typeof(GetTasksTestCase), nameof(GetTasksTestCase.TestCases))]
        public void Test_GetTasks(string assignedByAccountId, IEnumerable<string> statuses, IEnumerable<CSChatworkAPI.Models.Task> result)
        {
            Assert.Inconclusive();
        }
        #endregion endpoint /my

        #region endpoint /contacts
        [TestCase]
        public void Test_Contact()
        {
            Assert.Inconclusive();
        }
        #endregion endpoint /contacts

        #region endpoint /rooms

        [TestCase]
        public void Test_GetRooms()
        {
            Assert.Inconclusive();
        }

        [TestCase]
        public void Test_AddRoom()
        {
            Assert.Inconclusive();
        }

        [TestCase]
        public void Test_GetRoom()
        {
            Assert.Inconclusive();
        }

        [TestCaseSource(typeof(RoomForTest), nameof(RoomForTest.TestCases))]
        public void Test_UpdateRoom(Room room)
        {
            // act
            var now = $"{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}";
            var newIcon = "star";
            var newIconPath = "https://appdata.chatwork.com/icon/ico_star.png";
            var newDescription = $"description for test room created at {now}";
            var newRoomName = $"test room created at {now}";
            TestContext.ChatworkClient.UpdateRoom(room.room_id, newDescription, newIcon, newRoomName);

            // assert
            var actual = TestContext.ChatworkClient.GetRoom(room.room_id);
            Assert.AreEqual(newIconPath, actual.icon_path);
            Assert.AreEqual(newDescription, actual.description);
            Assert.AreEqual(newRoomName, actual.name);

            // tear down
            TestContext.ChatworkClient.DeleteRoom(room.room_id);
        }

        [TestCaseSource(typeof(RoomForTest), nameof(RoomForTest.TestCases))]
        public void Test_LeaveRoom(Room room)
        {
            // act
            TestContext.ChatworkClient.LeaveRoom(room.room_id);

            // assert
            var actual = TestContext.ChatworkClient.GetRoom(room.room_id);
            Assert.IsNull(actual.room_id);
        }

        [TestCaseSource(typeof(RoomForTest), nameof(RoomForTest.TestCases))]
        public void Test_DeleteRoom(Room room)
        {
            // act
            TestContext.ChatworkClient.DeleteRoom(room.room_id);

            // test
            var deletedRoom = TestContext.ChatworkClient.GetRoom(room.room_id);
            Assert.IsNull(deletedRoom.room_id);
        }

        [TestCase]
        public void Test_GetRoomMembers()
        {
            Assert.Inconclusive();
        }

        [TestCase]
        public void Test_UpdateRoomMembers()
        {
            Assert.Inconclusive();
        }

        [TestCase]
        public void Test_GetMessages()
        {
            Assert.Inconclusive();
        }

        [TestCase]
        public void Test_SendMessage()
        {
            Assert.Inconclusive();
        }

        [TestCase]
        public void Test_GetMessage()
        {
            Assert.Inconclusive();
        }

        [TestCase]
        public void Test_GetTasks()
        {
            Assert.Inconclusive();
        }

        [TestCase]
        public void Test_AddTask()
        {
            var ids = TestContext.ChatworkClient.AddTask(TestContext.TestRoom.room_id,
                $"task body created at {DateTime.Today}",
                DateTime.Today.AddDays(1),
                new[] { TestContext.Me.account_id });

            Assert.IsNotEmpty(ids.task_ids);
        }

        [TestCase]
        public void Test_GetTask()
        {
            Assert.Inconclusive();
        }

        [TestCase]
        public void Test_GetFiles()
        {
            Assert.Inconclusive();
        }

        [TestCase]
        public void Test_GetFile()
        {
            Assert.Inconclusive();
        }
        #endregion endpoint /rooms
    }
}
