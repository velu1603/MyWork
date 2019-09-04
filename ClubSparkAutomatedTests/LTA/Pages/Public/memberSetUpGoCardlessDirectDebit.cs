using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public
{
    public class MemberSetUpGoCardlessDirectDebit : Base
    {
        public MemberSetUpGoCardlessDirectDebit(IWebDriver driver)
        {
            this.driver = driver;
        }

        public readonly By _sortCode = By.XPath("//*[@id='customer_bank_accounts_branch_code']");
        public readonly By _accountNumber = By.XPath("//*[@id='customer_bank_accounts_account_number']");
        //public readonly By _postCode = By.XPath("//*[@id='address_lookup']");

        public readonly By _clickToEnterAddress = By.XPath("//*[@id='new_customer']/div[1]/div[3]/div[3]/div[2]/button");

        
        public readonly By _address1 = By.XPath(" //*[@id='customer_address_line1']");
        public readonly By _city = By.XPath("//*[@id='customer_city']");
        public readonly By _postcode = By.XPath("//*[@id='customer_postal_code']");
        public readonly By _clickDirectDebit = By.XPath(" //*[@id='submit-button']");
        public readonly By _confirm = By.XPath("//*[@id='submit-button']");


        public readonly By _membershipConfirmation = By.XPath("//h2[contains(.,'Thank you for your membership  purchase')]");

        public readonly By _dopdown = By.XPath("//*[@id='account-options']/a");

        public readonly By _signOut = By.CssSelector("#account-options > ul > li.sign-out > a");


        public void EnterSortCode(string sortcode)
        {

            driver.FindElement(_sortCode).SendKeys(sortcode);
        }

        public void EnterAccountNumber(string accountnumber)
        {
            driver.FindElement(_accountNumber).SendKeys(accountnumber);
        }

        public void ClickToEnterAddress()
        {

            driver.FindElement(_clickToEnterAddress).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_address1));

        }

        public void Address1(string address)
        {
            driver.FindElement(_address1).SendKeys(address);
        }

        public void Town(string town)
        {
            driver.FindElement(_city).SendKeys(town);
        }
        public void PostCode(string postcode)
        {
            driver.FindElement(_postcode).SendKeys(postcode);
        }
        public void ClickOnSetUpDirectDebit()
        {
            driver.FindElement(_clickDirectDebit).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_confirm));

        }

        public void ClickConfirm()
        {
            driver.FindElement(_confirm).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_membershipConfirmation));

        }

        public string MemberShipConfirmation()
        {
            return driver.FindElement(_membershipConfirmation).Text;
          
        }

        public void SignOut()
        {

            driver.FindElement(_dopdown).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_signOut));
            driver.FindElement(_signOut).Click();

        }


    }
  

      





}
