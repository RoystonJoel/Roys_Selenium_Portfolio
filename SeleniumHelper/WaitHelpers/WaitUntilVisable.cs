using OpenQA.Selenium;

namespace Roys_Selenium_Portfolio;

public class WaitUntilVisable
{
    private readonly WaitHelper waithelper;
    public WaitUntilVisable(IWebDriver driver)
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