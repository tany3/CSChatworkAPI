using System;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace CSChatworkAPITest2
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
        public static TestData TestData { get; set; }

        static TestContext()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData.json");
            TestData = TestData.Create(path);
        }
    }
}
