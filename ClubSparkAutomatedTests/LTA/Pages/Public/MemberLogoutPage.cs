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
    public class MemberLogoutPage : Base
    {
        public MemberLogoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public readonly By _dopdown = By.XPath("//*[@id='account-options']/a");

        public readonly By _signOut = By.CssSelector("#account-options > ul > li.sign-out > a");


        public void SignOut()
        {

            driver.FindElement(_dopdown).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_signOut));
            driver.FindElement(_signOut).Click();
        }
    }
}
