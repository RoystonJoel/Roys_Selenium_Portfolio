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
            this.output = output;
            driver = new ChromeDriver(_options);
            driver.Manage().Window.Maximize(); //fullscreen
        }

        [Fact]
        public void Appointment_Success ()
        {
            
        }


    }
}