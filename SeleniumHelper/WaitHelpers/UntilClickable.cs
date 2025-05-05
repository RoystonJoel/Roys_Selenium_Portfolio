using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Roys_Selenium_Portfolio;

public class UntilClickable
{
    private readonly WebDriverWait _wait;
    
    public UntilClickable(WebDriverWait wait)
    {
        _wait = wait;
    }

    public void ByID(string id)
    { 
        _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));
    }

    public void ByName(string name)
    {
        _wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(name)));
    }
}