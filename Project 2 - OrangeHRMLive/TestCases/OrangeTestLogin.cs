using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit.Abstractions;

namespace Roys_Selenium_Portfolio.Project_2___OrangeHRMLive;

public class OrangeTestLogin : TestBase
{
    public OrangeTestLogin(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void correct_login()
    {
        var login = new OrangeLogin(_driver);
        login.EnterUsername();
        login.EnterPassword();
        login.Submit();
        Thread.Sleep(9000);
    }
}