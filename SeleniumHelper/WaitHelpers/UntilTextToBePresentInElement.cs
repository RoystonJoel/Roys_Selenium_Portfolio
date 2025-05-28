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

    public bool ByCssSelector(string cssSelector, string text)
    {
        return _waitInteractions.TextToBePresentInElementLocated(By.CssSelector(cssSelector),text);
    }
    
    public void ByCssSelector(string cssSelector, string text, int elementIndex)
    {
        IWebElement element = _waitInteractions.UntilElementAtIndexIsPresent(By.CssSelector(cssSelector), elementIndex);
        try
        {
            _waitInteractions.WaitUntil<IWebElement>(driver =>
            {
                if (element.Text.Contains(text))
                {
                    return element;
                }
                return null;
            });
        }
        catch (Exception e)
        {
            throw new Exception($"string in element does not contain sequence of characters from expected string. Element: {element.Text} expected: {text}.... {e.Message}");
        }
        
    }
}