using ClubSparkAutomatedTests._Help;
using ClubSparkAutomatedTests.LTA.Pages.Admin;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages
{
    public class AdminNewCoursePage : Base
    {
        //Construtor

        public AdminNewCoursePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        // Click on register 

        public readonly By _coachingLeftPanelIcon = By.XPath("//*[@id='dashboard-menu']/li[8]/a/span[1]");
        public readonly By _ViewCourses = By.LinkText("View courses");

        public readonly By _selectNormalAdult = By.XPath("//*[@id='membership-package-list']//following::div[14]");
       
        public void SelectCoaching()
        {
            driver.FindElement(_coachingLeftPanelIcon).Click();
        }
        public void ClickViewCourse()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_ViewCourses));
            driver.FindElement(_ViewCourses).Click();         

        }

        public void ClickProgrammes()
        {                       
            AdminCoachingProgrammes adminProgrammes = new AdminCoachingProgrammes(driver);
            adminProgrammes.SelectNormalAdult();

        }



    }
}
