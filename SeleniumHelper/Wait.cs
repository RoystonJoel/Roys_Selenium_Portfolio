using OpenQA.Selenium;

namespace Roys_Selenium_Portfolio;

public class Wait
{
    private readonly WaitHelper _waitheper;
    public Wait(IWebDriver driver)
    {
        _waitheper = new  WaitHelper(driver);
    }

    public void wait_until_visable_byID(string _id)
    {
        _waitheper.WaitUntilVisible(By.Id(_id));
    }
}