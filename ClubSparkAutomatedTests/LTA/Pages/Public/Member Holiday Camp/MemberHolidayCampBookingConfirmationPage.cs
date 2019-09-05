using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public.Member_Holiday_Camp
{
    public class MemberHolidayCampBookingConfirmationPage : Base
    {
        public MemberHolidayCampBookingConfirmationPage(IWebDriver driver) { this.driver = driver; }

        public readonly By _bookingConfirmationText = By.XPath("//p[contains(text(),'Confirmed! Your Holiday camp is booked.')]");

        public string BookingConfirmationText()
        {
            return driver.FindElement(_bookingConfirmationText).Text;
        }
    }
}
