using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace BookingAutomated.Selenium.Tests.SeleniumCore.Factories
{
    internal class EdgeDriverBuilder : WebDriverBuilder
    {
        public override void BuildDriver()
        {
            WebDriver = new EdgeDriver(GetOptions() as EdgeOptions);
        }

        protected sealed override DriverOptions GetOptions()
        {
            var edgeOptions = new InternetExplorerOptions
            {
                EnsureCleanSession = true,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                RequireWindowFocus = true,
                EnableNativeEvents = true
            };
            edgeOptions.AddAdditionalCapability(CapabilityType.Version, "Edge");

            return edgeOptions;
        }
    }
}
