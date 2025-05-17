using FluentAssertions;
using Xunit.Abstractions;

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
                
                var url = login.Url();
                login.QuiteAndDispose();
                
                url.Should().NotBeEmpty();
                url.Should().Contain("/#appointment");
                url.Should().NotBe("https://katalon-demo-cura.herokuapp.com/");
                url.Should().NotBeNull();
            }
            catch (Exception e)
            {
                output.WriteLine($"Error in correct_login: {e.Message}");
                output.WriteLine(e.StackTrace);
                throw;
            }
        }

        [Fact]
        public void incorrect_login_username()
        {
            try
            {
                var login = new CHSLogin(_driver);
                login.enterusername("notJohnDoe");
                login.enterpassword();
                var previousHtml = login.PageSource();
                login.submit();
                Thread.Sleep(1000);
                
                string currentHtml = login.PageSource();
                var url = login.Url();
                login.QuiteAndDispose();
                
                url.Should().NotBeEmpty();
                url.Should().Contain("profile.php#login");
                url.Should().NotBeNull();
                currentHtml.Should().NotBe(previousHtml);
                currentHtml.Should().Contain("Login failed! Please ensure the username and password are valid.");
            }
            catch (Exception e)
            {
                output.WriteLine($"Error in incorrect_login_username: {e.Message}");
                output.WriteLine(e.StackTrace);
                throw;
            }
        }

        [Fact]
        public void incorrect_login_password()
        {
            try
            {
                var login = new CHSLogin(_driver);
                login.enterusername();
                login.enterpassword("incorrectpassword");
                var previousHtml = login.PageSource();
                login.submit();
                Thread.Sleep(1000);
                string currentHtml = login.PageSource();
                var url = login.Url();
                login.QuiteAndDispose();
                
                url.Should().NotBeEmpty();
                url.Should().Contain("profile.php#login");
                url.Should().NotBeNull();
                currentHtml.Should().NotBe(previousHtml);
                currentHtml.Should().Contain("Login failed! Please ensure the username and password are valid.");
            }
            catch (Exception e)
            {
                output.WriteLine($"Error in incorrect_login_password: {e.Message}");
                output.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}