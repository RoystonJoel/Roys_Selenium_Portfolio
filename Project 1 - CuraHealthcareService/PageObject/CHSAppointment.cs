using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Roys_Selenium_Portfolio.Project_1___CuraHealthcareService;

public class CHSAppointment : PageBase
{
    private readonly SeleniumHelper _helper;

    public CHSAppointment(IWebDriver driver) : base(driver)
    {
        _helper = new SeleniumHelper(driver);
       _helper.wait().UntilVisible().ByID("combo_facility");
    }

    public void choose_facility()
    {
        _helper.dropdown().ById("combo_facility").SelectByText("Seoul CURA Healthcare Center");
    }
    public void choose_facility(string text)
    {
        _helper.dropdown().ById("combo_facility").SelectByText(text);
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

    public bool isFieldInvalid()
    {
        return _helper.JavaScriptExecutor<bool>("return arguments[0].checkValidity();", _helper.GetElement(By.Id("txt_visit_date")));
    }

    public string validationMessage()
    {
        return _helper.JavaScriptExecutor<string>("return arguments[0].validationMessage;", _helper.GetElement(By.Id("txt_visit_date")));
        
    }
}