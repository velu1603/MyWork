using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages
{
    public class AdminAdvancedBookingPage : Base
    {
        public readonly By _clickToGoToTomorrow = By.CssSelector("div.date-control.pull-right > a.btn.day-nav-btn.tomorrow.pull-left");
        public readonly By _bookingslot = By.XPath("//*[@id='book-by-date-view']/div/div[2]/div[2]/ul/li[2]/div/div/div[2]/div/div[8]/a");

        public readonly By _advancedOptions = By.LinkText("Advanced options");

        public readonly By _submit = By.XPath("//button[@class='submit-btn']");
        private readonly By _cookieBar = By.Id("cookie-bar");
        private readonly By _cookieIUnderstandButton = By.CssSelector("#cookie-bar > p > a.cb-enable");


        //Construtor 
        public AdminAdvancedBookingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClicktoSelectNextDay()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_clickToGoToTomorrow));
            driver.FindElement(_clickToGoToTomorrow).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void clickOnATimeSlot()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement element = driver.FindElement(_bookingslot);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           driver.SwitchTo().Window(driver.WindowHandles.Last());  // This switch to Advance booking page

        }

        public void ClickOnAdvancedOptions()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(_advancedOptions).Click();

        }

        public void ClickSumbit()
        {
            if (driver.FindElement(_cookieBar).Displayed)
            {
                driver.FindElement(_cookieIUnderstandButton).Click();
            }
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_submit));
            driver.FindElement(_submit).Click();
        }
    }
}
