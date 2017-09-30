using System;
using System.IO;
using System.Text;
using CSChatworkAPI.Test.E2E.TestCase;
using Newtonsoft.Json;

namespace CSChatworkAPI.Test.E2E
{
    public class TestData
    {
        public InputData InputData { get; set; }

        public ResultData ResultData { get; set; }

        /// <summary>
        /// Return new TestData.
        /// </summary>
        public static TestData Create(string filename, string encodingName = "UTF-8")
        {
            if (string.IsNullOrWhiteSpace(filename)) { throw new ArgumentNullException(@"filename"); }

            string json;
            using (var sr = new StreamReader(filename, Encoding.GetEncoding(encodingName)))
            {
                json = sr.ReadToEnd();
                sr.Close();
            }
            if (string.IsNullOrWhiteSpace(json)) { throw new Exception(@"file is empty."); }

            return JsonConvert.DeserializeObject<TestData>(json);
        }
    }

    public class InputData
    {
        public string APIToken { get; set; }
    }

    public class ResultData
    {
        public string ChatworkId { get; set; }
    }

    public static class TestContext
    {
        public static ChatworkClient ChatworkClient { get; }

        public static TestData TestData { get; }

        public static Models.Me Me { get; private set; }

        public static Models.Room TestRoom { get; private set; }

        static TestContext()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData.json");
            TestData = TestData.Create(path);
            ChatworkClient = new ChatworkClient(TestData.InputData.APIToken);
            Me = ChatworkClient.GetMe();
        }

        public static void SetUp()
        {
            TestRoom = TestCaseUtility.CreateRoomForTest();
        }

        public static void TearDown()
        {
            if (TestRoom != null)
                ChatworkClient.LeaveRoom(TestRoom.RoomId);
        }

        public static void CleanTestRooms()
        {
            foreach (var room in ChatworkClient.GetRooms())
                if (room.Name.StartsWith(TestCaseUtility.RoomNamePrefix))
                    ChatworkClient.LeaveRoom(room.RoomId);
        }
    }
}
