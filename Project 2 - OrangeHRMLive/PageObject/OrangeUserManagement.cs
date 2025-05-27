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
    }

    public void SearchUserName(string username)
    {
        _helper.sendkeys().ByCssSelector(username,"input.oxd-input.oxd-input--active",1);
    }

    public void SelectUserRole(string userrole)
    {
        _helper.click().ByCssSelector("i.oxd-icon.bi-caret-down-fill.oxd-select-text--arrow",0);
        IWebElement listbox = _helper.GetElement(By.CssSelector("div.oxd-select-dropdown[role='listbox']"));
        IReadOnlyCollection<IWebElement> options = listbox.FindElements(By.CssSelector("div[role='option']"));
        SelectFromDropdown(options, userrole);
    }

    public void SearchEmployeeName(string firstname, string middlename, string lastname)
    {
        string firstlast = firstname+" "+lastname;
        string fullname = firstname+" "+middlename+" "+lastname;
        _helper.sendkeys().ByCssSelector(firstlast,"div.oxd-autocomplete-text-input input[placeholder='Type for hints...']",0);
        _helper.wait().UntilTextToBePresentInElement().ByCssSelector("div.oxd-autocomplete-dropdown[role='listbox']",fullname,0);
        IWebElement listbox = _helper.GetElement(By.CssSelector("div.oxd-autocomplete-dropdown[role='listbox']"));
        IReadOnlyCollection<IWebElement> options = listbox.FindElements(By.CssSelector("div[role='option']"));
        SelectFromDropdown(options, fullname);
    }
    
    public void SelectStatus(string status)
    {
        _helper.click().ByCssSelector("i.oxd-icon.bi-caret-down-fill.oxd-select-text--arrow",1);
        IWebElement listbox = _helper.GetElement(By.CssSelector("div.oxd-select-dropdown[role='listbox']"));
        IReadOnlyCollection<IWebElement> options = listbox.FindElements(By.CssSelector("div[role='option']"));
        SelectFromDropdown(options, status);
    }

    private void SelectFromDropdown(IReadOnlyCollection<IWebElement> options, string optionTextToSelect)
    {
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