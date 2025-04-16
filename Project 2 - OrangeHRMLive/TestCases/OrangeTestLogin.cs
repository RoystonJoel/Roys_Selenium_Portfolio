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
        Thread.Sleep(9000);
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