namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

public class WaitHelper
{
    private readonly WebDriverWait _wait;
    private readonly IWebDriver _driver;

    public WaitHelper(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
    }
    
    public IWebElement WaitUntilVisible(By by)
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(by));
    }

    public IWebElement WaitUntilClickable(By by)
    {
        return _wait.Until(ExpectedConditions.ElementToBeClickable(by));
    }

    public bool WaitUntilTextToBePresentInElement(By by, string text)
    {
        return _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(by, text));
    }

    public bool WaitUntilUrlContains(string url)
    {
        return _wait.Until(ExpectedConditions.UrlContains(url));
    }
    
}