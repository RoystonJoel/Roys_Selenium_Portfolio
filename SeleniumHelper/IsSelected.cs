namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class IsSelected
{
    private readonly ChromeDriver _driver;
    
    public IsSelected(ChromeDriver driver)
    {
        _driver = driver;
    }

    public bool IsSelectedByid(string id)
    {
        return _driver.FindElement(By.Id(id)).Selected;
    }
}