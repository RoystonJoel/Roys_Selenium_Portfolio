namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class GrabFunctions
{
    private readonly ChromeDriver _driver;
    public GrabFunctions(ChromeDriver driver)
    {
        _driver = driver;
    }
    
    public string ByXpath(string _Xpath)
    {
        return _driver.FindElement(By.XPath(_Xpath)).GetAttribute("value");
    }
    
    public string ById(string _id)
    {
        return _driver.FindElement(By.Id(_id)).GetAttribute("value");
    }

    public string ByLinkText(string _linktext)
    {
        return _driver.FindElement(By.LinkText(_linktext)).GetAttribute("value");
    }

    public string ByClassName(string _classname)
    {
        return _driver.FindElement(By.ClassName(_classname)).GetAttribute("value");
    }
    
}