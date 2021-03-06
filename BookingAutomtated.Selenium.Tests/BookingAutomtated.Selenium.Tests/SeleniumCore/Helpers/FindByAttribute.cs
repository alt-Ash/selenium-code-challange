﻿using System;
using OpenQA.Selenium;

namespace BookingAutomated.Selenium.Tests.SeleniumCore.Helpers
{
    public class FindByAttribute
    {
        public static By FindByLocator(FindBy findBy, string locator)
        {
            By by = findBy switch
            {
                FindBy.Css => By.CssSelector(locator),
                FindBy.XPath => By.XPath(locator),
                FindBy.Id => By.Id(locator),
                FindBy.Name => By.Name(locator),
                FindBy.ClassName => By.ClassName(locator),
                FindBy.TagName => By.TagName(locator),
                _ => throw new ArgumentOutOfRangeException(nameof(findBy), findBy, null),
            };

            return by;
        }
    }
}
