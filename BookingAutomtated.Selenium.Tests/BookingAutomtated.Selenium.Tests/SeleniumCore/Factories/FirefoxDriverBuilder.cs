using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace BookingAutomtated.Selenium.Tests.SeleniumCore.Factories
{
    internal class FirefoxDriverBuilder : WebDriverBuilder
    {
        public override void BuildDriver()
        {
            WebDriver = new FirefoxDriver(GetOptions() as FirefoxOptions);
        }

        protected sealed override DriverOptions GetOptions()
        {
            {
                var firefoxOptions = new FirefoxOptions();
                firefoxOptions.AddArgument("--window-size");
                firefoxOptions.AddArgument("1920,1080");
                firefoxOptions.AddArgument("start-maximized");

                return firefoxOptions;
            }
        }
    }
}