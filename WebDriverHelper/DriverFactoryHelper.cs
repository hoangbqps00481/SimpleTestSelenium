﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;

namespace WebDriverHelper.Helper
{
    public class DriverFactoryHelper
    {

        public static IWebDriver InitBrowser(string browserType)
        {

            IWebDriver driver = null;

            switch (browserType)
            {

                case "CHROME":
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    driver = new ChromeDriver();
                    break;

                case "FIREFOX":
                    new DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.MatchingBrowser);
                    driver = new FirefoxDriver();
                    break;

                case "EDGE":
                    new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
                    driver = new EdgeDriver();
                    break;

                default:
                    throw new Exception("Not support this driver type");
                    break;
            }

            return driver;
        }
    }
}
