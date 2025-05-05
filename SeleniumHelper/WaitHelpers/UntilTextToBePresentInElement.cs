using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Roys_Selenium_Portfolio;

public class UntilTextToBePresentInElement
{
    private readonly WebDriverWait _wait;
    public UntilTextToBePresentInElement(WebDriverWait wait)
    {
        _wait = wait;
    }

    public bool ByID(string id, string text)
    {
        return _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.Id(id), text));
    }

    public bool  ByName(string name, string text)
    {
        return _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.Name(name), text));
    }
}