using System.Runtime.InteropServices.JavaScript;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Roys_Selenium_Portfolio;

public class DropdownFunctions
{
    private readonly ChromeDriver _driver;
    
    public DropdownFunctions(ChromeDriver driver)
    {
        _driver = driver;
    }
    
    public SelectFunctions FindById(string _id)
    {
        var dropDownElement = _driver.FindElement(By.Id(_id)); 
        var selectElement = new SelectElement(dropDownElement);
        return new SelectFunctions(selectElement);
    }
}