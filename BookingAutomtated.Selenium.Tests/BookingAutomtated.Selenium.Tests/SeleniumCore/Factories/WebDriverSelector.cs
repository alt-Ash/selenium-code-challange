using BookingAutomtated.Selenium.Tests.SeleniumCore.Helpers;
using BookingAutomtated.Selenium.Tests.SeleniumCore.Interfeaces;
using OpenQA.Selenium;
using System;

namespace BookingAutomtated.Selenium.Tests.SeleniumCore.Factories
{
    public class WebDriverSelector : IWebDriverSelector
    {
        private WebDriverBuilder _webDriverBuilder;

        public IWebDriver GetDriver(BrowserType browserType)
        {
            _webDriverBuilder = browserType switch
            {
                BrowserType.Chrome => new ChromeDriverBuilder(),
                BrowserType.Firefox => new FirefoxDriverBuilder(),
                BrowserType.Edge => new EdgeDriverBuilder(),
                BrowserType.IE => throw new NotImplementedException($"{browserType} Browser has not been implemented"),
                _ => throw new ArgumentException($"Browser Not Supported: {browserType}"),
            };
            _webDriverBuilder.BuildDriver();

            return _webDriverBuilder.GetDriver();
        }
    }
}
