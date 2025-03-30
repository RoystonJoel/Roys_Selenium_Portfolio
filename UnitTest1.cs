using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using System.Diagnostics;
using Xunit.Abstractions;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Buffers.Text;
using OpenQA.Selenium.Internal;

namespace Roys_Selenium_Framework
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;
        private readonly ChromeOptions _options;
        private readonly ChromeDriver driver;
        private readonly WebDriverWait wait;
        private readonly string[] scopes;
        

        public UnitTest1(ITestOutputHelper output)
        {
            _options = new ChromeOptions();
            //_options.AddArgument("--headless");
            this.output = output;
            driver = new ChromeDriver(_options);
            driver.Manage().Window.Maximize(); //fullscreen
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
        

        [Fact]
        public void Test_one()
        {
            SeleniumHelper Helper = new SeleniumHelper(driver,wait);
            Helper.Visit("https://katalon-demo-cura.herokuapp.com/");
            
            
            Helper.Dispose();
        }
    }
}