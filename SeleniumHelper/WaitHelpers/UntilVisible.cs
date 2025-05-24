using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Roys_Selenium_Portfolio;

public class UntilVisible
{
    private readonly WaitInteractions _waitInteractions;
    
    public UntilVisible(WebDriverWait wait)
    {
        _waitInteractions = new WaitInteractions(wait);
    }

    public void ByID(string id)
    {
        _waitInteractions.UntilVisible(By.Id(id));
    }

    public void ByName(string name)
    {
        _waitInteractions.UntilVisible(By.Name(name));
    }
    
    public void ByClassName(string classname)
    {
        _waitInteractions.UntilVisible(By.ClassName(classname));
    }

    public void ByXpath(string xpath)
    {
        _waitInteractions.UntilVisible(By.XPath(xpath));
    }

    public void ByCssSelector(string cssSelector)
    {
        _waitInteractions.UntilVisible(By.CssSelector(cssSelector));
    }
}