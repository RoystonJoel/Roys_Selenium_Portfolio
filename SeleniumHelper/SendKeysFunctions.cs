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

        private readonly ChromeDriver _driver;

        public SendKeysFunctions(IWebDriver driver)
        {
            _driver = driver;
        }

        //types in a text box
        public void ByXpath(string _text, string _Xpath)
        {
            _driver.FindElement(By.XPath(_Xpath)).SendKeys(_text);
        }

        //clicks on anything using the elements ID. Uses wait helpers incase page doesn't respond immediately
        public void ById(string _text, string _id)
        {
            _driver.FindElement(By.Id(_id)).SendKeys(_text);
        }

        public void ByLinkText(string _text, string _linktext)
        {
            _driver.FindElement(By.LinkText(_linktext)).SendKeys(_text);
        }

        public void ByClassName(string _text, string _classname)
        {
            _driver.FindElement(By.ClassName(_classname)).SendKeys(_text);
        }
    }
}
