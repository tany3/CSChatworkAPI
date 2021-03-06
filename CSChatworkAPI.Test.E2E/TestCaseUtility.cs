﻿using System;

namespace CSChatworkAPI.Test.E2E
{
    public static class TestCaseUtility
    {
        public static string RoomNamePrefix = "CSChatworkAPI.Test.E2E";

        private static readonly ChatworkClient Client = new ChatworkClient(TestContext.TestData.InputData.APIToken);

        public static Models.Room CreateRoomForTest()
        {
            var now = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff");
            var accountId = Client.GetMe().AccountId;

            var admins = new[] { accountId };
            var members = new[] { "" };
            var readonlyMembers = new[] { "" };

            var roomName = $"{RoomNamePrefix} at {now}";

            var room = Client.AddRoom(
                $"description for test room created at {now}",
                "beer",
                admins,
                members,
                readonlyMembers,
                roomName);
            return room;
        }

        public static string SendMessage(string roomId)
        {
            var messageBody = $"message created at {DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}";
            Client.SendMessage(roomId, messageBody);
            return messageBody;
        }
    }
}
