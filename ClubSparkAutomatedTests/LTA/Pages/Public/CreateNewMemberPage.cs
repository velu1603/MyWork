using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public
{
    public class CreateNewMemberPage : Base
    {
        public CreateNewMemberPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        // Click on register 
        public readonly By _register = By.CssSelector("#account-options > ul > li.border.last > span > a");


        // Enter user details Firstname, Lastname, email mobile number
        public readonly By _newMemberFirstName = By.Id("FirstName");
        public readonly By _newMemberLastName = By.Id("LastName");
        public readonly By _newMemberEmail = By.Id("EmailAddress");
        public readonly By _newMemberConfirmEmail = By.Id("ConfirmEmailAddress");
        public readonly By _newMemberMobileNumber = By.Id("PhoneNumber");

        // Date of birth - Day,Month,Year     
        public readonly By _newMemberDOBDay = By.XPath("//*[@id='daySelectBoxIt']");
        public readonly By _newMemberDOBMonth = By.XPath("//*[@id='monthSelectBoxItContainer']");
        public readonly By _newMemberDOBYear = By.XPath("//*[@id='yearSelectBoxItArrow']");

        //Check box for Gender 
        public readonly By _newMemberMale = By.CssSelector(".controls:nth-child(2) > div > label > span.styled-radio-bg");
        public readonly By _newMemberFemale = By.CssSelector(".controls:nth-child(3) > div > label > span.styled-radio-bg");

        //postcode 
        public readonly By _newMemberPostcode = By.Id("Postcode");

        //Password
        public readonly By _newMemberPassword = By.Id("Password");

        //SignUp 
        public readonly By _newMemberSignUp = By.XPath("//button[contains(.,'Sign Up')]");

        //new user info 
        public readonly By _newMemberNameontheHomePage = By.XPath("//*[@class='user-name']");
               
        public void RegisterUser(string firstName,string lastName,string emailAddress,string confirmEmailAddress)
                                                                  
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["LTA_MemberURL"]);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_register));
            driver.FindElement(_register).Click();

            // Pass relevant fields to create new user
            memberFirstName(firstName);
            memberLastName(lastName);
            memberEmailAddress(emailAddress);
            memberConfirmEmailAddress(confirmEmailAddress);
            memberMobileNumber("1010101010");
            memberDate(10);
            memberMonth("May");
            memberYear("1985");
            selectGender();
            postCode("SW193RQ");
            password("clubspark");
            signUp();
            getMemberText();
        }
         public void memberFirstName(string firstName)
        {
            driver.FindElement(_newMemberFirstName).SendKeys(firstName);
        }
        public void memberLastName(string lastName)
        {
            driver.FindElement(_newMemberLastName).SendKeys(lastName);
        }
        public void memberEmailAddress(string emailAddress)
        {
            driver.FindElement(_newMemberEmail).SendKeys(emailAddress);
        }
        public void memberConfirmEmailAddress(string emailAddress)
        {
            driver.FindElement(_newMemberConfirmEmail).SendKeys(emailAddress);
        }
        public void memberMobileNumber(string mobileNumber)
        {
            driver.FindElement(_newMemberMobileNumber).SendKeys(mobileNumber);
        }
        public void memberDate(Int32 day)
        {
            /******************The below Javascript executor is repeating , so can be kept in a common Class**********/
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('daySelectBoxItText').setAttribute('unselectable', 'off')");
            driver.FindElement(By.Id("daySelectBoxItText")).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("daySelectBoxItText")));
            driver.FindElement(By.XPath("//*[@id='daySelectBoxItOptions']/li[" + (day + 1) + "]")).Click();
        }
        public void memberMonth(string month)
        {
            
            /******************The below Javascript executor is repeating , so can be kept in a common Class**********/
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('daySelectBoxItText').setAttribute('unselectable', 'off')");
            driver.FindElement(By.Id("monthSelectBoxIt")).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("monthSelectBoxIt")));
            driver.FindElement(By.XPath("//*[@id='monthSelectBoxItOptions']/li[2]")).Click();
        }
        public void memberYear(string year)
        {
            /******************The below Javascript executor is repeating , so can be kept in a common Class**********/
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('yearSelectBoxIt').setAttribute('unselectable', 'off')");
            driver.FindElement(By.Id("yearSelectBoxIt")).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("yearSelectBoxIt")));
            driver.FindElement(By.XPath("//*[@id='yearSelectBoxItOptions']/li[63]")).Click();

        }
        public void selectGender()
        {
            //driver.FindElement(_newMemberMale).Click();
            driver.FindElement(_newMemberFemale).Click();
        }
        public void postCode(string postcode)
        {
            driver.FindElement(_newMemberPostcode).SendKeys("postcode");
        }
        public void password(string pasword)
        {
            driver.FindElement(_newMemberPassword).SendKeys(pasword);
        }
        public void signUp()
        {
            IWebElement element = driver.FindElement(_newMemberSignUp);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }
        public string getMemberText()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_newMemberNameontheHomePage));
            return driver.FindElement(_newMemberNameontheHomePage).Text;
        }
    }

}

