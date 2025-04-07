using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Roys_Selenium_Portfolio
{
    
    public class CHSTestAppointment : CHSTestBase
    {
        
        public CHSTestAppointment(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Appointment_Success ()
        {
            try
            {
                string facility = "Hongkong CURA Healthcare Center";
                bool hospital_readmission = true;
                string healthcare_Program = "radio_program_medicaid";
                string visit_date = "23/04/2025";
                
                var login = new Login(_driver);
                login.auto_login();
                var appointment = new Appointment(login.GetDriver());
                appointment.choose_facility(facility);
                appointment.hospital_readmission(hospital_readmission);
                appointment.healthcare_Program(healthcare_Program);
                appointment.visit_date(visit_date);
                appointment.comment("Test comment");
                string previousHtml = login.GetDriver().PageSource;
                appointment.book_appointment();
                var appointment_confirmation = new AppointmentConfirmation(appointment.GetDriver());
                string currentHtml = login.GetDriver().PageSource;
            
            
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
                Dispose();
                throw;
            }
            Dispose();
        }

        [Fact]
        public void Appointment_NoDate()
        {
            try
            {
                string facility = "Hongkong CURA Healthcare Center";
                bool hospital_readmission = true;
                string healthcare_Program = "radio_program_medicaid";
                
                var login = new Login(_driver);
                login.auto_login();
                var appointment = new Appointment(login.GetDriver());
                
                appointment.choose_facility(facility);
                appointment.hospital_readmission(hospital_readmission);
                appointment.healthcare_Program(healthcare_Program);
                appointment.comment("Test comment");
                appointment.book_appointment();
                
                output.WriteLine(appointment.isFieldInvalid().ToString());
                output.WriteLine(appointment.validationMessage());
                Assert.False(appointment.isFieldInvalid(), "The required field should be marked as invalid.");
                // Note: The exact validation message text can vary slightly between browsers
                Assert.NotEmpty(appointment.validationMessage());
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Dispose();
                throw;
            }
            Dispose();
        }
    }
}