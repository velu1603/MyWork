using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public.MemberCoachingTab
{
    public class MemberCoachingBookingConfirmationPage : Base
    {
        public MemberCoachingBookingConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public readonly By _bookingConfirmationText = By.XPath("//*[@id='content']/div[3]/section/div[2]/div/div/div[1]/h2");

        public string BookingConfirmationText()
        {
            return driver.FindElement(_bookingConfirmationText).Text;
        }
    }
}
