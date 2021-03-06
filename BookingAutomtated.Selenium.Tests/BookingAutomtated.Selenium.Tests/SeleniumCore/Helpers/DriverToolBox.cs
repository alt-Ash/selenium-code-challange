﻿using System.Collections.Generic;
using BookingAutomated.Selenium.Tests.SeleniumCore.Interfaces;
using OpenQA.Selenium;

namespace BookingAutomated.Selenium.Tests.SeleniumCore.Helpers
{
    public class DriverToolBox : IPage
    {
        public Extensions.Selenium Selenium;
        public By Locator;

        public bool IsVisible => Selenium.IsElementVisible(Locator);
        public string Text => Selenium.GetText(Locator);

        public DriverToolBox(Extensions.Selenium selenium, By locator)
        {
            Selenium = selenium;
            Locator = locator;
        }

        public void WaitForVisibleElement()
        {
            Selenium.WaitUntilElementIsVisible(Locator);
        }

        public void WaitForVisibleCollection()
        {
            Selenium.WaitUntilCollectionIsVisible(Locator);
        }

        public void WaitUntilVisibleElementIsNot()
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
