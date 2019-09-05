using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public.Member_Holiday_Camp
{
    public class MemberHolidayCampBookingPage : Base
    {
        public MemberHolidayCampBookingPage(IWebDriver driver) { this.driver = driver; }


        public readonly By _firstName = By.XPath("//*[@id='FirstName']");
        public readonly By _lastName = By.XPath("//*[@id='LastName']");

        //Check box for Gender 
        public readonly By _newMemberFemale = By.CssSelector(".controls:nth-child(2) > div > label > span.styled-radio-bg");
        public readonly By _newMemberMale = By.CssSelector(".controls:nth-child(3) > div > label > span.styled-radio-bg");
        public readonly By _emergencyNumber = By.XPath("//*[@id='EmergencyContact']");

        public readonly By _save = By.XPath("//button[text()='Save']");

        public readonly By _selectMember = By.XPath("//div[@class='control-group checkbox-control pull-left']//span[@class='styled-checkbox-bg']");
        public readonly By _termsAndConditions = By.XPath("//div[@class='control-group checkbox-control terms-control']//span[@class='styled-checkbox-bg']");

        public readonly By _payNow = By.XPath("//button[text()='Pay Now']");

        public void EnterDetails()
        {
            driver.FindElement(_firstName).SendKeys("Mary");
            driver.FindElement(_lastName).SendKeys("Jane");
            selectGender();
            memberDate(10);
            memberMonth("May");
            memberYear("1985");
            driver.FindElement(_emergencyNumber).SendKeys("100");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.FindElement(_save).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }
        public void selectGender()
        {
            //driver.FindElement(_newMemberMale).Click();
            driver.FindElement(_newMemberFemale).Click();

        }
        public void SelectMember()
        {            
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
          //  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_selectMember));
          //  driver.FindElement(_selectMember).Click();

            IWebElement element = driver.FindElement(_selectMember);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);
        }
        public void SelectTermsAndConditions()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement element = driver.FindElement(_termsAndConditions);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);
            
            //driver.FindElement(_termsAndConditions).Click();
        }

        public void ClickPayNow()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_payNow));
            // driver.FindElement(_payNow).Click();
            IWebElement element = driver.FindElement(_payNow);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);

        }

        public void memberDate(Int32 day)
        {
            /******************The below Javascript executor is repeating , so can be kept in a common Class**********/
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementsByClassName('selectboxit-text')[0].setAttribute('unselectable', 'off')");
            driver.FindElement(By.XPath("(//span[@class='selectboxit-text'])[1]")).Click();
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("selectboxit-text")));
            driver.FindElement(By.XPath("(//*[@class='selectboxit-options selectboxit-list']/li[" + (day + 1) + "])[1]")).Click();
        }
        public void memberMonth(string month)
        {
            Console.WriteLine("Inside this method i.e. Month ");
            /******************The below Javascript executor is repeating , so can be kept in a common Class**********/
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementsByClassName('selectboxit-text')[1].setAttribute('unselectable', 'off')");
            driver.FindElement(By.XPath("(//span[@class='selectboxit-text'])[2]")).Click();
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
           // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("monthSelectBoxIt")));
            //driver.FindElement(By.XPath("//*[@id='monthSelectBoxItOptions']/li[2]")).Click();
            driver.FindElement(By.XPath("(//*[@class='selectboxit-options selectboxit-list']/li[6])[2]")).Click();
        }

        public void memberYear(string year)
        {
            /******************The below Javascript executor is repeating , so can be kept in a common Class**********/
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementsByClassName('selectboxit-text')[2].setAttribute('unselectable', 'off')");
            driver.FindElement(By.XPath("(//span[@class='selectboxit-text'])[3]")).Click();
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("yearSelectBoxIt")));
            //driver.FindElement(By.XPath("//*//*[@id='yearSelectBoxItOptions']/li[63]")).Click();
            driver.FindElement(By.XPath("(//*[@class='selectboxit-options selectboxit-list']/li[63])[1]")).Click();
        }
    }
}
