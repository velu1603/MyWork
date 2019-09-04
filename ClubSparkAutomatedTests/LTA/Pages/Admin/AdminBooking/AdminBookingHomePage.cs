using OpenQA.Selenium;
using ClubSparkAutomatedTests._Help;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin.AdminBooking
{
    public class AdminBookingHomePage : Base
    {
        ///
        //Locators
        //

        private readonly string _bookingSettingsHref = "/Admin/Booking/Settings";
        private readonly By _bookingLeftPanelIcon = By.XPath("//*[@id='dashboard-menu']/li[5]/a/span[1]");




        ///
        //Constructor
        //
        public AdminBookingHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        ///
        //Methods
        //

        public void BookingSchedule()
        {
            var bSettingsPage = new AdminBookingsSettingsPage(driver);
            var bSchedulesPage = new AdminBookingSchedulesPage(driver);
            driver.FindElement(_bookingLeftPanelIcon).Click();
            GeneralMethods.ClickLinkByHref(driver,_bookingSettingsHref);
            bSettingsPage.ManageSchedule();
            bSchedulesPage.AddSchedule();
        }




    }
}
