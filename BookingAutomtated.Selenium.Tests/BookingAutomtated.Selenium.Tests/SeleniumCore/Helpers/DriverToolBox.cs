using BookingAutomtated.Selenium.Tests.SeleniumCore.Helpers;
using BookingAutomtated.Selenium.Tests.SeleniumCore.Interfeaces;

using OpenQA.Selenium;

using System.Collections.Generic;

namespace BookingAutomtated.Selenium.Tests.SeleniumCore.Extensions
{
    public class DriverToolBox : IPage
    {
        public Selenium Selenium;
        public By Locator;

        public bool IsVisible => Selenium.IsElementVisible(Locator);
        public string Text => Selenium.GetText(Locator);

        public DriverToolBox(Selenium selenium, By locator)
        {
            Selenium = selenium;
            Locator = locator;
        }

        public void WaitForVisableElement()
        {
            Selenium.WaitUntilElementIsVisible(Locator);
        }

        public void WaitForVisibleCollection()
        {
            Selenium.WaitUntilCollectionIsVisible(Locator);
        }

        public void WaitUntilVisableElementIsNot()
        {
            Selenium.WaitUntilElementIsNotVisible(Locator);
        }

        public void Click()
        {
            Selenium.Click(Locator);
        }

        public string GetAttribute(string attribute)
        {
            return Selenium.GetAttribute(Locator, attribute);
        }

        public string GetCssValue(string value)
        {
            return Selenium.GetCssValue(Locator, value);
        }

        public string GetProperty(string property)
        {
            return Selenium.GetCssValue(Locator, property);
        }

        public void SendKeys(string attribute)
        {
            Selenium.SendKeys(Locator, attribute);
        }

        public IEnumerable<IWebElement> GetInnerElementByProperty(string property)
        {
            return Selenium.GetInnerElement(Locator, property);
        }

        public void ClickElementInTable(string property, string attribute, string elementStart, string elementEnd)
        {
            Selenium.ClickElementInTable(Locator, property, attribute, elementStart, elementEnd);
        }

        public void ScrollToElement()
        {
            Selenium.ScrollToMakeTheElementVisible(Locator);
        }
    }
}
