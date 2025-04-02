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
            string facility = "Hongkong CURA Healthcare Center";
            bool hospital_readmission = true;
            string healthcare_Program = "radio_program_medicaid";
            string visit_date = "23/04/2025";
            
            var login = new Login(driver);
            login.auto_login();
            var appointment = new Appointment(login.GetHelper().GetDriver());
            appointment.GetHelper().wait().wait_until_visable_byID("combo_facility");
            appointment.choose_facility(facility);
            appointment.hospital_readmission(hospital_readmission);
            appointment.healthcare_Program(healthcare_Program);
            appointment.visit_date(visit_date);
            appointment.comment("Test comment");
            string previousHtml = login.GetHelper().GetDriver().PageSource;
            appointment.book_appointment();
            var appointment_confirmation = new AppointmentConfirmation(appointment.GetHelper().GetDriver());
            appointment.GetHelper().wait().wait_until_visable_byID("summary");
            string currentHtml = login.GetHelper().GetDriver().PageSource;
            
            try
            {
                var url = appointment_confirmation.GetHelper().GetDriver().Url;
                url.Should().NotBeEmpty();
                url.Should().Contain("appointment.php#summary");
                url.Should().NotBeNull();
                currentHtml.Should().NotBe(previousHtml);
                
                appointment_confirmation.facility().Should().Contain(facility);
                appointment_confirmation.hospital_readmission().Should().Be(hospital_readmission);
                appointment_confirmation.program().ToLower().Should().Contain(healthcare_Program.Replace("radio_program_", ""));
                appointment_confirmation.visit_date().Should().Contain(visit_date);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                appointment_confirmation.Dispose();
                throw;
            }
            appointment_confirmation.Dispose();
        }
        
        
        


    }
}