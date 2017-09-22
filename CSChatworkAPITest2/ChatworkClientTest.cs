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
        private ChatworkClient client = new ChatworkClient(TestContext.TestData.InputData.APIToken);

        [OneTimeSetUp]
        public void Setup()
        {
        }

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
            var me = client.GetMe();

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
            var status = client.GetStatus();
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
        #endregion endpoint /rooms
    }
}
