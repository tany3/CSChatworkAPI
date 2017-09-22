/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using CSChatworkAPI;
using NUnit.Framework;

namespace CSChatworkAPITest2
{
    [TestFixture]
    public class ChatworkClientTest
    {
        [TestCase]
        public void Test_Constructor()
        {
            Assert.DoesNotThrow(() => new ChatworkClient("dummyApiToken"));
            Assert.Throws<ArgumentNullException>(() => new ChatworkClient(null));
        }

        #region endpoint /me
        [TestCaseSource(typeof(TestCase.MeTestCase), nameof(TestCase.MeTestCase.TestCases))]
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

        [TestCaseSource(typeof(TestCase.GetTasksTestCase), nameof(TestCase.GetTasksTestCase.TestCases))]
        public void Test_GetTasks(string assignedByAccountId, IEnumerable<string> statuses, IEnumerable<CSChatworkAPI.Models.Task> result)
        {
            Assert.Inconclusive();
        }
        #endregion endpoint /my

        #region endpoint /contacts
        #endregion endpoint /contacts

        #region endpoint /rooms
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
        public void Test_DeleteRoom()
        {
            // prepare
            var room = TestCase.TestCaseUtility.CreateRoomForTest();

            // act
            TestContext.ChatworkClient.DeleteRoom(room.room_id);

            // test
            var deletedRoom = TestContext.ChatworkClient.GetRoom(room.room_id);
            Assert.IsNull(deletedRoom.room_id);
        }
        #endregion endpoint /rooms
    }
}
