namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class GetText
{
    private readonly ElementInteraction _elementInteraction;
    public GetText(IWebDriver driver)
    {
        _elementInteraction = new ElementInteraction(driver);
    }
    
    public string ByXpath(string xpath)
    {
        return _elementInteraction.GetText(By.XPath(xpath));
    }
    
    public string ById(string id)
    {
        return _elementInteraction.GetText(By.Id(id));
        
    }

    public string ByLinkText(string linktext)
    {
        return _elementInteraction.GetText(By.LinkText(linktext));
    }

    public string ByClassName(string classname)
    {
        return _elementInteraction.GetText(By.ClassName(classname));
    }
    public string ByClassName(string classname, string index)
    {
        return _elementInteraction.GetText(By.ClassName(classname));
    }
    
    
}