using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Roys_Selenium_Portfolio;

public class WaitInteractions
{
    private readonly WebDriverWait _wait;
    
    public WaitInteractions(WebDriverWait wait)
    {
        _wait = wait;
    }

    //waitUntil takes a Func<IWebDriver, TResult?> as a parameter, which is exactly what _wait.Until() expects.
    //TResult : notnull constraint ensures that the result is not null.
    public TResult WaitUntil<TResult>(Func<IWebDriver, TResult?> condition) where TResult : notnull
    { 
        return _wait.Until(condition);
    }

    public void UntilVisible(By by)
    {
        WaitUntil(ExpectedConditions.ElementIsVisible(by));
    }

    public bool TextToBePresentInElementLocated(By by, string text)
    {
        return WaitUntil(ExpectedConditions.TextToBePresentInElementLocated(by, text));
    }

    public void UntilClickable(By by)
    {
        WaitUntil(ExpectedConditions.ElementToBeClickable(by));
    }
    
    public IWebElement UntilElementAtIndexIsPresent(By by, int elementIndex)
    {
        // Wait until there are enough elements to access the desired index, and return that element.
        return WaitUntil(driver =>
        {
            //return new ElementInteraction(driver).UntilElementAtIndex(by,elementIndex);
            var elements = driver.FindElements(by);
            return elements.ElementAtOrDefault(elementIndex); // <-- Used here
        });
    }
}