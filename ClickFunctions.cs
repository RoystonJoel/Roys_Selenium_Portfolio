using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Roys_Selenium_Framework
{
    public class ClickFunctions
    {
        private readonly ChromeDriver _driver;
        private readonly WebDriverWait _wait;

        public ClickFunctions(ChromeDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        //clicks on anything using the elements xpath. Uses wait helpers incase page doesn't respond immediately 
        public void ByXpath(string _xpath)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_xpath)));
            _driver.FindElement(By.XPath(_xpath)).Click();
        }

        //clicks on anything that has an ID on it. Uses wait helpers incase page doesn't respond immediately
        public void ById(string _id)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(_id)));
            _driver.FindElement(By.Id(_id)).Click();
        }

        public void ByLinkText(string _linktext) 
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText(_linktext)));
            _driver.FindElement(By.LinkText(_linktext)).Click();
        }

        public void ByClassName(string _classname)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName(_classname)));
            _driver.FindElement(By.ClassName(_classname)).Click();
        }

    }
}
