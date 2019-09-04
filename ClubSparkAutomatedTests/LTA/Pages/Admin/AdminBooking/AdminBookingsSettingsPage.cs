using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin.AdminBooking
{
    public class AdminBookingsSettingsPage : Base
    {

        ///
        //Locators
        //

        public const string ManageSchedules = "/Admin/Booking/Schedules";

        //*[@id="content"]/div[4]/div[2]/div/div[2]/a


        ///
        //Constructor
        //
        public AdminBookingsSettingsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        ///
        //Methods
        //

        public void ManageSchedule()
        {
            GeneralMethods.ClickLinkByHref(driver,ManageSchedules);


        }
    }
}
