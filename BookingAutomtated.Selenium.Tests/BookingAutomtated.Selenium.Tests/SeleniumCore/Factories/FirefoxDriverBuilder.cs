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
                firefoxOptions.AddArguments(new string[] { "--test-type" });
                firefoxOptions.AddArgument("--ignore-certificate-errors");
                firefoxOptions.AddArgument("--allow-running-insecure-content");
                firefoxOptions.AddArgument("--start-maximized");

               
                return firefoxOptions;
            }
        }
    }
}