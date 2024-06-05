using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestFrameworkCore.Roport
{
    public class ReportHelper
    {

        private ExtentReports extent;

        public ReportHelper()
        {
            InitReport();
        }

        public void InitReport()
        {
            extent = new ExtentReports();
            var reportName = $"Report_{DateTime.Now.ToFileTimeUtc()}.html";
            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", reportName);
            var spark = new ExtentSparkReporter(reportPath);
            extent.AttachReporter(spark);

        }

        public void ExportReport()
        {
            extent.Flush();
        }

        public ExtentTest CreateTest(string name, string description)
        {
            return extent.CreateTest(name, description);
        }

    }
}
