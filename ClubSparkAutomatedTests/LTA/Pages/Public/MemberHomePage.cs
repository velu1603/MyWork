using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public
{
    public class MemberHomePage : Base
    {
        ///
        //Locators
        //

        //private readonly By _loginEmail = By.Id("EmailAddress");
        //private readonly By _loginPassword = By.Id("Password");
        //private readonly By _signInButton = By.Id("signin-btn");
        public const string MembershipTab = "/Membership";
        public const string BookingTab = "/Booking";
        public const string CoachingTab = "/Coaching";

        ///
        //Constructor
        //

        public MemberHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        ///
        //Methods
        //

        public void SelectMembershipTab()
        {
            GeneralMethods.ClickLinkByHref(driver, MembershipTab);
        }

        public void SelectBookingTab()
        {
            GeneralMethods.ClickLinkByHref(driver, BookingTab);
        }

        public void SelectCoachingTab()
        {
            GeneralMethods.ClickLinkByHref(driver,CoachingTab);
        }

       

    }
}
