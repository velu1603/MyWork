using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public.MemberEventsBooking
{
    public class MemberConfirmationPage : Base
    {
        public MemberConfirmationPage(IWebDriver driver) { this.driver = driver; }

        public readonly By _bookingConfirmation = By.XPath("//h2[contains(text(),'Thanks for booking')]");

        public string BookingConfirmationText()
        {
            return driver.FindElement(_bookingConfirmation).Text;
        }
    }
}
