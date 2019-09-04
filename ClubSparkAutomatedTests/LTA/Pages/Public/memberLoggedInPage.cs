using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public
{
    class MemberLoggedInPage : Base

    {

        public MemberLoggedInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //#content > div.venue-navigation.desktop.tablet > div > div > div > ul > li:nth-child(2) > a

        // Click on Membership after user has been created 
        public readonly By _selectMembership = By.XPath("//div[@class='container']/descendant::li[contains(.,'Membership')]");

        public readonly By _joinNow = By.XPath("//*[text()[contains(.,'Join Now!!')]]");


        public void clickOnMembership()
        {

            driver.FindElement(_selectMembership).Click();
        }

        public string joinNow()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_joinNow));

            return driver.FindElement(_joinNow).Text;
        }





    }
}
