using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit.Abstractions;

namespace Roys_Selenium_Portfolio.Project_2___OrangeHRMLive;

public class OrangeTestLogin : TestBase
{
    public OrangeTestLogin(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void correctLogin()
    {
        try
        {
            var login = new OrangeLogin(_driver);
            login.EnterUsername();
            login.EnterPassword();
            login.Submit();
            login.waitSucessfulLogin();

            var url = login.GetDriver().Url;
            url.Should().NotBeEmpty();
            url.Should().Contain("/web/index.php/dashboard/index");
            url.Should().NotBe("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            url.Should().NotBeNull();
        }
        catch (Exception e)
        {
            output.WriteLine(e.ToString());
            Dispose();
            throw;
        }
    }

    [Fact]
    public void CustomLogin()
    {
        try
        {
            initlizeSecretsOrangeHrm();
            var login = new OrangeLogin(_driver);
            login.EnterUsername(credentials.Username);
            login.EnterPassword(credentials.Password);
            login.Submit();
            login.waitSucessfulLogin();
        }
        catch (Exception e)
        {
            output.WriteLine(e.ToString());
            throw;
        }
    }
}