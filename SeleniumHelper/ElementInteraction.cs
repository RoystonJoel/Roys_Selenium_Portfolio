using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Roys_Selenium_Portfolio;

// New ElementInteraction class
public class ElementInteraction
{
    private readonly IWebDriver _driver; // Use IWebDriver

    public ElementInteraction(IWebDriver driver)
    {
        _driver = driver;
    }

    public IWebElement FindElement(By by)
    {
        return _driver.FindElement(by);
    }

    public IReadOnlyCollection<IWebElement> FindElements(By locator)
    {
        return _driver.FindElements(locator);
    }

    public void Click(By by)
    {
        FindElement(by).Click();
    }

    public void SendKeys(By by, string text)
    {
        FindElement(by).SendKeys(text);
    }

    public string GetAttribute(By by, string attributeName)
    {
        return FindElement(by).GetAttribute(attributeName);
    }

    public string GetText(By by)
    {
        return FindElement(by).Text;
    }

    public bool IsSelected(By by)
    {
        return FindElement(by).Selected;
    }

    public SelectElement Select(By by)
    {
        return new SelectElement(FindElement(by));
    }

    public IWebElement LocateElementAtIndex(By by, int elementIndex)
    {
        IReadOnlyCollection<IWebElement> allElements = FindElements(by);
        if (elementIndex >= 0 && elementIndex < allElements.Count)
        {
             return allElements.ElementAt(elementIndex); // Or use allElements.ToList()[elementIndex]
        }
        throw new ArgumentOutOfRangeException($"Cannot click element at index {elementIndex}. Only {allElements.Count} elements found for locator {by}");
    }
}