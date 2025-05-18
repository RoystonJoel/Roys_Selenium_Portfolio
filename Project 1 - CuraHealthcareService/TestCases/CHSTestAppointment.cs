using FluentAssertions;
using Xunit.Abstractions;

namespace Roys_Selenium_Portfolio.Project_1___CuraHealthcareService
{
    
    public class CHSTestAppointment : TestBase
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
                
                var login = new CHSLogin(_driver);
                login.auto_login();
                var appointment = new CHSAppointment(login.GetDriver());
                appointment.choose_facility(facility);
                appointment.hospital_readmission(hospital_readmission);
                appointment.healthcare_Program(healthcare_Program);
                appointment.visit_date(visit_date);
                appointment.comment("Test comment");
                string previousHtml = login.PageSource();
                appointment.book_appointment();
                var appointment_confirmation = new CHSAppointmentConfirmation(appointment.GetDriver());
                string currentHtml = login.PageSource();
                var url = appointment_confirmation.GetHelper().GetDriver().Url;
                
                
                url.Should().NotBeEmpty();
                url.Should().Contain("appointment.php#summary");
                url.Should().NotBeNull();
                currentHtml.Should().NotBe(previousHtml);
                
                appointment_confirmation.facility().Should().Contain(facility);
                appointment_confirmation.hospital_readmission().Should().Be(hospital_readmission);
                appointment_confirmation.program().ToLower().Should().Contain(healthcare_Program.Replace("radio_program_", ""));
                appointment_confirmation.visit_date().Should().Contain(visit_date);
                appointment_confirmation.Quit();
            }
            catch (Exception e)
            {
                output.WriteLine($"Error in Appointment_Success: {e.Message}");
                output.WriteLine(e.StackTrace);
                throw;
            }
        }

        [Fact]
        public void Appointment_NoDate()
        {
            try
            {
                string facility = "Hongkong CURA Healthcare Center";
                bool hospital_readmission = true;
                string healthcare_Program = "radio_program_medicaid";
                
                var login = new CHSLogin(_driver);
                login.auto_login();
                var appointment = new CHSAppointment(login.GetDriver());
                
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
                appointment.Quit();
                
            }
            catch (Exception e)
            {
                output.WriteLine($"Error in Appointment_NoDate: {e.Message}");
                output.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}