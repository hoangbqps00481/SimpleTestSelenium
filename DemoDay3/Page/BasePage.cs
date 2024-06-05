using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoDay3.Page
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver _driver)
        {
            this.driver = _driver;
        }



    }
}
