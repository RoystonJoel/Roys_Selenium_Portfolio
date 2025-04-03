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

namespace Roys_Selenium_Portfolio
{
    public class Test_Login : Test
    {

        public Test_Login(ITestOutputHelper output) : base(output)
        {
        }
        

        [Fact]
        public void correct_login()
        {
            var login = new Login(driver);
            
            login.enterusername();
            login.enterpassword();
            login.submit();
            Thread.Sleep(1000);

            try
            {
                var url = login.GetHelper().GetDriver().Url;
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
            var login = new Login(driver);
            login.enterusername("notJohnDoe");
            login.enterpassword();
            var previousHtml = driver.PageSource;
            login.submit();
            Thread.Sleep(1000);
            
            string currentHtml = login.GetHelper().GetDriver().PageSource;
            
            try
            {
                var url = login.GetHelper().GetDriver().Url;
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
            var login = new Login(driver);
            login.enterusername();
            login.enterpassword("incorrectpassword");
            var previousHtml = driver.PageSource;
            login.submit();
            Thread.Sleep(1000);
            
            string currentHtml = login.GetHelper().GetDriver().PageSource;
            
            try
            {
                var url = login.GetHelper().GetDriver().Url;
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