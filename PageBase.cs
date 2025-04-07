using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Roys_Selenium_Portfolio;

public class PageBase
{
    private readonly SeleniumHelper _helper;

    public PageBase(IWebDriver driver)
    {
        _helper = new SeleniumHelper(driver);
    }

    public IWebDriver GetDriver()
    {
        return _helper.GetDriver();
    }
}