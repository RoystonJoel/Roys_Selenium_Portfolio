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
        private readonly ChromeDriver _driver;

        public SeleniumHelper(ChromeDriver driver) 
        {
            _driver = driver;
        }

        //switchs the driver to operate on another tab
        public void SwitchTabs(int tabNumber)
        {
            IList<string> windowHandles = new List<string>(_driver.WindowHandles);
            _driver.SwitchTo().Window(windowHandles[tabNumber]);
        }

        //if the textbox is atually a div element and not a <input>, use this.
        public void Force_SendKeys(string _text, string _Xpath)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].innerHTML = '" + _text + "';", _driver.FindElement(By.XPath(_Xpath)));
        }

        public SendKeysFunctions sendkeys() 
        {
            return new SendKeysFunctions(_driver);
        }

        public GrabFunctions grabvalue()
        {
            return new GrabFunctions(_driver);
        }

        public WaitHelper wait()
        {
            return new WaitHelper(_driver);
        }
      
        public ClickFunctions click()
        {
            return new ClickFunctions(_driver);
        }

        public DropdownFunctions dropdown()
        {
            return new DropdownFunctions(_driver);
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

        public ChromeDriver GetDriver()
        {
            return _driver;
        }
    }
}
