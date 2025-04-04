using System.Runtime.InteropServices.JavaScript;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Roys_Selenium_Portfolio;

public class Dropdown
{
    private readonly ElementInteraction _elementInteraction;
    
    public Dropdown(IWebDriver driver)
    {
        _elementInteraction = new ElementInteraction(driver);
    }
    
    public Select ById(string id)
    {
        return new Select(_elementInteraction.Select(By.Id(id)));
    }
}