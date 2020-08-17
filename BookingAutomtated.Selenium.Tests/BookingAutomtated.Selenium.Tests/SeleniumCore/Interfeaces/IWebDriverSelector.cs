using BookingAutomtated.Selenium.Tests.SeleniumCore.Helpers;

using OpenQA.Selenium;

namespace BookingAutomtated.Selenium.Tests.SeleniumCore.Interfeaces
{
    public interface IWebDriverSelector
    {
        IWebDriver GetDriver(BrowserType browserType);
    }
}
