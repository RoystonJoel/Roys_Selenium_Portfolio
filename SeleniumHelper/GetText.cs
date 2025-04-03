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
    
    public string ByXpath(string _Xpath)
    {
        return _elementInteraction.GetText(By.XPath(_Xpath));
    }
    
    public string ById(string _id)
    {
        return _elementInteraction.GetText(By.Id(_id));
        
    }

    public string ByLinkText(string _linktext)
    {
        return _elementInteraction.GetText(By.LinkText(_linktext));
    }

    public string ByClassName(string _classname)
    {
        return _elementInteraction.GetText(By.ClassName(_classname));
    }
    
}