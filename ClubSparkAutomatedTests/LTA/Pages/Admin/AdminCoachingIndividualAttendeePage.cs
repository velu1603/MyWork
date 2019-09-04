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
    public class AdminCoachingIndividualAttendeePage : Base
    {
        public AdminCoachingIndividualAttendeePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public readonly By _refund = By.LinkText("Refund");

        public readonly By _email = By.CssSelector("#players > div.person-card > div:nth-child(5) > div:nth-child(2) > dl > dd:nth-child(2)");
        public readonly By _clickConfirmCheckBox = By.CssSelector("#refund-attendee-modal > div > div > div.modal-body > div > form > div > div.control > div.checkbox-inline > label > span.styled-checkbox-bg");
        public readonly By _clickYes = By.CssSelector("#refund-attendee-modal > div > div > div.modal-footer > button.btn-primary.btn.btn-style-1.btn-lg.js-submit-refund-member");
        public readonly By _refundStatus = By.XPath("//*[@id='players']/div[2]/div[2]/div/form/div/table/tbody/tr/td[2]/span");

        public void ClickRefund()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_refund));
            driver.FindElement(_refund).Click();

        }

        public string ReadEmailID()
        {
            return driver.FindElement(_email).Text;    
        }

        public void SelectConfirmCheckbox()
        {

           
           driver.SwitchTo().Window(driver.WindowHandles.Last());
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            /*IWebElement checkbox = driver.FindElement(_clickConfirmCheckBox);
            if (!checkbox.Selected) {
                checkbox.Click();
            };*/

            var element = driver.FindElement(_clickConfirmCheckBox);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
            //element.Click();       
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public void ClickYes()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_clickYes));
            driver.FindElement(_clickYes).Click();            
        }
        public string RefundStatus()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_refundStatus));
            return driver.FindElement(_refundStatus).Text;
        }


    }
}
