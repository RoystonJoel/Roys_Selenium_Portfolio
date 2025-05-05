namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

public class WaitHelper
{
    private readonly WebDriverWait _wait;

    public WaitHelper(IWebDriver driver)
    {
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

    }
    
    public UntilVisible UntilVisible()
    {
        return new UntilVisible(_wait);
    }

    public UntilClickable UntilClickable()
    {
        return new UntilClickable(_wait);
    }

    public UntilTextToBePresentInElement UntilTextToBePresentInElement()
    {
        return new UntilTextToBePresentInElement(_wait);
    }

    public bool UntilUrlContains(string url)
    {
        return _wait.Until(ExpectedConditions.UrlContains(url));
    }
    
}