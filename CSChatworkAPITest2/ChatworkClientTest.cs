/* See the file "LICENSE" for the full license governing this code. */

using System;
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

        [TestCaseSource(typeof(TestCase.MeTestCase), nameof(TestCase.MeTestCase.TestCases))]
        public void Test_Me(string chatworkId)
        {
            var me = client.GetMe();

            Assert.IsNotNull(me);
            Assert.IsNotEmpty(me.account_id);
            Assert.IsNotEmpty(me.chatwork_id);
            Assert.AreEqual(me.chatwork_id, chatworkId);
        }
    }
}
