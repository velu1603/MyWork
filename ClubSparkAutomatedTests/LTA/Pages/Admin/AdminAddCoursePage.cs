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
    public class AdminAddCoursePage : Base
    {
        public AdminAddCoursePage(IWebDriver driver) { this.driver = driver; }


        // Mandatory fields in the course form 
        public readonly By _yourReference = By.XPath("//*[@id='Code']");
        public readonly By _name = By.XPath("//*[@id='Name']");
        public readonly By _description = By.XPath("//*[@id='Description']");
        public readonly By _confirmation = By.XPath("//*[@id='Confirmation']");
        public readonly By _nosOfSessions = By.XPath("//*[@id='NumberOfSessions']");
        public readonly By _courseCapacity = By.XPath("//*[@id='CourseCapacity']");
        public readonly By _courseCost = By.XPath("//*[@id='FullCourseCost']");
        public readonly By _defaultName = By.XPath("//*[@id='DefaultName']");
        public readonly By _saveCourse = By.CssSelector("button[class='btn btn-style-1 btn-lg']");


        public readonly By _courseCreatedMessage = By.XPath("//*[@id='feedback-message']/p");

        public string addNewCourse(string courseName, string courseCost)
        {

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_saveCourse));
           // driver.FindElement(_shortCourse).Click();

            var name = RandomGenerator.RandomString(3, false);
            driver.FindElement(_yourReference).SendKeys("Automation_" + name);
            driver.FindElement(_name).SendKeys(courseName); //---Will pass this in the method
            driver.FindElement(_description).SendKeys("This is while running the automation script " + name);
            driver.FindElement(_confirmation).SendKeys("This is while running the automation script " + name);
                        
            SelectStartDate();
            driver.FindElement(_nosOfSessions).SendKeys("1");
            driver.FindElement(_courseCapacity).SendKeys("1");
            driver.FindElement(_courseCost).Clear();
            driver.FindElement(_courseCost).SendKeys(courseCost);
            driver.FindElement(_defaultName).SendKeys("Automation_" + name);
            driver.FindElement(_saveCourse).Click();

            return driver.FindElement(_courseCreatedMessage).Text;
           //Console.WriteLine(courseCreated);
        }

        public void SelectStartDate()
        /*
         * This method will select the start date of the fixed membership
         * This will input (current day + 5)
         * Note: This date can be changed by changing the values withingthe Adddays() method below 
         * 
         */
        {
            var selectStartDate = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy");
            Console.WriteLine(selectStartDate);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.querySelector('#StartDate').value=\'" + selectStartDate + "\'");           

        }
        
    }
}
