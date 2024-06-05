using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFrameworkCore.Roport;

namespace DemoDay3.Test
{
    [TestClass]
    public class AssemblyTest
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext TestContext) {
            // Setup report
            BaseTest.ReportHelper = new ReportHelper();
            BaseTest.ReportHelper.InitReport();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            if (BaseTest.ReportHelper != null) {
                BaseTest.ReportHelper.ExportReport();
            }
        }
    }
        
}
