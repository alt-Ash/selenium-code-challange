using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BookingAutomtated.Selenium.Tests.SeleniumCore.Factories
{
    internal class ChromeDriverBuilder : WebDriverBuilder
    {
        public override void BuildDriver()
        {
            WebDriver = new ChromeDriver(GetOptions() as ChromeOptions);
        }

        protected sealed override DriverOptions GetOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new string[] { "--test-type" });
            chromeOptions.AddArguments(new string[] { "--lang=" });
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddArgument("--ignore-certificate-errors");
            chromeOptions.AddArgument("--allow-running-insecure-content");
            chromeOptions.AddArgument("--incognito");
            chromeOptions.AddArgument("--start-maximized");

            return chromeOptions;
        }
    }
}