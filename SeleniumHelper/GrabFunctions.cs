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
        var element = _driver.FindElement(By.Id(_id));
        return element.Text.ToString();
    }

    public string ByLinkText(string _linktext)
    {
        var element = _driver.FindElement(By.LinkText(_linktext));
        return element.Text.ToString();
    }

    public string ByClassName(string _classname)
    {
        var element = _driver.FindElement(By.ClassName(_classname));
        return element.Text.ToString();
    }
    
}