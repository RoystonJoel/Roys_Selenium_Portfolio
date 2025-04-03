using OpenQA.Selenium.Chrome;

namespace Roys_Selenium_Portfolio;

public class Page
{
    private readonly SeleniumHelper _helper;

    public Page(ChromeDriver driver)
    {
        _helper = new SeleniumHelper(driver);
    }

    public SeleniumHelper GetHelper()
    {
        return _helper;
    }
    
    public void Dispose()
    {
        _helper.Dispose();
    }
}