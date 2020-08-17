using OpenQA.Selenium;

namespace BookingAutomtated.Selenium.Tests.SeleniumCore.Factories
{
    public abstract class WebDriverBuilder
    {
        protected IWebDriver WebDriver;

        public IWebDriver GetDriver() { return WebDriver; }
        protected abstract DriverOptions GetOptions();
        public abstract void BuildDriver();
    }
}
