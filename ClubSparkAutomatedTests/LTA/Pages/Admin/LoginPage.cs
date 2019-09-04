using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin
{
    public class LoginPage : Base
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

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        ///
        //Methods
        //

        public void Login()

        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["LTA_AdminURL"]);
            driver.FindElement(_loginEmail).SendKeys("deepa.yadav@clubspark.com");
            driver.FindElement(_loginPassword).SendKeys("Google123$");
            driver.FindElement(_signInButton).Click();

        }
    }
}
