using DemoDay3.Page;
using FluentAssertions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFrameworkCore.Helper;
using TestFrameworkCore.Roport;
using WebDriverHelper;

namespace DemoDay3.Test
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;
        public override void SetupPage()
        {
            loginPage = new LoginPage(browserHelper.Driver);
            dashboardPage = new DashboardPage(browserHelper.Driver);

        }

        [TestMethod("C01: Verify login with valid usename and password")]

        public void LoginWithValidUser()
        {
           // throw new Exception("Faile");
            // Input username and password
            string username = ConfigurationHelper.GetConfig<string>("username");
            extentTest.LogMessage($"Read configuaration - username ");

            string password = ConfigurationHelper.GetConfig<string>("password");
            extentTest.LogMessage($"Read configuaration - password");

            // Input UserName and Password
            loginPage.LoginWithUsernameAndPassword(username, password);

            // Verify dashboard page is displayed
            Assert.IsTrue(dashboardPage.IsTitleDashboardDisplay(10));

            //dashboardPage.IsTitleDashboardDisplay().Should().BeTrue();
        }


        [TestMethod("C02: Verify login with invalid usename and password")]
        public void LoginWithInValidUser()
        {
            string username = "Admindwdw";
            string password = "admin12f3";
            loginPage.LoginWithUsernameAndPassword(username, password);
            Assert.AreEqual(loginPage.GetErrorMessage(), "Invalid Login Credentials.");

            //loginPage.GetErrorMessage().Should().Contain("");
        }
    }
}