using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin
{
    public class AdminCoachingNormalAdultPage : Base
    {
        public AdminCoachingNormalAdultPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public readonly By _addANewCourse = By.CssSelector("#content > div.prog-bar > div > div:nth-child(2) > ul > li:nth-child(2) > a");
        public readonly By _shortCourse = By.CssSelector("#select-course-modal > div > div > div.modal-body > div > div:nth-child(1) > div > div.panel-body");


        public void ClickAddNewCourse()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_addANewCourse));
            driver.FindElement(_addANewCourse).Click();
        }

        public void SelectShortCourse()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_shortCourse));
            driver.FindElement(_shortCourse).Click();
        }



    }
}
