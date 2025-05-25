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
            _elementInteraction.IndexLocator(By.CssSelector(cssselector), elementIndex).Click();
        }
        
    }
}
