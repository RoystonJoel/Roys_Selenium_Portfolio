﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Roys_Selenium_Portfolio;


public class CHSAppointmentConfirmation : PageBase
{
    private readonly SeleniumHelper _helper;

    public CHSAppointmentConfirmation(IWebDriver driver) : base(driver)
    {
        _helper = new SeleniumHelper(driver);
    }

    public string facility()
    {
        return _helper.Gettext().ById("facility");
    }
    
    public bool hospital_readmission()
    {
        if (_helper.Gettext().ById("hospital_readmission").ToLower() == "yes")
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
        return _helper.Gettext().ById("program");
    }
    
    public string visit_date()
    {
        return _helper.Gettext().ById("visit_date");
    }
    
    public string comment()
    {
        return _helper.Gettext().ById("comment");
    }
    
    public SeleniumHelper GetHelper()
    {
        return _helper;
    }
}