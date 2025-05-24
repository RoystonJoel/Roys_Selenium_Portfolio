using OpenQA.Selenium;

namespace Roys_Selenium_Portfolio
{
    public class Click
    {
        private readonly ElementInteraction _elementInteraction;


        public Click(IWebDriver  driver)
        {
            _elementInteraction = new ElementInteraction(driver);
        }
        
        public void ByXpath(string xpath)
        {
            _elementInteraction.Click(By.XPath(xpath));
        }
        
        public void ById(string id)
        {
            _elementInteraction.Click(By.Id(id));
        }

        public void ByLinkText(string linktext) 
        {
            _elementInteraction.Click(By.LinkText(linktext));
        }

        public void ByClassName(string classname)
        {
            _elementInteraction.Click(By.ClassName(classname));
        }

        public void ByCssSelector(string cssselector)
        {
            _elementInteraction.Click(By.CssSelector(cssselector));
        }
        
        public void ByCssSelector(string cssselector, int elementIndex)
        {
            By arrowLocator = By.CssSelector(cssselector);
            IReadOnlyCollection<IWebElement> allElements = _elementInteraction.FindElements(arrowLocator);
            if (elementIndex >= 0 && elementIndex < allElements.Count)
            {
                IWebElement targetElement = allElements.ElementAt(elementIndex); // Or use allElements.ToList()[elementIndex]
                targetElement.Click();
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Cannot click element at index {elementIndex}. Only {allElements.Count} elements found for locator {arrowLocator}");
            }
        }
        
    }
}
