namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class GetAttribute
{
    private readonly ElementInteraction _elementInteraction;
    public GetAttribute(IWebDriver  driver)
    {
        _elementInteraction = new ElementInteraction(driver);
    }
    
    public string ByXpath(string _Xpath, string attributeName)
    {
        return _elementInteraction.GetAttribute(By.XPath(_Xpath),attributeName);
    }
    
    public string ById(string _id, string attributeName)
    {
        return _elementInteraction.GetAttribute(By.Id(_id),attributeName);
    }

    public string ByLinkText(string _linktext, string attributeName)
    {
        return _elementInteraction.GetAttribute(By.LinkText(_linktext),attributeName);
    }

    public string ByClassName(string _classname, string attributeName)
    {
        return _elementInteraction.GetAttribute(By.ClassName(_classname),attributeName);
    }
    
}