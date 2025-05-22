namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium.Chrome;
using Xunit.Abstractions;

public class TestBase : IDisposable
{
    protected  readonly ITestOutputHelper output;
    private  readonly ChromeOptions options;
    protected  readonly ChromeDriver _driver;
    protected  OrangeHrmCredentials credentials;
    
    public TestBase(ITestOutputHelper output)
    {
        options = new ChromeOptions();
        //options.AddArgument("--headless");
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
        this.output = output;
        _driver = new ChromeDriver(options);
        _driver.Manage().Window.Maximize(); //fullscreen
    }
    
    public void Dispose()
    {
        try
        {
            _driver.Quit();
            _driver.Dispose();
        }
        catch (Exception ex)
        {
            output.WriteLine($"Error during Dispose: {ex.Message}");
        }
    }

    public void initlizeSecretsOrangeHrm()
    {
        credentials = SecretReader.GetOrangeHrmCredentials(output);
    }
}