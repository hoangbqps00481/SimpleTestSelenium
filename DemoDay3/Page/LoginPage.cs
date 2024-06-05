using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoDay3.Page
{
    internal class LoginPage : BasePage
    {
        public LoginPage(IWebDriver _driver) : base(_driver)
        {
            driver = _driver;
        }

        private By errorMessageXpath = By.XPath("//p[contains(@class,'oxd-text oxd-text--p oxd-alert-content-text')] | //div[contains(text(),'Invalid Login Credentials.')]");
        private By userNameXpath = By.XPath("//input[contains(@name,'username')] | //input[contains(@id,'iusername')]");
        private By passwordXpath = By.XPath("//input[contains(@name,'password')] | //input[contains(@id,'ipassword')]");
        private By loginButtonXpath = By.XPath("//button[@type='submit'][contains(.,'Login')] | //button[contains(.,'Login')]");

        public void LoginWithUsernameAndPassword(string username, string password) {

            InputUserName(username);
            InputPassword(password);
            ClickLogin();
        }

        public void InputUserName(string username)
        {
            driver.FindElement(userNameXpath).SendKeys(username);
        }

        public void InputPassword(string password)
        {
            driver.FindElement(passwordXpath).SendKeys(password);
        }

        public void ClickLogin()
        {
            driver.FindElement(loginButtonXpath).Click();
        }

        public string GetErrorMessage()
        {

            return driver.FindElement(errorMessageXpath).Text;
           
        }

    }
}
