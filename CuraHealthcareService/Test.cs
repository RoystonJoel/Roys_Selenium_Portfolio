namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit.Abstractions;

public class Test : IDisposable
{
    protected  readonly ITestOutputHelper output;
    protected  readonly ChromeOptions options;
    protected  readonly ChromeDriver _driver;
    protected  readonly WebDriverWait wait;
    protected  readonly string[] scopes;
    
    public Test(ITestOutputHelper output)
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
}