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

    private IWebElement FindElement(By by)
    {
        return _driver.FindElement(by);
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
    
}