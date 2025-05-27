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
            _helper.click().ByCssSelector("a.oxd-main-menu-item",0);
        }
        catch (Exception e)
        {
            passed = false;
        }
        if (!passed)
        {
            _helper.Visit("https://opensource-demo.orangehrmlive.com/web/index.php/admin/viewSystemUsers");
        }
        _helper.wait().UntilVisible().ByCssSelector("input.oxd-input.oxd-input--active",1);
        //_helper.wait().UntilVisible().ByXpath("/html/body/div[1]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[1]/div/div[2]/input");
    }

    public void SearchUserName(string username)
    {
        _helper.sendkeys().ByCssSelector(username,"input.oxd-input.oxd-input--active",1);
    }

    public void SelectUserRole(string optionTextToSelect)
    {
        _helper.click().ByCssSelector("i.oxd-icon.bi-caret-down-fill.oxd-select-text--arrow",0);
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
        _helper.click().ByCssSelector("button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space",0);
    }

    public void AddUser()
    {
        
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}