using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin
{
    public class AdminCoachingAttendeesListPage : Base
    {
       public AdminCoachingAttendeesListPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public readonly By _selectAttendee = By.CssSelector("#course-attendees-table > tbody > tr > td.attendee-cell");

        public readonly By _selectRow = By.CssSelector("#course-attendees-table > tbody > tr");

        public void SelectAttendee()
        {
            driver.FindElement(_selectAttendee).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_selectRow));
            driver.FindElement(_selectRow).Click();


        }


    }
}
