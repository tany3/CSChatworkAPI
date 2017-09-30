using System.Collections;
using NUnit.Framework;

namespace CSChatworkAPI.Test.E2E.TestCase
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
