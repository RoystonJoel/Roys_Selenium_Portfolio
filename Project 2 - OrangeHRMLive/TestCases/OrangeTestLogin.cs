﻿using FluentAssertions;
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

    [Fact]
    public void IncorrectLogin()
    {
        try
        {
            var login = new OrangeLogin(_driver);
            login.EnterUsername("Incorrect username");
            login.EnterPassword("Incorrect password");
            login.Submit();
            
            var url = login.GetDriver().Url;
            url.Should().NotBeEmpty();
            url.Should().NotBeNull();
            url.Should().Contain("/web/index.php/auth/login");
            output.WriteLine(login.GetPageAlert());
            login.GetPageAlert().Should().Contain("Invalid credentials");
        }
        catch (Exception e)
        {
            output.WriteLine(e.ToString());
            throw;
        }
    }
}