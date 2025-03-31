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

namespace Roys_Selenium_Portfolio
{
    public class Test_Login
    {
        private readonly ITestOutputHelper output;
        private readonly ChromeOptions _options;
        private readonly ChromeDriver driver;
        private readonly WebDriverWait wait;
        private readonly string[] scopes;
        

        public Test_Login(ITestOutputHelper output)
        {
            _options = new ChromeOptions();
            //_options.AddArgument("--headless");
            this.output = output;
            driver = new ChromeDriver(_options);
            driver.Manage().Window.Maximize(); //fullscreen
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
        

        [Fact]
        public void correct_login()
        {
            var helper = new SeleniumHelper(driver,wait);
            helper.Visit("https://katalon-demo-cura.herokuapp.com/");
            helper.click().ById("btn-make-appointment");
            var usr_name = helper.grabvalue().ByXpath("//input[@placeholder='Username']");
            var password = helper.grabvalue().ByXpath("//input[@placeholder='Password']");
            helper.sendkeys().ById(usr_name, "txt-username");
            helper.sendkeys().ById(password, "txt-password");
            //output.WriteLine("user name is :" + usr_name);
            //output.WriteLine("user name is :" + password);
            helper.click().ById("btn-login");
            Thread.Sleep(1000);

            try
            {
                var url = helper.GetURL();
                url.Should().NotBeEmpty();
                url.Should().Contain("/#appointment");
                url.Should().NotBe("https://katalon-demo-cura.herokuapp.com/");
                url.Should().NotBeNull();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                helper.Dispose();
                throw;
            }
            
            helper.Dispose();
        }

        [Fact]
        public void incorrect_login_username()
        {
            var helper = new SeleniumHelper(driver,wait);
            helper.Visit("https://katalon-demo-cura.herokuapp.com/");
            helper.click().ById("btn-make-appointment");
            var password = helper.grabvalue().ByXpath("//input[@placeholder='Password']");
            helper.sendkeys().ById("notJohnDoe", "txt-username");
            helper.sendkeys().ById(password, "txt-password");
            var previousHtml = driver.PageSource;
            helper.click().ById("btn-login");
            Thread.Sleep(1000);
            string currentHtml = driver.PageSource;
            
            try
            {
                var url = helper.GetURL();
                url.Should().NotBeEmpty();
                url.Should().Contain("profile.php#login");
                url.Should().NotBeNull();
                currentHtml.Should().NotBe(previousHtml);
                currentHtml.Should().Contain("Login failed! Please ensure the username and password are valid.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                helper.Dispose();
                throw;
            }
            
            helper.Dispose();
        }
    }
}