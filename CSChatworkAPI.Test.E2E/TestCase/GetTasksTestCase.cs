using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace CSChatworkAPI.Test.E2E.TestCase
{
    public class GetTasksTestCase
    {
        public static IEnumerable TestCases
        {
            get
            {
                var assignedByAccountId = "";
                var statuses = new[] { "done" };
                var tasks = new List<CSChatworkAPI.Models.Task>();

                yield return new TestCaseData(assignedByAccountId, statuses, tasks);
            }
        }
    }
}
