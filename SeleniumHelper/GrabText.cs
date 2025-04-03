namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class GrabText
{
    private readonly ChromeDriver _driver;
    public GrabText(ChromeDriver driver)
    {
        _driver = driver;
    }
    
    public string ByXpath(string _Xpath)
    {
        return _driver.FindElement(By.XPath(_Xpath)).Text;
    }
    
    public string ById(string _id)
    {
        return _driver.FindElement(By.Id(_id)).Text;
    }

    public string ByLinkText(string _linktext)
    {
        return _driver.FindElement(By.LinkText(_linktext)).Text;
    }

    public string ByClassName(string _classname)
    {
        return _driver.FindElement(By.ClassName(_classname)).Text;
    }
    
}