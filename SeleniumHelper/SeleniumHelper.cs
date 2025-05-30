﻿using OpenQA.Selenium;


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
            //((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].innerHTML = '" + text + "';", _driver.FindElement(By.XPath(xpath)));
            JavaScriptExecutor<object>("arguments[0].innerHTML = '" + text + "';",GetElement(By.XPath(xpath)));
        }
        
        public T JavaScriptExecutor<T>(string javascript, IWebElement field)
        {
            return (T)((IJavaScriptExecutor)_driver).ExecuteScript(javascript, field);
        }
        
        public T JavaScriptExecutor<T>(string javascript)
        {
            return (T)((IJavaScriptExecutor)_driver).ExecuteScript(javascript);
        }

        public void JavaScriptExecutor(string javascript)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(javascript);
        }

        public SendKeysFunctions sendkeys() 
        {
            return new SendKeysFunctions(_driver);
        }

        public GetText Gettext()
        {
            return new GetText(_driver);
        }

        public GetAttribute GetAttribute()
        {
            return new GetAttribute(_driver);
        }

        public WaitHelper wait()
        {
            return new WaitHelper(_driver);
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

        public string PageSource()
        {
            return _driver.PageSource;
        }

        public string Url()
        {
            return _driver.Url;
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }
    }
}
