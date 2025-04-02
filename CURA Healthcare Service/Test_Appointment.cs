using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Roys_Selenium_Portfolio
{
    
    public class Test_Appointment
    {
        private readonly ITestOutputHelper output;
        private readonly ChromeOptions _options;
        private readonly ChromeDriver driver;
        private readonly WebDriverWait wait;
        private readonly string[] scopes;
        
        public Test_Appointment(ITestOutputHelper output)
        {
            _options = new ChromeOptions();
            //_options.AddArgument("--headless");
            _options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            this.output = output;
            driver = new ChromeDriver(_options);
            driver.Manage().Window.Maximize(); //fullscreen
        }

        [Fact]
        public void Appointment_Success ()
        {
            var login = new Login(driver);
            login.auto_login();
            var appointment = new Appointment(login.GetHelper().GetDriver());
            appointment.GetHelper().wait().wait_until_visable_byID("combo_facility");
            appointment.choose_facility("Hongkong CURA Healthcare Center");
            appointment.hospital_readmission();
            appointment.healthcare_Program();
            appointment.visit_date();
            appointment.comment("Test comment");
            appointment.book_appointment();
        }
        


    }
}