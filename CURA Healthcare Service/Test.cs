namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit.Abstractions;

public class Test : IDisposable
{
    protected  readonly ITestOutputHelper output;
    protected  readonly ChromeOptions _options;
    protected  readonly ChromeDriver driver;
    protected  readonly WebDriverWait wait;
    protected  readonly string[] scopes;
    
    public Test(ITestOutputHelper output)
    {
        _options = new ChromeOptions();
        //_options.AddArgument("--headless");
        this.output = output;
        driver = new ChromeDriver(_options);
        driver.Manage().Window.Maximize(); //fullscreen
    }
    
    public void Dispose()
    {
        try
        {
            driver.Quit();
            driver.Dispose();
        }
        catch (Exception ex)
        {
            output.WriteLine($"Error during Dispose: {ex.Message}");
        }
    }
}