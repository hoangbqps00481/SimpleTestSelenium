using System.Reflection;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFrameworkCore.Helper;
using TestFrameworkCore.Roport;
using WebDriverHelper;

namespace DemoDay3.Test
{
    [TestClass]
    public class BaseTest
    {

        protected BrowserHelper browserHelper;
        public static ReportHelper ReportHelper;

        public TestContext TestContext { get; set; }
        protected ExtentTest extentTest;

        public virtual void SetupPage()
        {
        }

        [TestInitialize]
        public virtual void TestInitialize()
        {
            browserHelper = new BrowserHelper();
            var url = ConfigurationHelper.GetConfig<string>("url");
            browserHelper.OpenBrowser(url);


            SetupPage();

            // Create a Test

            MethodInfo testMethod = GetType().GetMethod(TestContext.TestName);
            TestMethodAttribute displayNameAttribute = testMethod.GetCustomAttribute<TestMethodAttribute>();
            string displayName = displayNameAttribute != null ? displayNameAttribute.DisplayName : TestContext.TestName;

            extentTest = ReportHelper.CreateTest(TestContext.TestName, displayName);
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            //Add Result
            if (extentTest != null) {
                if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
                {
                    extentTest.AddImageBase64(browserHelper.TakeScreenshotAsBase64());
                }
                extentTest.AddResult(TestContext.CurrentTestOutcome.ToString());
            }
            browserHelper.QuitBrowser();
        }
    }
}
