using OpenQA.Selenium;

namespace Roys_Selenium_Portfolio
{
    public class SendKeysFunctions
    {

        private readonly ElementInteraction   _elementInteraction;

        public SendKeysFunctions(IWebDriver driver)
        {
            _elementInteraction = new ElementInteraction(driver);
        }

        //types in a text box
        public void ByXpath(string text, string xpath)
        {
            _elementInteraction.SendKeys(By.XPath(xpath),text);
        }
        
        public void ById(string text, string id)
        {
            _elementInteraction.SendKeys(By.Id(id),text);
        }

        public void ByLinkText(string text, string linktext)
        {
            _elementInteraction.SendKeys(By.LinkText(linktext),text);
        }

        public void ByClassName(string text, string classname)
        {
            _elementInteraction.SendKeys(By.ClassName(classname),text);
        }
        
        public void ByCssSelector(string text, string cssselector,int elementIndex)
        {
            _elementInteraction.IndexLocator(By.CssSelector(cssselector),elementIndex).SendKeys(text);
        }

        public void ByName(string text, string name)
        {
            _elementInteraction.SendKeys(By.Name(name),text);
        }
    }
}
