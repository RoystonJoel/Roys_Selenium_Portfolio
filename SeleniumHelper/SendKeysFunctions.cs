using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void ByXpath(string _text, string _Xpath)
        {
            _elementInteraction.SendKeys(By.XPath(_Xpath),_text);
        }

        //clicks on anything using the elements ID. Uses wait helpers incase page doesn't respond immediately
        public void ById(string _text, string _id)
        {
            _elementInteraction.SendKeys(By.Id(_id),_text);
        }

        public void ByLinkText(string _text, string _linktext)
        {
            _elementInteraction.SendKeys(By.LinkText(_linktext),_text);
        }

        public void ByClassName(string _text, string _classname)
        {
            _elementInteraction.SendKeys(By.ClassName(_classname),_text);
        }
    }
}
