using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public.MemberEventsBooking
{
    public class MemberEventsBookingPage : Base
    {
        public MemberEventsBookingPage(IWebDriver driver) { this.driver = driver; }

        // Click on events
        public readonly By _events = By.XPath("(//a[contains(text(),'Events')])[1]");

        public readonly By _tennisFestival = By.XPath("(//a[contains(text(),'Tennis Festival')])[1]");

        public readonly By _book = By.LinkText("Book");

        private readonly By _cookieBar = By.Id("cookie-bar");
        private readonly By _cookieIUnderstandButton = By.CssSelector("#cookie-bar > p > a.cb-enable");

        public readonly By _basketIcon = By.XPath("//span[@class='basket-icon']");
        public readonly By _bookNow = By.XPath("//a[@class='btn btn-medium btn-colour-1']");

        public readonly By _selectMember = By.XPath("//div[@class='clearfix']//span[@class='styled-checkbox-bg']");
        public readonly By _confirm = By.XPath("//a[@class='btn btn-style-8 btn-small btn-colour-6 js-select-next-event']");

        public readonly By _termsAndConditions = By.XPath("//div[@class='controls full-width']//span[@class='styled-checkbox-bg']");

        public readonly By _payNow = By.XPath("//button[@id='paynow']");

        public void ClickEvents()
        {
            driver.FindElement(_events).Click();
        }
        public void SelectTennisFestival()
        {
            driver.FindElement(_tennisFestival).Click();
        }
        public string getEventNameForBooking(string eventName)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string xpath = "//h3[contains(text(),'" + eventName + "')]";
            var element = driver.FindElement(By.XPath(xpath));
            return element.Text;
        }
        public void Book()
        {
            if (driver.FindElement(_cookieBar).Displayed)
            {
                driver.FindElement(_cookieIUnderstandButton).Click();
            }
            IWebElement element = driver.FindElement(_book);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);            
        }
        public void ClickBasket()
        {
            driver.FindElement(_basketIcon).Click();
        }
        public void BookNow()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_bookNow));
            driver.FindElement(_bookNow).Click();
        }
        public void SelectMember()
        {
            driver.FindElement(_selectMember).Click();
        }
        public void ClickConfirm()
        {
            driver.FindElement(_confirm).Click();
        }
        public void ClickTermsAndConditions()
        {
            driver.FindElement(_termsAndConditions).Click();
        }
        public void ConfirmAndPayNow()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_payNow));
            driver.FindElement(_payNow).Click();
        }


    }
}
