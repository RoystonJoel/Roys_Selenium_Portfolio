using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Roys_Selenium_Portfolio;

public class UntilTextToBePresentInElement
{
    private readonly WaitInteractions _waitInteractions;
    public UntilTextToBePresentInElement(WebDriverWait wait)
    {
        _waitInteractions = new WaitInteractions(wait);
    }

    public bool ByID(string id, string text)
    {
        return _waitInteractions.TextToBePresentInElementLocated(By.Id(id), text);
    }

    public bool  ByName(string name, string text)
    {
        return _waitInteractions.TextToBePresentInElementLocated(By.Name(name), text);
    }
}