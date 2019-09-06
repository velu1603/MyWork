using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public.MemberEventsBooking
{
    public class MemberEventsBookingPage : Base
    {
        public MemberEventsBookingPage(IWebDriver driver) { this.driver = driver; }

        // Click on events
        public readonly By _events = By.XPath("(//a[contains(text(),'Events')])[1]");

        public readonly By _tennisFestival = By.XPath("(//a[contains(text(),'Tennis Festival')])[1]");

        public void ClickEvents()
        {
            driver.FindElement(_events);
        }

        public void SelectTennisFestival()
        {
            driver.FindElement(_tennisFestival).Click();
        }


    }
}
