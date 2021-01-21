using BookingAutomated.Selenium.Tests.SeleniumCore.Factories;
using BookingAutomated.Selenium.Tests.SeleniumCore.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BookingAutomated.Selenium.Tests.SeleniumCore.Base
{
    public class InitializeTest
    {
        public static IWebDriver WebDriver;

        [SetUp]
        public static void AssemblyInitialize()
        {
            var webDriver = BrowserType.Chrome; //(BrowserType)Enum.Parse(typeof(BrowserType), TestContext.Parameters["WebDriver"]);

            WebDriver = new WebDriverSelector().GetDriver(webDriver);

            WebDriver.Url = "https://www.booking.com/"; //TestContext.Parameters["WebSite"];
        }
    }
}
