using Gurock.TestRail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests._Help
{
    public static class TestRailMethods
    {
        public static string TestRailRunId = "115";
        public static string TestRailUsername = "automated.user@clubspark.com";
        public static string TestRailPassword = "R0b0t123";
        public static string TestRailUrl = "https://clubspark.testrail.io";
    

    public static void AddResultForTestCase(string testCaseId, int status, string comment)
    {
        try
        {
            var testRunId = TestRailRunId;
                var client = new APIClient(TestRailUrl)
                {
                    User = TestRailUsername, //TestRail e-mail id of user
                    Password = TestRailPassword
                };
                Dictionary<string, object> testResult = new Dictionary<string, object>
                {
                    ["status_id"] = status, //TestCase Status either Failed or Passed;
                    ["comment"] = comment
                };
                client.SendPost("add_result_for_case/" + testRunId + "/" + testCaseId + "", testResult);

        }
        catch (APIException)
        {

        }
        catch (InvalidOperationException)
        {

        }
    }
}
}
