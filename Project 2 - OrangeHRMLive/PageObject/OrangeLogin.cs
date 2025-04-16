﻿using Microsoft.VisualStudio.TestPlatform.Utilities;
using OpenQA.Selenium;

namespace Roys_Selenium_Portfolio.Project_2___OrangeHRMLive;


    public class OrangeLogin : PageBase
    {
        private readonly SeleniumHelper _helper;

        public OrangeLogin(IWebDriver driver) : base(driver)
        {
            _helper = new SeleniumHelper(driver);
            _helper.Visit("https://opensource-demo.orangehrmlive.com/");
            _helper.wait().waitUntilVisableByName("password");
        }

        public void EnterUsername()
        {
            _helper.sendkeys().ByName(GetUsername(), "username");
        }
        public void EnterUsername(string username)
        {
            _helper.sendkeys().ByName(username, "username");
        }
        public void EnterPassword()
        {
            _helper.sendkeys().ByName(GetPassword(), "password");
        }
        public void EnterPassword(string password)
        {
            _helper.sendkeys().ByName(password, "password");
        }

        public string GetUsername()
        {
            return _helper.JavaScriptExecutor<string>("return document.querySelectorAll(\"p.oxd-text\")[0].textContent").Replace("Username : ", "");
        }
        
        public string GetPassword()
        {
            return _helper.JavaScriptExecutor<string>("return document.querySelectorAll(\"p.oxd-text\")[1].textContent").Replace("Password : ", "");
        }

        public void Submit()
        {
            _helper.click().ByClassName("oxd-button");
        }
        
        
    }
