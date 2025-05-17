namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium;

public class GetAttribute
{
    private readonly ElementInteraction _elementInteraction;
    public GetAttribute(IWebDriver  driver)
    {
        _elementInteraction = new ElementInteraction(driver);
    }
    
    public string ByXpath(string xpath, string attributeName)
    {
        return _elementInteraction.GetAttribute(By.XPath(xpath),attributeName);
    }
    
    public string ById(string id, string attributeName)
    {
        return _elementInteraction.GetAttribute(By.Id(id),attributeName);
    }

    public string ByLinkText(string linktext, string attributeName)
    {
        return _elementInteraction.GetAttribute(By.LinkText(linktext),attributeName);
    }

    public string ByClassName(string classname, string attributeName)
    {
        return _elementInteraction.GetAttribute(By.ClassName(classname),attributeName);
    }
    
}