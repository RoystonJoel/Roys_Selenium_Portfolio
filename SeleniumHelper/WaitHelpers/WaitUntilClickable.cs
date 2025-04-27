using OpenQA.Selenium;

namespace Roys_Selenium_Portfolio;

public class WaitUntilClickable
{
    private readonly WaitHelper waithelper;
    public WaitUntilClickable(IWebDriver driver)
    {
        waithelper = new  WaitHelper(driver);
    }

    public void WaitUntilClickableByID(string id)
    {
        waithelper.WaitUntilClickable(By.Id(id));
    }

    public void WaitUntilClickableByName(string name)
    {
        waithelper.WaitUntilClickable(By.Name(name));
    }
}