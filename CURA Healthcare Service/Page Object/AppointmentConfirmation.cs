namespace Roys_Selenium_Portfolio;
using OpenQA.Selenium.Chrome;

public class AppointmentConfirmation
{
    private readonly SeleniumHelper _helper;

    public AppointmentConfirmation(ChromeDriver driver)
    {
        _helper = new SeleniumHelper(driver);
    }

    public string facility()
    {
        return _helper.grabtext().ById("facility");
    }
    
    public bool hospital_readmission()
    {
        if (_helper.grabtext().ById("hospital_readmission").ToLower() == "yes")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public string program()
    {
        return _helper.grabtext().ById("program");
    }
    
    public string visit_date()
    {
        return _helper.grabtext().ById("visit_date");
    }
    
    public string comment()
    {
        return _helper.grabtext().ById("comment");
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