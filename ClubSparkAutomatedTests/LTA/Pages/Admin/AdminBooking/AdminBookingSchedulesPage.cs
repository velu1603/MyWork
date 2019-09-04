using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubSparkAutomatedTests._Help;
using NUnit.Framework.Api;
using OpenQA.Selenium;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin.AdminBooking
{
    public class AdminBookingSchedulesPage :Base
    {
        ///
        //Locators
        //
        private readonly By _addScheduleButton = By.Id("schedules-add-row");
        private readonly  By _saveScheduleButton = By.XPath(("//*[@id='schedules-form']/div/div/div[2]/button"));
        private readonly By _closedYellowLabelBox = By.CssSelector(".row:nth-child(1) > .col-sm-6 .key");
        private readonly By _memberDiscountPurpleLabelBox = By.CssSelector(".row:nth-child(3) .key");
        private readonly By _defaultGreenLabelBox = By.CssSelector(".row:nth-child(2) .key");
        private readonly By _editScheduleSaveButton = By.CssSelector(".pull-right > .btn");

        ///
        //Constructor
        //
        public AdminBookingSchedulesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        ///
        //Methods
        //
        public void AddSchedule()
        {
            DeleteExistingSchedules();
            driver.FindElement(_addScheduleButton).Click();
            var noOfExistingSchedules = CountNoOfExistingSchedule();
            driver.FindElement(By.Id("Schedules_" + (noOfExistingSchedules - 2) + "__Name"))
                .SendKeys(RandomGenerator.RandomString(5, false) + "_AutomatedSchedule");
            var scheduleDateFrom = DateTime.Now.ToString("dd/MM/yyyy");
            var scheduleDateTo = DateTime.Now;
            scheduleDateTo = scheduleDateTo.AddDays(2);
            var dateTo = scheduleDateTo.ToString("dd/MM/yyyy");
            driver.FindElement(By.Id("Schedules_" + (noOfExistingSchedules - 2) + "__StartDate"))
                .SendKeys(scheduleDateFrom);
            driver.FindElement(By.Id("Schedules_" + (noOfExistingSchedules - 2) + "__EndDate")).SendKeys(dateTo);
            driver.FindElement(_saveScheduleButton).Click();
            ManageRecentlyAddedSchedule();
            EditSchedule();


        }

        public void DeleteExistingSchedules()
        {
            IReadOnlyCollection<IWebElement> buttons = driver.FindElements(By.TagName("button"));
            IList<string> list = new List<string>();
            foreach (var button in buttons)
            {
                if (button.Text.Contains("Delete"))
                {
                    try
                    {
                        driver.FindElement(By.CssSelector(".js-delete")).Click();
                    }
                    catch
                    {
                        driver.FindElement(By.CssSelector("tr:nth-child(3) .form-group > .btn")).Click();
                    }
                }
            }

        }


        public void ManageRecentlyAddedSchedule()
        {
            IReadOnlyCollection<IWebElement> anchors = driver.FindElements(By.TagName("a"));
            IList<string> list = new List<string>();
            foreach (var anchor in anchors)
            {
                if (anchor.GetAttribute("href").Contains("Admin/Booking/Schedule/"))
                {
                    list.Add(anchor.GetAttribute("href"));
                }
            }

            var recentlyAddedScheduleButtonHref = list.Last();
            GeneralMethods.ClickLinkByHref(driver,recentlyAddedScheduleButtonHref);
            Console.WriteLine(list.Last());
        }

        public void EditSchedule()
        {
            driver.FindElement(_closedYellowLabelBox).Click();
            int todayDay = Convert.ToInt32(DateTime.Now.DayOfWeek);
            Console.WriteLine(todayDay);
            todayDay = todayDay + 2;
            driver.FindElement(By.CssSelector(".unselectable:nth-child(1) > td:nth-child("+todayDay+") > span")).Click();  //Monday 08:00
            driver.FindElement(_memberDiscountPurpleLabelBox).Click();
            driver.FindElement(By.CssSelector(".unselectable:nth-child(6) > td:nth-child("+todayDay+") > span")).Click();  //Monday 10:30
            driver.FindElement(_editScheduleSaveButton).Click();
        }
        public int CountNoOfExistingSchedule()
        {
            var iRowCount = driver.FindElements(By.XPath("//*[@id='schedules']/tbody/tr")).Count;
            return iRowCount;
        }


    }
}
