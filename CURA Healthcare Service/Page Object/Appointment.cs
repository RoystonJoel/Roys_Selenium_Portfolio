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

    public void hospital_readmission(bool selected)
    {
        if (selected)
        {
            if (!_helper.isselected().IsSelectedByid("chk_hospotal_readmission"))
            {
                _helper.click().ById("chk_hospotal_readmission");
            }
        }
        else
        {
            if (_helper.isselected().IsSelectedByid("chk_hospotal_readmission"))
            {
                _helper.click().ById("chk_hospotal_readmission");
            }
        }
        
    }
    
    public void healthcare_Program()
    {
        _helper.click().ById("radio_program_medicaid");
    }
    public void healthcare_Program(string radiobuttonId)
    {
        _helper.click().ById(radiobuttonId);
    }
    
    public void visit_date()
    {
        _helper.sendkeys().ById("12/04/2025", "txt_visit_date");
    }
    public void visit_date(string date)
    {
        _helper.sendkeys().ById(date, "txt_visit_date");
    }

    public void comment()
    {
        _helper.sendkeys().ById("hello world","txt_comment");
    }
    public void comment(string text)
    {
        _helper.sendkeys().ById(text,"txt_comment");
    }

    public void book_appointment()
    {
        _helper.click().ById("btn-book-appointment");
    }
    
    public SeleniumHelper GetHelper()
    {
        return _helper;
    }
}