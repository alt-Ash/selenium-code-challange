using BookingAutomtated.Selenium.Tests.SeleniumCore.Helpers;

using System.Collections.Generic;

namespace BookingAutomtated.Selenium.Tests.SeleniumCore.Base
{
    public abstract class Base
    {
        private readonly Dictionary<string, IPage> _pageElements = new Dictionary<string, IPage>();

        private readonly Dictionary<string, List<IPage>> _pageElementLists = new Dictionary<string, List<IPage>>();

        protected IPage FindById(string locator)
        {
            return FindElementBy(FindBy.Id, locator);
        }

        protected IPage FindByCss(string locator)
        {
            return FindElementBy(FindBy.Css, locator);
        }

        protected IPage FindByName(string locator)
        {
            return FindElementBy(FindBy.Name, locator);
        }

        protected IPage FindByClassName(string locator)
        {
            return FindElementBy(FindBy.ClassName, locator);
        }
        protected IPage FindByTagName(string locator)
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

        private protected IEnumerable<IPage> FindElementsByClassName(string locator)
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

            if (_pageElements.ContainsKey(key))
                return _pageElements[key];

            var element = GetElement(findBy, locator);

            _pageElements[key] = element;

            return element;
        }

        private List<IPage> FindElementsBy(FindBy findBy, string locator)
        {
            var key = $"{findBy}-{locator}";

            if (_pageElementLists.ContainsKey(key))
                return _pageElementLists[key];

            var elements = FindElements(findBy, locator);

            _pageElementLists[key] = elements;

            return elements;
        }

        private static IPage GetElement(FindBy findBy, string locator)
        {
            var selenium = new Extensions.Selenium();
            return selenium.FindElement(findBy, locator);
        }

        private static List<IPage> FindElements(FindBy findBy, string locator)
        {
            var selenium = new Extensions.Selenium();
            return selenium.FindElements(findBy, locator);
        }
    }
}
