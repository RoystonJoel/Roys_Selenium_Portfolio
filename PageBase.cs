using OpenQA.Selenium;

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
    
    public string PageSource()
    {
        return _helper.PageSource();
    }

    public string Url()
    {
        return _helper.Url();
    }

    public void Quit()
    {
        _helper.Quit();
    }
}