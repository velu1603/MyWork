using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin.Admin_Events
{
    public class AdminEventsActivitiesPage : Base
    {
        public AdminEventsActivitiesPage(IWebDriver driver) { this.driver = driver; }

        public readonly By _ballType = By.XPath("//div[@class='btn-group bootstrap-select']//span[@class='caret']");
        public readonly By _selectBallType = By.XPath("//*[@id='CreateOpenDaysActivity_BallColour']");
        public readonly By _selectNone = By.XPath("//span[contains(text(),'None')]");
        public readonly By _eventName = By.XPath("//input[@id='CreateOpenDaysActivity_EventName']");
        public readonly By _gender = By.XPath("(//*[@id='CreateOpenDaysActivity_Gender'])[3]/following::a[1]");
        public readonly By _entryFee = By.XPath("//*[@id='CreateOpenDaysActivity_EntryFee']");
        public readonly By _startTime = By.XPath("//*[@id='CreateOpenDaysActivity_StartTime']");

        public readonly By _endTime = By.XPath("//*[@id='CreateOpenDaysActivity_EndTime']");
        public readonly By _description = By.XPath("//*[@id='CreateOpenDaysActivity_Description']");
        public readonly By _saveActivity = By.XPath("//button[contains(@class,'ns-btn btn-style-1 js-save-activity')]");

        
        public void SelectBallType()
        {
           IWebElement ballType = driver.FindElement(_ballType);
           ballType.Click();

           wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_selectNone));
           driver.FindElement(_selectNone).Click();           
        }

        public void EventName(string eventName)
        {
            
            driver.FindElement(_eventName).SendKeys(eventName);
            //return eventName;
        }

        public void SelectGender()
        {
            driver.FindElement(_gender).Click();            
        }

        public void EntryFeePerPlayer(string fee)
        {
            driver.FindElement(_entryFee).SendKeys(fee);
        }

        public void StartTime()
        {
            IWebElement startTime = driver.FindElement(_startTime);
            startTime.Click();
            startTime.SendKeys("09:00");
            startTime.SendKeys(Keys.Enter);            
        }

        public void EndTime()
        {
            IWebElement endTime = driver.FindElement(_endTime);
            endTime.Click();
            endTime.SendKeys("18:00");
            endTime.SendKeys(Keys.Enter);
        }

        public void Description(string enterDescription)
        {
            driver.FindElement(_description).SendKeys(enterDescription);
        }

        public void SaveActivity()
        {
            driver.FindElement(_saveActivity).Click();
        }
        
        public string getEventName(string eventName)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string xpath = "//h3[contains(text(),'" + eventName +"')]";
            var element = driver.FindElement(By.XPath(xpath));            
            return element.Text;
            
        }
        



    }  
}
