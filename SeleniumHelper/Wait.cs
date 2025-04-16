using OpenQA.Selenium;

namespace Roys_Selenium_Portfolio;

public class Wait
{
    private readonly WaitHelper waithelper;
    public Wait(IWebDriver driver)
    {
        waithelper = new  WaitHelper(driver);
    }

    public void waitUntilVisableByID(string id)
    {
        waithelper.WaitUntilVisible(By.Id(id));
    }

    public void waitUntilVisableByName(string name)
    {
        waithelper.WaitUntilVisible(By.Name(name));
    }
}