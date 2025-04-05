using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Roys_Selenium_Portfolio;

public class Page
{
    private readonly SeleniumHelper _helper;

    public Page(IWebDriver driver)
    {
        _helper = new SeleniumHelper(driver);
    }

    public SeleniumHelper GetHelper()
    {
        return _helper;
    }
}