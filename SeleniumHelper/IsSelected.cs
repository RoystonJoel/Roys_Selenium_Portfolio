namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium;

public class IsSelected
{
    private readonly ElementInteraction   _elementInteraction;
    
    public IsSelected(IWebDriver driver)
    {
        _elementInteraction = new ElementInteraction(driver);
    }

    public bool IsSelectedByid(string id)
    {
        return _elementInteraction.IsSelected(By.Id(id));
    }
}