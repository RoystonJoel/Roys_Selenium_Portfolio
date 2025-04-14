
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit.Abstractions;

namespace Roys_Selenium_Portfolio.Project_1___CuraHealthcareService
{
    public class CHSLogin : PageBase
    {
        private readonly SeleniumHelper _helper;


        public CHSLogin(IWebDriver driver) : base(driver)
        {
            _helper = new SeleniumHelper(driver);
            _helper.Visit("https://katalon-demo-cura.herokuapp.com/");
            _helper.click().ById("btn-make-appointment");
        }
        
        public void auto_login()
        {
            enterusername();
            enterpassword();
            submit();
        }

        public void enterusername()
        {
            string usr_name = _helper.GetAttribute().ByXpath("//input[@placeholder='Username']","value");
            _helper.sendkeys().ById(usr_name, "txt-username");
        }

        public void enterusername(string usr_name)
        {
            _helper.sendkeys().ById(usr_name, "txt-username");
        }

        public void enterpassword()
        {
            string password = _helper.GetAttribute().ByXpath("//input[@placeholder='Password']","value");
            _helper.sendkeys().ById(password, "txt-password");
        }

        public void enterpassword(string password)
        {
            _helper.sendkeys().ById(password, "txt-password");
        }

        public void submit()
        {
            _helper.click().ById("btn-login");
        }
    }
}