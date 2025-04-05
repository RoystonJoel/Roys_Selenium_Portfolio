using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit.Abstractions;

namespace Roys_Selenium_Portfolio
{
    public class SeleniumHelper
    {
        private readonly IWebDriver _driver;

        public SeleniumHelper(IWebDriver driver) 
        {
            _driver = driver;
        }
        
        public IWebElement GetElement(By by)
        {
            return new ElementInteraction(_driver).FindElement(by);
        }

        //switchs the driver to operate on another tab
        public void SwitchTabs(int tabNumber)
        {
            IList<string> windowHandles = new List<string>(_driver.WindowHandles);
            _driver.SwitchTo().Window(windowHandles[tabNumber]);
        }

        //if the textbox is atually a div element and not a <input>, use this.
        public void ForceSendKeys(string text, string xpath)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].innerHTML = '" + text + "';", _driver.FindElement(By.XPath(xpath)));
        }

        public SendKeysFunctions sendkeys() 
        {
            return new SendKeysFunctions(_driver);
        }

        public GetText grabtext()
        {
            return new GetText(_driver);
        }

        public GetAttribute GetAttribute()
        {
            return new GetAttribute(_driver);
        }

        public Wait wait()
        {
            return new Wait(_driver);
        }
      
        public Click click()
        {
            return new Click(_driver);
        }

        public Dropdown dropdown()
        {
            return new Dropdown(_driver);
        }

        public IsSelected isselected()
        {
            return new IsSelected(_driver);
        }

        //Logs in to any homepage you pass into it
        public void Visit(string Url)
        {
            _driver.Navigate().GoToUrl(Url);
        }

        //closes the drivers windows, and closes the session
        public void Dispose()
        {
            _driver.Dispose();  
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }
    }
}
