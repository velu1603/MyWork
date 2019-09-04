using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public
{
    public class MemberLoginPage : Base
    {

        ///
        //Locators
        //

        private readonly By _loginEmail = By.Id("EmailAddress");
        private readonly By _loginPassword = By.Id("Password");
        private readonly By _signInButton = By.Id("signin-btn");



        ///
        //Constructor
        //

        public MemberLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        ///
        //Methods
        //

        public void Login()
        {
            driver.FindElement(_loginEmail).SendKeys("saw@lin.one");
            driver.FindElement(_loginPassword).SendKeys("sp0rtlabs");
            driver.FindElement(_signInButton).Click();

        }
    }
}
