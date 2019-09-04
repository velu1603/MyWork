using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using Selenium.WebDriver.Extensions.Sizzle;
using By = OpenQA.Selenium.By;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace ClubSparkAutomatedTests.LTA.Pages.Public.PublicBooking
{
    public class PublicBookingHomePage : Base
    {

        ///
        /// Locators
        //

        //private readonly string Court1CheckBox = ".pull-left .controls:nth-of-type(0) .styled-checkbox-bg";
        //private readonly By _court1CheckBox = By.XPath("*//div[@class='pull-left']/div[1]/div/label/span[@class='styled-checkbox-bg']");
        private readonly By _court1CheckBox = By.CssSelector(".pull-left .controls:nth-of-type(1) .styled-checkbox-bg");
        private readonly By _court2CheckBox = By.CssSelector(".pull-left .controls:nth-of-type(2) .styled-checkbox-bg");
        private readonly By _court3CheckBox = By.CssSelector(".pull-left .controls:nth-of-type(3) .styled-checkbox-bg");
        private readonly By _cookieBar = By.Id("cookie-bar");
        private readonly By _cookieIUnderstandButton = By.CssSelector("#cookie-bar > p > a.cb-enable");
        private readonly By _addNewContactLink = By.LinkText("Add new contact");
        private readonly By _firstName = By.Id("FirstName");
        private readonly By _lastName = By.Id("LastName");
        private readonly By _emailAddress = By.Id("EmailAddress");
        private readonly By _phoneNumber = By.Id("PhoneNumber");
        private readonly By _adminNote = By.Id("AdminNote");
        private readonly By _submitBookingButton = By.CssSelector(".submit-btn");
        private readonly By _bookingConfirmedMessage = By.CssSelector(".container > h1");
        private readonly By _errorMessage1 = By.CssSelector(".field-validation-error");
        private readonly By _errorMessage2 = By.CssSelector("div:nth-child(2) > p");


        ///
        //Constructor
        //
        public PublicBookingHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void BookIntervalFromNotBooked(string courtNumber)
        {
            var startTimeHour = Convert.ToInt32(DateTime.Now.ToString("HH"));
            startTimeHour = startTimeHour + 1;
            var startTimeMinutes = DateTime.Now.ToString("mm");
            var startTimeSeconds = DateTime.Now.ToString("ss");
            Console.WriteLine(startTimeHour + ":" + startTimeMinutes + ":" + startTimeSeconds);
            switch (courtNumber)
            {
                case "Court1":
                    driver.FindElement(By.XPath(
                        "//*[@id='book-by-date-view']/div/div[2]/div[2]/ul/li[1]/div/div/div[2]/div/div[" +
                        startTimeHour + "]")).Click();
                    break;
                case "Court2":
                    driver.FindElement(By.XPath(
                        "//*[@id='book-by-date-view']/div/div[2]/div[2]/ul/li[2]/div/div/div[2]/div/div[" +
                        startTimeHour + "]")).Click();
                    break;
                case "Court3":
                    driver.FindElement(By.XPath(
                        "//*[@id='book-by-date-view']/div/div[2]/div[2]/ul/li[3]/div/div/div[2]/div/div[" +
                        startTimeHour + "]")).Click();
                    break;

            }
        }

        public void CreateBookingByAdmin(string courtNumber, string testScenarioType)
        {
            
            if(driver.FindElement(_cookieBar).Displayed)
            {
                driver.FindElement(_cookieIUnderstandButton).Click();
            }
            System.Threading.Thread.Sleep(4000);
            driver.FindElement(_addNewContactLink).Click();
            string firstName = RandomGenerator.RandomString(5, false);
            string lastName = RandomGenerator.RandomString(5, false);
            driver.FindElement(_firstName).SendKeys(firstName);
            driver.FindElement(_lastName).SendKeys(lastName);
            driver.FindElement(_emailAddress).SendKeys(firstName+"."+lastName+"@testautomation.com");
            //driver.FindElement(_emailAddress).SendKeys("7777777777");
            driver.FindElement(_adminNote).SendKeys("Booking created by Automated_Admin_User");

            switch (courtNumber)
            {
                case "Court1":
                    Actions actions1 = new Actions(driver);
                    actions1.MoveToElement(driver.FindElement(_court1CheckBox));
                    actions1.Perform();

                    driver.FindElement(_court1CheckBox).Click();
                    break;
                case "Court2":
                    Actions actions2 = new Actions(driver);
                    actions2.MoveToElement(driver.FindElement(_court2CheckBox));
                    actions2.Perform();
                    driver.FindElement(_court2CheckBox).Click();
                    break;
                case "Court3":
                    Actions actions3 = new Actions(driver);
                    actions3.MoveToElement(driver.FindElement(_court2CheckBox));
                    actions3.Perform();
                    driver.FindElement(_court3CheckBox).Click();
                    break;
            }

            var tomorrow = DateTime.Today.AddDays(3).Date;
            ((IJavaScriptExecutor)base.driver).ExecuteScript($"$('#StartDate').val('{tomorrow:yyyy/MM/dd}')"); // Enables the from date box
            driver.FindElement(_submitBookingButton).Click();
            System.Threading.Thread.Sleep(3000);
            switch (testScenarioType)
            {
                case "1PositiveTestCase:ConfirmedBooking":
                    IReadOnlyCollection<IWebElement> elements = driver.FindElements(_bookingConfirmedMessage);
                    Console.WriteLine(elements.Count);
                    Assert.IsTrue(elements.Count > 0);
                    break;
                case "2NegativeTestCase:DuplicateBooking":
                    var errorMessage1 = driver.FindElement(_errorMessage1).Text;
                    Assert.AreEqual("Booking clashes: 1", errorMessage1);
                    var errorMessage2 = driver.FindElement(_errorMessage2).Text;
                    Assert.AreEqual("Please amend your bookings to continue.", errorMessage2);
                    break;
            }
          

        }

    }

}

