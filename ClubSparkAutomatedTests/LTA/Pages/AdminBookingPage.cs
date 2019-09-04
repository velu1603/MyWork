using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages
{
    public class AdminBookingPage : Base
        // This page for booking by admin when booking is clicked on the home page
    {

        IWebElement _bookingSheet => driver.FindElement(By.LinkText("Booking sheet"));
        public AdminBookingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnBookingSheet()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_bookingSheet));
            _bookingSheet.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.SwitchTo().Window(driver.WindowHandles.Last());  // This switch to Advance booking page
           
        }








    }
}
