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
    public class AdminLogOutPage : Base
    {
        public AdminLogOutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public readonly By _adminUser = By.XPath("//*[@id='user-details']/div/div/button");
        public readonly By _signOut = By.CssSelector("#user-details > div > div > ul > li:nth-child(5) > a");

        public void LogoutOfAdmin()
        {
            driver.FindElement(_adminUser).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_signOut));
            driver.FindElement(_signOut).Click();
        }




    }
}
