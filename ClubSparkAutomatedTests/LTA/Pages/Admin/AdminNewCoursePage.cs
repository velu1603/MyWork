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

        public readonly By _coachingLeftPanelIcon = By.XPath("//*[@id='dashboard-menu']/li[8]/a/span[1]");
        public readonly By _viewCourses = By.LinkText("View courses");
        public readonly By _selectNormalAdult = By.XPath("//*[@id='membership-package-list']//following::div[14]");


        public readonly By _holidayCamps = By.LinkText("Holiday camps");


        public void SelectCoaching()
        {
            driver.FindElement(_coachingLeftPanelIcon).Click();
        }
        public void ClickViewCourse()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_viewCourses));
            driver.FindElement(_viewCourses).Click();         

        }
        // Select programmes within view course
        public void ClickProgrammes()
        {                       
            AdminCoachingProgrammes adminProgrammes = new AdminCoachingProgrammes(driver);
            adminProgrammes.SelectNormalAdult();

        }

        // Click holiday camps within Coaching tab 
        public void ClickHolidayCamps()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_holidayCamps));
            driver.FindElement(_holidayCamps).Click();

        }



    }
}
