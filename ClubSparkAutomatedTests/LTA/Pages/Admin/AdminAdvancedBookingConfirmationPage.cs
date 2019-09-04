using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin
{
    public class AdminAdvancedBookingConfirmationPage : Base
    {

        public readonly By _bookingConfirmedMessage = By.CssSelector("#booking-confirmation-view > section > div.confirmation-header._30px-spacing-bottom > div > h1");
        public AdminAdvancedBookingConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string ConfirmationText()
        {

            return driver.FindElement(_bookingConfirmedMessage).Text;

        }

    }
}
