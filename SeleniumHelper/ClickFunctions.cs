using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Roys_Selenium_Portfolio
{
    public class ClickFunctions
    {
        private readonly ChromeDriver _driver;


        public ClickFunctions(ChromeDriver driver)
        {
            _driver = driver;
        }

        //clicks on anything using the elements xpath. Uses wait helpers incase page doesn't respond immediately 
        public void ByXpath(string _xpath)
        {
            _driver.FindElement(By.XPath(_xpath)).Click();
        }

        //clicks on anything that has an ID on it. Uses wait helpers incase page doesn't respond immediately
        public void ById(string _id)
        {
            _driver.FindElement(By.Id(_id)).Click();
        }

        public void ByLinkText(string _linktext) 
        {
            _driver.FindElement(By.LinkText(_linktext)).Click();
        }

        public void ByClassName(string _classname)
        {
            _driver.FindElement(By.ClassName(_classname)).Click();
        }
        
    }
}
