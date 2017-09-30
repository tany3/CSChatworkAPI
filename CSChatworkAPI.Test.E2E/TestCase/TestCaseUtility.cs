using System;

namespace CSChatworkAPI.Test.E2E.TestCase
{
    public static class TestCaseUtility
    {
        private static readonly ChatworkClient Client = new ChatworkClient(TestContext.TestData.InputData.APIToken);

        public static Models.Room CreateRoomForTest()
        {
            var now = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff");
            var accountId = Client.GetMe().account_id;

            var admins = new[] { accountId };
            var members = new[] { "" };
            var readonlyMembers = new[] { "" };

            var room = Client.AddRoom(
                $"description for test room created at {now}",
                "beer",
                admins,
                members,
                readonlyMembers,
                $"Test at {now}");
            return room;
        }
    }
}
