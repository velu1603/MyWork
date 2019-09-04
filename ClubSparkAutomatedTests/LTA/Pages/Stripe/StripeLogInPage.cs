using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Stripe
{
    public class StripeLogInPage : Base
    {
        public StripeLogInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public readonly By _email = By.XPath("//*[@id='email']");
        public readonly By _password = By.XPath("//*[@id='password']");
        public readonly By _signIn = By.XPath("//button[@class='button blue']/span");

        public void LogInToStripe(string email,string password)
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["StripePayment"]);
            driver.FindElement(_email).SendKeys(email);
            driver.FindElement(_password).SendKeys(password);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_signIn));
            driver.FindElement(_signIn).Click();

            
        }   
    }



}
