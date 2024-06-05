using System.Drawing;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using TestFrameworkCore.Helper;
using WebDriverHelper.Helper;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace WebDriverHelper
{
    public class BrowserHelper
    {
        public IWebDriver Driver;
        public void OpenBrowser(string url = null, string browserType = null)
        {

            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

            //Neu ko truyen browserType thi doc tu config
            // Nguoc lai su dung cai thu minh truyn vo
            if (string.IsNullOrEmpty(browserType))
            {
                browserType = ConfigurationHelper.GetConfig<string>("browser");
            }

            Driver = DriverFactoryHelper.InitBrowser(browserType);

            var timeout = ConfigurationHelper.GetConfig<int>("timeout");

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            Driver.Manage().Window.Maximize();

            if (!string.IsNullOrEmpty(url))
            {
                GoToURL(url);
            }
        }

        public void QuitBrowser()
        {
            if (Driver is null)
            {
                return;
            }

            Driver.Quit();
        }

        public void GoToURL(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public string TakeScreenshotAsBase64()

        {

            // Chụp màn hình và lưu vào biến image

            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

            // Chuyển đổi ảnh thành dạng byte array

            byte[] screenshotAsByteArray = screenshot.AsByteArray;

            // Chuyển đổi byte array thành ảnh

            using (MemoryStream stream = new MemoryStream(screenshotAsByteArray))

            {

                using (Bitmap image = new Bitmap(stream))

                {

                    // Chuyển đổi ảnh thành chuỗi base64

                    using (MemoryStream memoryStream = new MemoryStream())

                    {

                        image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

                        byte[] imageBytes = memoryStream.ToArray();

                        return Convert.ToBase64String(imageBytes);

                    }

                }

            }

        }
    }
}
