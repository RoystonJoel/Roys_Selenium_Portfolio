using OpenQA.Selenium;

namespace Roys_Selenium_Portfolio.Project_2___OrangeHRMLive;

public class OrangeUserManagement : PageBase
{
    private readonly SeleniumHelper _helper;
    
    public OrangeUserManagement(IWebDriver driver) : base(driver)
    {
        bool passed = true;
        _helper = new SeleniumHelper(driver);
        _helper.wait().UntilVisible().ByClassName("oxd-main-menu-item");
        try
        {
            _helper.click().ByXpath("/html/body/div/div[1]/div[1]/aside/nav/div[2]/ul/li[1]/a");
        }
        catch (Exception e)
        {
            passed = false;
        }
        if (!passed)
        {
            _helper.Visit("https://opensource-demo.orangehrmlive.com/web/index.php/admin/viewSystemUsers");
        }
        _helper.wait().UntilVisible().ByXpath("/html/body/div[1]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[1]/div/div[2]/input");
    }

    public void SearchUserName(string username)
    {
        _helper.JavaScriptExecutor("return document.querySelectorAll('input.oxd-input')[1].value = '"+username+"'");
    }

    public void SelectUserRole(string optionTextToSelect)
    {
        _helper.click().ByCssSelector("i.oxd-icon.bi-caret-down-fill.oxd-select-text--arrow",0);
        //_helper.click().ByXpath("/html/body/div[1]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[2]/div/div[2]/div/div[1]/div[2]/i");
        IWebElement listbox = _helper.GetElement(By.CssSelector("div.oxd-select-dropdown[role='listbox']"));
        IReadOnlyCollection<IWebElement> options = listbox.FindElements(By.CssSelector("div[role='option']"));
        bool optionFoundAndClicked = false;
        foreach (IWebElement option in options)
        {
            string optionText = option.Text.Trim();
            if (optionText.Equals(optionTextToSelect, StringComparison.OrdinalIgnoreCase))
            {
                option.Click();
                optionFoundAndClicked = true;
                break;
            }
        }
        if (!optionFoundAndClicked)
        {
            throw new NoSuchElementException($"Option with text '{optionTextToSelect}' not found in the dropdown.");
        }
    }

    public void SearchEmployeeName()
    {
        
    }

    public void SelectStatus()
    {
        
    }

    public void Reset()
    {
        
    }

    public void Search()
    {
        _helper.wait().UntilVisible().ByXpath("/html/body/div[1]/div[1]/div[2]/div[2]/div/div[2]/div[3]/div/div[2]/div[1]/div/div[2]/div");
        _helper.click().ByXpath("/html/body/div[1]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[2]/button[2]");
    }

    public void AddUser()
    {
        
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}