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

    public void SelectUserRole()
    {
        _helper.dropdown().ByXpath("/html/body/div[1]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[2]/div/div[2]/div/div/div[1]").SelectByText("Admin");
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