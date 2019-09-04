using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin
{
    public class FixedMembershipDuplicatePackagePage : Base

    //This Class will contain all elements needed for admin to create actions on duplicated fixed membership package 
    {
        public FixedMembershipDuplicatePackagePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public readonly By _editPackage = By.LinkText("Edit Package");
        public readonly By _savePackageButton = By.CssSelector("button[class='btn btn-style-1 btn-lg js-save-package']");

        public readonly By _verifyAvailability = By.XPath("//div[@class='control']/p[contains(.,'Anyone (public)')]");

        public readonly By _navigateToDuplicatePkg = By.CssSelector("#content > div.section-breadcrumb.clearfix > ul > li:nth-child(1) > a");

        public readonly By _selectMember = By.XPath("id('members-table')//tbody//tr/td//span[@class='styled-checkbox-bg']");

        public readonly By _dropDownForPayment = By.CssSelector("div.operations-row > div > div > a.btn.btn-style-7.dropdown-toggle");

        public readonly By _selectPayment = By.LinkText("Payment");

        //*[@id='payment-members']/div/div/div[3]/button
        public readonly By _requestPayment = By.XPath("//*[@id='payment-members']/div/div/div[3]/button");


        public readonly By _selectSendAndContinue = By.XPath("//*[@id='auto-payment-members']/div/div/div[3]/button[1]");

        public readonly By _close = By.XPath("//*[@id='auto-payment-members']/div/div/div[3]/button[2]");

        public readonly By _moreColumns = By.CssSelector("div.results-to-show > div.more-columns.right5 > span");

        public readonly By _autopayment = By.CssSelector("ul > li:nth-child(1) > div > label > span.styled-checkbox-bg");

        public readonly By _status = By.CssSelector("#members-table > tbody > tr > td:nth-child(10) > span");
       

        public void clickEditPackage()
        {
            driver.FindElement(_editPackage).Click();
        }

        // Select public to make the package public 
        public void selectAvailability()                       
        {            
            var availability = driver.FindElement(By.Id("Availability"));
            var selectElement = new SelectElement(availability);
            selectElement.SelectByText("Anyone (public)");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_savePackageButton));
        }

        public void SavePackage()
        {
            driver.FindElement(_savePackageButton).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_verifyAvailability));
        }

        public string Availability()
        {
            return driver.FindElement(_verifyAvailability).Text;
        }
        public void NavigateToDuplicatedMembershipPackage()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_navigateToDuplicatePkg));
            driver.FindElement(_navigateToDuplicatePkg).Click();
        }
        public void SelectMemberUsingCheckbox()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_selectMember));
            driver.FindElement(_selectMember).Click();
        }

        public void SelectDropDownForPayment()
        {

            driver.FindElement(_dropDownForPayment).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement selectPyment = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_selectPayment));
            selectPyment.Click();
        }

        public void SelectAutoPayment()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());


            //driver.FindElement(_requestPayment).Click();

            driver.FindElement(_selectSendAndContinue).Click();
            Thread.Sleep(10000);

            driver.FindElement(_close).Click();

            /*
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement sendAndContinueElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_selectSendAndContinue));
            sendAndContinueElement.Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement close = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_close));
            close.Click();*/
        }

        public void SelectMoreColumns()
        {
           wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           IWebElement moreColumns= wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_moreColumns));
            moreColumns.Click();
        }

        public void CheckAutopayment()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement selectAutopyment = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_autopayment));           
            selectAutopyment.Click();
            SelectMoreColumns();  // Click on the selectmorecolumn to come out of the checkbox selection
        }

        public string GetStatus()        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_status));
            return driver.FindElement(_status).Text;
        }

    }
}
