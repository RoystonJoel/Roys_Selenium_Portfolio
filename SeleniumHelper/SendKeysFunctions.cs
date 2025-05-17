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

        //clicks on anything using the elements ID. Uses wait helpers incase page doesn't respond immediately
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

        public void ByName(string text, string name)
        {
            _elementInteraction.SendKeys(By.Name(name),text);
        }
    }
}
