using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin.AdminHolidayCamp
{
    public class AdminHolidayCampPage : Base
    {

        public AdminHolidayCampPage(IWebDriver driver) { this.driver = driver; }


        public readonly By _addANewCamp = By.CssSelector("#content > div.prog-bar > div > div:nth-child(2) > ul > li > a");
       


        public void ClickAddNewCamp()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_addANewCamp));
            driver.FindElement(_addANewCamp).Click();
        }






    }
}
