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
    public class FixedMemberShipConfirmationPage : Base

    {
        public FixedMemberShipConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            
        }

        public readonly By _newMeberShipPackage = By.CssSelector("#content > form > div:nth-child(1) > div > div > div.panel-body > div:nth-child(1) > div.control > p");


        public string TextOfNewlyCreatedPakage()
        {
            //var newMeberShipPackageText = driver.FindElement(_newMeberShipPackage).Text;

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_newMeberShipPackage));

            return driver.FindElement(_newMeberShipPackage).Text;
        }
    }
}
