using System.Collections;
using NUnit.Framework;

namespace CSChatworkAPITest2.TestCase
{
    public class MeTestCase
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(TestContext.TestData.ResultData.ChatworkId);
            }
        }
    }
}
