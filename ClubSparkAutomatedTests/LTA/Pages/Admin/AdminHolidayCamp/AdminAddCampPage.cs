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
    public class AdminAddCampPage : Base
    {
        public AdminAddCampPage(IWebDriver driver) { this.driver = driver; }

        // Mandatory fields in the course form 
        public readonly By _code = By.XPath("//*[@id='Code']");
        public readonly By _name = By.XPath("//*[@id='Name']");
        public readonly By _description = By.XPath("//*[@id='Description']");
        
        public readonly By _courseCapacity = By.XPath("//*[@id='DefaultCapacity']");
        public readonly By _contactEmail = By.XPath("//*[@id='ContactEmailAddress']");
        public readonly By _contactPhone = By.XPath("//*[@id='ContactPhoneNumber']");

        public readonly By _morningSessionsStartTime = By.XPath("//*[@id='DefaultIntervals_0__StartTime']");
        public readonly By _morningSessionsEndTime = By.XPath("//*[@id='DefaultIntervals_0__EndTime']");

        public readonly By _afternoonSessionsStartTime = By.XPath("//*[@id='DefaultIntervals_1__StartTime']");
        public readonly By _afternoonSessionsEndTime = By.XPath("//*[@id='DefaultIntervals_1__EndTime']");

        public readonly By _morningCost = By.XPath("//*[@id='DefaultIntervals_0__Cost']");
        public readonly By _afternoonCost = By.XPath("//*[@id='DefaultIntervals_1__Cost']");
        public readonly By _fullDayCost = By.XPath("//*[@id='DefaultFullDayCost']");

        public readonly By _saveCamp = By.CssSelector("button[class='btn btn-style-1 btn-lg']");
        public readonly By _courseCreatedMessage = By.XPath("//*[@id='feedback-message']/p");

        public string addNewHolidayCamp(string courseName,string cost,string fulldayCost)        {

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_saveCamp));
            

            var name = RandomGenerator.RandomString(3, false);
            driver.FindElement(_code).SendKeys("Automation_" + name);
            driver.FindElement(_name).SendKeys(courseName); //---Will pass this in the method
            driver.FindElement(_description).SendKeys("New Holiday camp using automation script " + name);
           
            SelectStartDate();
            
            driver.FindElement(_courseCapacity).SendKeys("1");
            driver.FindElement(_contactEmail).SendKeys("contact@email.com");
            driver.FindElement(_contactPhone).SendKeys("0789678987");

            // select the time for the session 
            MorningStartTime();
            MorningEndTime();

            AfterNoonStartTime();
            AfterNoonEndTime();

            // enter the costs 
            driver.FindElement(_morningCost).SendKeys(cost);
            driver.FindElement(_afternoonCost).SendKeys(cost);
            driver.FindElement(_fullDayCost).SendKeys(fulldayCost);
                                             
            // Click to save camp
            driver.FindElement(_saveCamp).Click();

            return driver.FindElement(_courseCreatedMessage).Text;
            
        }

        public void SelectStartDate()        
        {
            var selectStartDate = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy");
            Console.WriteLine(selectStartDate);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.querySelector('#StartDate').value=\'" + selectStartDate + "\'");
        }

        public void MorningStartTime()
        {
            var morningStartTime = driver.FindElement(_morningSessionsStartTime);
            var morningSelectStartTime = new SelectElement(morningStartTime);
            morningSelectStartTime.SelectByText("09:00");
        }
        public void MorningEndTime()
        {
            var morningnEndTime = driver.FindElement(_morningSessionsEndTime);
            var morningSelectEndTime = new SelectElement(morningnEndTime);
            morningSelectEndTime.SelectByText("12:30");
        }

        public void AfterNoonStartTime()
        {
            var afternoonStartTime = driver.FindElement(_afternoonSessionsStartTime);
            var afternoonSelectStartTime = new SelectElement(afternoonStartTime);
            afternoonSelectStartTime.SelectByText("14:00");
        }
        public void AfterNoonEndTime()
        {
            var afternoonEndTime = driver.FindElement(_afternoonSessionsEndTime);
            var afternoonSelectEndTime = new SelectElement(afternoonEndTime);
            afternoonSelectEndTime.SelectByText("17:30");
        }



    }
}
