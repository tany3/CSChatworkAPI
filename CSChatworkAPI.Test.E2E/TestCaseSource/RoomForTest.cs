using System.Collections;
using CSChatworkAPI.Models;
using NUnit.Framework;

namespace CSChatworkAPI.Test.E2E.TestCaseSource
{
    class RoomForTest
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(GetRoomForTest());
            }
        }

        private static Room GetRoomForTest()
        {
            return TestCaseUtility.CreateRoomForTest();
        }
    }
}
