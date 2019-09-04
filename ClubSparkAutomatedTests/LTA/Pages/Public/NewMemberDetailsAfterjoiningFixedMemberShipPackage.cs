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
    public class NewMemberDetailsAfterjoiningFixedMemberShipPackage : Base
    {

        public NewMemberDetailsAfterjoiningFixedMemberShipPackage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public readonly By _memberPackageDetails = By.CssSelector("# membershipJoinType > div:nth-child(5) > div.col.span_4 > div > div > h2");
       
        /* Adding only mandatory fields*/
        public readonly By _address1 = By.Id("Address1");
        public readonly By _town = By.Id("Town");
        public readonly By _clickTermsandConditions = By.CssSelector("#membershipJoinType > div:nth-child(6) > div > div.details.opt-ins.span8 > fieldset > div > div > label > span.styled-checkbox-bg");
        public readonly By _clickNext = By.XPath("//div[@class='form-actions']/button");

        public readonly By _paymentIsChecked = By.Id("SelectedPaymentMethod");

        public readonly By _continue = By.XPath("//button[@class='btn submit']");



       /* public string MemberPackageDetails()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_memberPackageDetails));


            return driver.FindElement(_memberPackageDetails).Text;
        }
        */
        public void Address1(String address)
        {

            driver.FindElement(_address1).SendKeys(address);


        }

        public void Town(String town)
        {
            driver.FindElement(_town).SendKeys(town);
                       
        }

        public void ClickTermsAndConditions()
        {
            var element = driver.FindElement(_clickTermsandConditions);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript("document.getElementById('AgreeTermsAndConditions').setAttribute('unselectable', 'off')");
            element.Click();

        }

        public void ClickNext()
        {
            driver.FindElement(_clickNext).Click();

         }

       /* public string directDebitIsSelected()
        {
            Boolean value = false;

            // return driver.FindElement(_paymentIsChecked).GetAttribute("checked");
           // return driver.FindElement(_paymentIsChecked)

        }*/

        public void clickContinue()
        {
            driver.FindElement(_continue).Click();

        }

    }
}
