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
        try {return _driver.FindElement(by);}
        catch (Exception e)
        {throw new Exception($"Could not find element at: {by}");}
    }

    public IReadOnlyCollection<IWebElement> FindElements(By by)
    {
        try {return _driver.FindElements(by);}
        catch  (Exception e)
        {throw new Exception($"Could not find element's at: {by}");}
    }

    public void Click(By by)
    {
        try {FindElement(by).Click();}
        catch  (Exception e)
        {throw new Exception($"Unable to click element at: {by}");}
    }

    public void SendKeys(By by, string text)
    {
        try {FindElement(by).SendKeys(text);}
        catch  (Exception e)
        {throw new Exception($"Unable to send keys to element at: {by}");}
    }

    public string GetAttribute(By by, string attributeName)
    {
        try
        {
            var attribute = FindElement(by).GetAttribute(attributeName);
            if (attribute == null)
            {
                throw new Exception($"attribute came back as NULL at: {by}");
            }
            return attribute;
        } catch  (Exception e)
        {throw new Exception($"Unable to get attribute from element at: {by}");}
    }

    public string GetText(By by)
    {
        try
        {
            var text = FindElement(by).Text;
            if (text == null)
            {
                throw new Exception($"text came back as NULL at: {by}");
            }
            return text;
        } catch  (Exception e)
        {throw new Exception($"Unable to get text from element at: {by}");}
    }

    public bool IsSelected(By by)
    {
        try {return FindElement(by).Selected;}
        catch  (Exception e)
        {throw new Exception($"Unable to see if element was selected or not at: {by}");}
    }

    public SelectElement Select(By by)
    {
        try {return new SelectElement(FindElement(by));}
        catch  (Exception e)
        {throw new Exception($"Unable to select element at: {by}");}
    }

    public IWebElement LocateElementAtIndex(By by, int elementIndex)
    {
        IReadOnlyCollection<IWebElement> allElements = FindElements(by);
        if (elementIndex >= 0 && elementIndex < allElements.Count)
        {
             return allElements.ElementAt(elementIndex); // Or use allElements.ToList()[elementIndex]
        }
        throw new ArgumentOutOfRangeException($"Cannot locate element at index {elementIndex}. Only {allElements.Count} elements found for locator {by}");
    }
}