using OpenQA.Selenium;

using System.Collections.Generic;

namespace BookingAutomtated.Selenium.Tests.SeleniumCore.Helpers
{
    public interface IPage
    {
        bool IsVisible { get; }
        string Text { get; }
        void WaitForVisableElement();
        void WaitForVisibleCollection();
        void WaitUntilVisableElementIsNot();
        void Click();
        string GetAttribute(string attribute);
        void SendKeys(string attribute);
        IEnumerable<IWebElement> GetInnerElementByProperty(string innerElement);
        void ClickElementInTable(string innerElement, string attribute, string elementStart, string elementEnd);
        void ScrollToElement();
    }
}