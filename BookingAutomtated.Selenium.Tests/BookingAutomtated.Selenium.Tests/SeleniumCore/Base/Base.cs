using BookingAutomtated.Selenium.Tests.SeleniumCore.Helpers;

using System.Collections.Generic;

namespace BookingAutomtated.Selenium.Tests.SeleniumCore.Base
{
    public abstract class Base
    {
        private readonly Dictionary<string, IPage> PageElements = new Dictionary<string, IPage>();

        private readonly Dictionary<string, List<IPage>> PageElementLists = new Dictionary<string, List<IPage>>();

        public IPage FindById(string locator)
        {
            return FindElementBy(FindBy.Id, locator);
        }

        public IPage FindByCss(string locator)
        {
            return FindElementBy(FindBy.Css, locator);
        }

        public IPage FindByName(string locator)
        {
            return FindElementBy(FindBy.Name, locator);
        }

        public IPage FindByClassName(string locator)
        {
            return FindElementBy(FindBy.ClassName, locator);
        }
        public IPage FindByTagName(string locator)
        {
            return FindElementBy(FindBy.TagName, locator);
        }

        public IPage FindByXPath(string locator)
        {
            return FindElementBy(FindBy.XPath, locator);
        }

        public List<IPage> FindElementsByCss(string locator)
        {
            return FindElementsBy(FindBy.Css, locator);
        }

        public List<IPage> FindElementsByXPath(string locator)
        {
            return FindElementsBy(FindBy.XPath, locator);
        }

        public List<IPage> FindElementsById(string locator)
        {
            return FindElementsBy(FindBy.Id, locator);
        }

        public List<IPage> FindElementsByClassName(string locator)
        {
            return FindElementsBy(FindBy.ClassName, locator);
        }

        public List<IPage> FindElementsByTagName(string locator)
        {
            return FindElementsBy(FindBy.TagName, locator);
        }

        private IPage FindElementBy(FindBy findBy, string locator)
        {
            var key = $"{findBy}-{locator}";

            if (PageElements.ContainsKey(key))
                return PageElements[key];

            var element = GetElement(findBy, locator);

            PageElements[key] = element;

            return element;
        }

        private List<IPage> FindElementsBy(FindBy findBy, string locator)
        {
            var key = $"{findBy}-{locator}";

            if (PageElementLists.ContainsKey(key))
                return PageElementLists[key];

            var elements = FindElements(findBy, locator);

            PageElementLists[key] = elements;

            return elements;
        }

        private IPage GetElement(FindBy findBy, string locator)
        {
            var selenium = new Extensions.Selenium();
            return selenium.FindElement(findBy, locator);
        }

        private List<IPage> FindElements(FindBy findBy, string locator)
        {
            var selenium = new Extensions.Selenium();
            return selenium.FindElements(findBy, locator);
        }
    }
}
