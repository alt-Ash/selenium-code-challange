using BookingAutomtated.Selenium.Tests.SeleniumCore.Base;
using BookingAutomtated.Selenium.Tests.SeleniumCore.Helpers;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace BookingAutomtated.Selenium.Tests.SeleniumCore.Extensions
{
    public class Selenium
    {
        private IWebDriver WebDriver { get; }
        private TimeSpan Timeout { get; }

        public Selenium()
        {
            WebDriver = InitializeTest.WebDriver;
            Timeout = TimeSpan.FromSeconds(20);
        }

        public IPage FindElement(FindBy findBy, string locator) => new DriverToolBox(this, FindByAttribute.FindByLocator(findBy, locator));
        public void WaitUntilElementIsVisible(By locator, TimeSpan? timeout = null) => WaitUntilElementIsVisible(locator, null, timeout);
        public void WaitUntilCollectionIsVisible(By locator, TimeSpan? timeout = null) => WaitUntilCollectionIsVisible(locator, null, timeout);
        public void WaitUntilElementIsNotVisible(By locator, TimeSpan? timeout = null) => WaitUntilElementIsNotVisible(locator, null, timeout);
        public bool IsElementVisible(By locator) => ElementIsVisible(locator);
        public string GetText(By locator) => WebDriver.FindElement(locator).Text;
        public string GetAttribute(By locator, string attribute) => WebDriver.FindElement(locator).GetAttribute(attribute);
        public string GetCssValue(By locator, string value) => WebDriver.FindElement(locator).GetCssValue(value);
        public string GetProperty(By locator, string property) => WebDriver.FindElement(locator).GetProperty(property);
        public void SendKeys(By locator, string attribute) => WebDriver.FindElement(locator).SendKeys(attribute);
        public void Click(By locator) => WebDriver.FindElement(locator).Click();
        public List<IPage> FindElements(FindBy findBy, string locator) => GetElementsList(FindByAttribute.FindByLocator(findBy, locator));
        public IEnumerable<IWebElement> GetInnerElement(By locator, string innerElement) => GetInnerElement(innerElement, locator);
        public void ClickElementInTable(By locator, string innerElement, string attribute, string elementStart, string elementEnd) => ClickElementInTable(innerElement, attribute, elementStart, elementEnd, locator);
        public void ScrollToMakeTheElementVisible(By locator) => ScrollToMakeTheElementVisible(WebDriver.FindElement(locator));

        private List<IPage> GetElementsList(By locator)
        {
            var elements = WebDriver.FindElements(locator);
            var list = elements.Select(x => new DriverToolBox(this, locator));

            return new List<IPage>(list);
        }

        private void WaitUntilCollectionIsVisible(By locator, string selector, TimeSpan? timeout = null)
        {
            var wait = new WebDriverWait(WebDriver, timeout ?? Timeout)
            {
                Message = $"Element {locator} was not visible within timeout of {Timeout.TotalSeconds} seconds",
                PollingInterval = TimeSpan.FromSeconds(2)
            };

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        private void WaitUntilElementIsVisible(By locator, string selector, TimeSpan? timeout = null)
        {
            var wait = new WebDriverWait(WebDriver, timeout ?? Timeout)
            {
                Message = $"Element {locator} was not visible within timeout of {Timeout.TotalSeconds} seconds",
                PollingInterval = TimeSpan.FromSeconds(2)
            };

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        private void WaitUntilElementIsNotVisible(By locator, string selector, TimeSpan? timeout = null)
        {
            var wait = new WebDriverWait(WebDriver, timeout ?? Timeout)
            {
                Message = $"Element {locator} was not visible within timeout of {Timeout.TotalSeconds} seconds",
                PollingInterval = TimeSpan.FromSeconds(2)
            };

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        private bool ElementIsVisible(By locator)
        {
            try
            {
                return WebDriver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        private IEnumerable<IWebElement> GetInnerElement(string innerElement, By locator)
        {
            var element = WebDriver.FindElement(locator);

            var internalElement = element.FindElements(By.TagName(innerElement));

            return internalElement.ToList();
        }

        private void ClickElementInTable(string innerElement, string attribute, string elementStart, string elementEnd, By locator)
        {
            var table = WebDriver.FindElement(locator);

            var internalElement = table.FindElements(By.TagName(innerElement));

            foreach (var data in internalElement)
            {
                if (data.GetAttribute(attribute) == elementStart || data.GetAttribute(attribute) == elementEnd) data.Click();
            }

            return;
        }

        private void ScrollToMakeTheElementVisible(IWebElement webElement)
        {
            var actions = new Actions(WebDriver);
            actions.MoveToElement(webElement);
            actions.Perform();
        }
    }
}
