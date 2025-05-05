using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Roys_Selenium_Portfolio;

public class UntilVisible
{
    private readonly WebDriverWait _wait;
    
    public UntilVisible(WebDriverWait wait)
    {
        _wait = wait;
    }

    public void ByID(string id)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
    }

    public void ByName(string name)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(By.Name(name)));
    }
}