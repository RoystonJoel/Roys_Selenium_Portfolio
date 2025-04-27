using OpenQA.Selenium;

namespace Roys_Selenium_Portfolio;

public class WaitUntilTextToBePresentInElement
{
    private readonly WaitHelper waithelper;
    public WaitUntilTextToBePresentInElement(IWebDriver driver)
    {
        waithelper = new  WaitHelper(driver);
    }

    public void WaitUntilTextToBePresentInElementByID(string id, string text)
    {
        waithelper.WaitUntilTextToBePresentInElement(By.Id(id),text);
    }

    public void WaitUntilTextToBePresentInElementByName(string name, string text)
    {
        waithelper.WaitUntilTextToBePresentInElement(By.Name(name),text);
    }
}