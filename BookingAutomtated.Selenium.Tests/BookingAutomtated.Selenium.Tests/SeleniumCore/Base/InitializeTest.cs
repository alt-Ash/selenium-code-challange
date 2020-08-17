using BookingAutomtated.Selenium.Tests.SeleniumCore.Factories;
using BookingAutomtated.Selenium.Tests.SeleniumCore.Helpers;

using NUnit.Framework;

using OpenQA.Selenium;

using System;

namespace BookingAutomtated.Selenium.Tests.SeleniumCore.Base
{
    public class InitializeTest
    {
        public static IWebDriver WebDriver;

        [SetUp]
        public static void AssemblyInitialize()
        {
            var webDriver = (BrowserType)Enum.Parse(typeof(BrowserType), TestContext.Parameters["WebDriver"]);

            WebDriver = new WebDriverSelector().GetDriver(webDriver);

            WebDriver.Url = TestContext.Parameters["WebSite"];
        }
    }
}
