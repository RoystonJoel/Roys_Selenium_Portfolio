using OpenQA.Selenium;


namespace Roys_Selenium_Portfolio;

public class Dropdown
{
    private readonly ElementInteraction _elementInteraction;
    
    public Dropdown(IWebDriver driver)
    {
        _elementInteraction = new ElementInteraction(driver);
    }
    
    public Select ById(string id)
    {
        return new Select(_elementInteraction.Select(By.Id(id)));
    }

    public Select ByXpath(string xpath)
    {
        return new Select(_elementInteraction.Select(By.XPath(xpath)));
    }
}