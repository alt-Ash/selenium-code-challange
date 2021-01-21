using System.Collections.Generic;
using OpenQA.Selenium;

namespace BookingAutomated.Selenium.Tests.SeleniumCore.Interfaces
{
    public interface IPage
    {
        bool IsVisible { get; }
        string Text { get; }
        void WaitForVisibleElement();
        void WaitForVisibleCollection();
        void WaitUntilVisibleElementIsNot();
        void Click();
        string GetAttribute(string attribute);
        void SendKeys(string attribute);
        IEnumerable<IWebElement> GetInnerElementByProperty(string innerElement);
        void ClickElementInTable(string innerElement, string attribute, string elementStart, string elementEnd);
        void ScrollToElement();
    }
}