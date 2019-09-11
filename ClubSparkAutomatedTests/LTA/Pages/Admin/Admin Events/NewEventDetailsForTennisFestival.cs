
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
    public class NewEventDetailsForTennisFestival : Base
    {
        public NewEventDetailsForTennisFestival(IWebDriver driver) { this.driver = driver; }

        public readonly By _theme = By.XPath("//div[@class='btn-group bootstrap-select']//span[@class='caret']");
        public readonly By _selectMonsterSmash = By.XPath("//span[contains(text(),'Monster Smash')]");
        public readonly By _date = By.XPath("//*[@id='MainDetails_Date']");
        public readonly By _startTime = By.XPath("//*[@id='MainDetails_StartTime']");
        public readonly By _endTime = By.XPath("//*[@id='MainDetails_EndTime']");
        public readonly By _competitionName = By.XPath("//*[@id='MainDetails_EventName']");
        public readonly By _takeOnlinePayment = By.XPath("(//div/input[@class='pretty-checkable']/following::a[1])[1]");

        public readonly By _introduction = By.XPath("//*[@id='MainDetails_Intro']");
        public readonly By _competitionDetails = By.XPath("//*[@id='MainDetails_EventDetails']");
        public readonly By _contactEmail = By.XPath("//*[@id='MainDetails_EventEmailAddress']");
        public readonly By _contactPhone = By.XPath("//*[@id='MainDetails_EventPhoneNumber']");

        public readonly By _SaveEvent = By.XPath("//button[@id='openDaySubmit']");

        public void SelectTheme()
        {
            IWebElement theme = driver.FindElement(_theme);
            theme.Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_selectMonsterSmash));
            driver.FindElement(_selectMonsterSmash).Click();
        }

        public void SelectDate()
        {
            var selectStartDate = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;            
            js.ExecuteScript("document.querySelector('#MainDetails_Date').value=\'" + selectStartDate + "\'");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
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

        public void CompetitionName(string competitionName)
        {
            driver.FindElement(_competitionName).SendKeys(competitionName);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void CheckTakeOnlinePayment()
        {
            driver.FindElement(_takeOnlinePayment).Click();
        }

        public void EnterInroduction(string introDetails)
        {
            driver.FindElement(_introduction).SendKeys(introDetails);
        }
        public void EnterCompetitionDetails(string CompetitionDetails)
        {
            driver.FindElement(_competitionDetails).SendKeys(CompetitionDetails);
        }
        public void ContactEmail(string contactEmail)
        {
            driver.FindElement(_contactEmail).SendKeys(contactEmail);
        }
        public void ContactPhoneNumber(string phoneNumber)
        {
            driver.FindElement(_contactPhone).SendKeys(phoneNumber);
        }

        public void SaveEvent()
        {
            driver.FindElement(_SaveEvent).Click();
        }

    }
}
