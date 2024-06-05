using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoDay3.Page
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        private By xpathLabelDashboard = By.XPath("//p[contains(@class,'text-muted m-b-0')]");

        public bool IsTitleDashboardDisplay(int timeout=1) {

            var timeoutDefault = driver.Manage().Timeouts().ImplicitWait;

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
                return driver.FindElement(xpathLabelDashboard).Displayed;
            }
            catch {
                return false;
            }

            finally {
                driver.Manage().Timeouts().ImplicitWait = timeoutDefault;
            }

        }

    }
}
