using BookingAutomated.Selenium.Tests.SeleniumCore.Helpers;
using OpenQA.Selenium;

namespace BookingAutomated.Selenium.Tests.SeleniumCore.Interfaces
{
    public interface IWebDriverSelector
    {
        IWebDriver GetDriver(BrowserType browserType);
    }
}
