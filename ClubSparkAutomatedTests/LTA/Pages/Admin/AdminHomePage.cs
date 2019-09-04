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
    public class AdminHomePage : Base
    {
        //The admin landing page once he/she login as admin 
        IWebElement _bookingLeftPanelIcon => driver.FindElement(By.CssSelector("#dashboard-menu > li:nth-child(5) > a > span.text"));
        
        public AdminHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnBooking()
        {
           
            _bookingLeftPanelIcon.Click();

        }
        


    }
}
