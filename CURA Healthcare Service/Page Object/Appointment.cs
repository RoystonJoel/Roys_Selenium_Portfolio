using OpenQA.Selenium.Chrome;

namespace Roys_Selenium_Portfolio;

public class Appointment
{
    private readonly SeleniumHelper _helper;

    public Appointment(ChromeDriver driver)
    {
        _helper = new SeleniumHelper(driver);
    }

    public void choose_facility()
    {
        _helper.dropdown().FindById("combo_facility").SelectByText("Seoul CURA Healthcare Center");
    }
    public void choose_facility(string text)
    {
        _helper.dropdown().FindById("combo_facility").SelectByText(text);
    }

    public void hospital_readmission()
    {
        
    }
    
    public void healthcare_Program()
    {
        
    }
    
    public void visit_date()
    {
        
    }

    public void comment()
    {
        
    }

    public void book_appointment()
    {
        
    }
}