using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Roys_Selenium_Portfolio;

public class UntilClickable
{
    private readonly WaitInteractions _waitInteractions;
    
    public UntilClickable(WebDriverWait wait)
    {
        _waitInteractions = new WaitInteractions(wait);
    }

    public void ByID(string id)
    { 
        _waitInteractions.UntilClickable(By.Id(id));
    }

    public void ByName(string name)
    {
        _waitInteractions.UntilClickable(By.Name(name));
    }
}