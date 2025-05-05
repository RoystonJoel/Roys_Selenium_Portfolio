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
        var login = new OrangeLogin(_driver);
        login.EnterUsername();
        login.EnterPassword();
        login.Submit();

        var url = login.GetDriver().Url;
        url.Should().NotBeEmpty();
        url.Should().Contain("/web/index.php/dashboard/index");
        url.Should().NotBe("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        url.Should().NotBeNull();
    }

    [Fact]
    public void CustomLogin()
    {
        initlizeSecretsOrangeHrm();
        var login = new OrangeLogin(_driver);
        login.EnterUsername(credentials.Username);
        login.EnterPassword(credentials.Password);
        login.Submit();
        Thread.Sleep(9000);
    }
}