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
using Roys_Selenium_Portfolio;

namespace Roys_Selenium_Portfolio.Project_1___CuraHealthcareService
{
    public class CHSTestLogin : TestBase
    {

        public CHSTestLogin(ITestOutputHelper output) : base(output)
        {
        }
        

        [Fact]
        public void correct_login()
        {
            try
            {
                var login = new CHSLogin(_driver);
                
                login.enterusername();
                login.enterpassword();
                login.submit();
                Thread.Sleep(1000);
                
                var url = login.GetDriver().Url;
                url.Should().NotBeEmpty();
                url.Should().Contain("/#appointment");
                url.Should().NotBe("https://katalon-demo-cura.herokuapp.com/");
                url.Should().NotBeNull();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Dispose();
                throw;
            }
            
            Dispose();
        }

        [Fact]
        public void incorrect_login_username()
        {
            try
            {
                var login = new CHSLogin(_driver);
                login.enterusername("notJohnDoe");
                login.enterpassword();
                var previousHtml = _driver.PageSource;
                login.submit();
                Thread.Sleep(1000);
                
                string currentHtml = login.GetDriver().PageSource;
            
                var url = login.GetDriver().Url;
                url.Should().NotBeEmpty();
                url.Should().Contain("profile.php#login");
                url.Should().NotBeNull();
                currentHtml.Should().NotBe(previousHtml);
                currentHtml.Should().Contain("Login failed! Please ensure the username and password are valid.");
            }
            catch (Exception e)
            {
                output.WriteLine(e.StackTrace);
                Dispose();
                throw;
            }
            
            Dispose();
        }

        [Fact]
        public void incorrect_login_password()
        {
            try
            {
                var login = new CHSLogin(_driver);
                login.enterusername();
                login.enterpassword("incorrectpassword");
                var previousHtml = _driver.PageSource;
                login.submit();
                Thread.Sleep(1000);
                
                string currentHtml = login.GetDriver().PageSource;
                
                var url = login.GetDriver().Url;
                url.Should().NotBeEmpty();
                url.Should().Contain("profile.php#login");
                url.Should().NotBeNull();
                currentHtml.Should().NotBe(previousHtml);
                currentHtml.Should().Contain("Login failed! Please ensure the username and password are valid.");
            }
            catch (Exception e)
            {
                output.WriteLine(e.StackTrace);
                Dispose();
                throw;
            }
            
            Dispose();
        }
    }
}