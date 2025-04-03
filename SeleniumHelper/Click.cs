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
    public class Click
    {
        private readonly ElementInteraction   _elementInteraction;


        public Click(IWebDriver  driver)
        {
            _elementInteraction = new ElementInteraction(driver);
        }

        //clicks on anything using the elements xpath. Uses wait helpers incase page doesn't respond immediately 
        public void ByXpath(string _xpath)
        {
            _elementInteraction.Click(By.XPath(_xpath));
        }

        //clicks on anything that has an ID on it. Uses wait helpers incase page doesn't respond immediately
        public void ById(string _id)
        {
            _elementInteraction.Click(By.Id(_id));
        }

        public void ByLinkText(string _linktext) 
        {
            _elementInteraction.Click(By.LinkText(_linktext));
        }

        public void ByClassName(string _classname)
        {
            _elementInteraction.Click(By.ClassName(_classname));
        }
        
    }
}
