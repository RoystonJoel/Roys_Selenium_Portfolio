using OpenQA.Selenium;

namespace Roys_Selenium_Portfolio
{
    public class Click
    {
        private readonly ElementInteraction   _elementInteraction;


        public Click(IWebDriver  driver)
        {
            _elementInteraction = new ElementInteraction(driver);
        }

        //clicks on anything using the elements xpath. Uses wait helpers incase page doesn't respond immediately 
        public void ByXpath(string xpath)
        {
            _elementInteraction.Click(By.XPath(xpath));
        }

        //clicks on anything that has an ID on it. Uses wait helpers incase page doesn't respond immediately
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
        
    }
}
