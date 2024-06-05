using DemoDay3.Model;
using DemoDay3.Page;
using FluentAssertions;
using Newtonsoft.Json;
using WebDriverHelper;

namespace DemoDay3.Helper
{
    public class KeywordHelper
    {
        private List<KeywordData> keywords;
        private BrowserHelper browserHelper;

        public KeywordHelper(List<KeywordData> keywords)
        {
            this.keywords = keywords;
        }

        public void ExecuteKeyword()
        {
            foreach (var keyword in keywords)
            {
                ExecuteKeyword(keyword);
            }
        }
            /// <summary>
            /// Excute keyword in the list 
            /// </summary>
            public void ExecuteKeyword(KeywordData keywordData) {
            switch (keywordData.Keyword)
            {
                case "Open Browser":
                    browserHelper = new BrowserHelper();
                    browserHelper.OpenBrowser(browserType: keywordData.Data);
                    break;

                case "Go to URL":
                    browserHelper.GoToURL(url: keywordData.Data);
                    break;

                /*                case "Enter username":
                                    EnterUserName(keywordData.Data);
                                    break;

                                case "Enter password":
                                    EnterPassword(keywordData.Data);
                                    break;*/


                case "Enter username and password":
                    UserModel? userModel = JsonConvert.DeserializeObject<UserModel>(keywordData.Data);
                    EnterUsernameAndPassword(userModel);
                    break;

                case "Click login button":
                    ClickLoginButton();
                    break;

                case "Verify dashboard display":
                    VerifyDashboardDisplay(bool.Parse(keywordData.Data));
                    break;

                case "Quit Browser":
                    browserHelper.QuitBrowser();
                    break;

                default:
                    throw new Exception("Not support this keyword");
            }
        }

        private void VerifyDashboardDisplay(bool expected)
        {
            DashboardPage dashboardPage = new DashboardPage(browserHelper.Driver);
            dashboardPage.IsTitleDashboardDisplay(10).Should().Be(expected);
        }

        private void EnterUserName(string username) { 
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.InputUserName(username);
        }

        private void EnterPassword(string password)
        {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.InputPassword(password);
        }

        private void ClickLoginButton()
        {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.ClickLogin();
        }


        private void EnterUsernameAndPassword(UserModel userModel)
        {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.LoginWithUsernameAndPassword(userModel.username, userModel.password);
        }
    }
}
