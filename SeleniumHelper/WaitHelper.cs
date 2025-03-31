namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class WaitHelper
{
    private readonly ChromeDriver _driver;
    private readonly WebDriverWait _wait;
    
    public WaitHelper(ChromeDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public SeleniumHelper wait_until_visable_byID(string _id)
    {
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(_id)));
        return new SeleniumHelper(_driver,_wait);
    }
}