namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium.Support.UI;

public class SelectFunctions
{
    private readonly SelectElement _selectElement;
    
    public SelectFunctions(SelectElement selectElement)
    {
        _selectElement = selectElement;
    }

    public void SelectByText(String text)
    {
        _selectElement.SelectByText(text);
    }
}