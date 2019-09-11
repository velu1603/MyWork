using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public.MemberCoachingTab
{
    public class MemberBookingPage : Base
    {
        public MemberBookingPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public readonly By _selectToAttend = By.XPath("//td[@class='first-name']/preceding-sibling::td/label/span");
        public readonly By _termsAndConditions = By.XPath("//*[@id='booking-form']/div[3]/div/div[1]/div/div/div/label/span[1]");
        public readonly By _payNow = By.CssSelector("#booking-form > div.row.gutters.js-set-booking > div > div.submit.mini-tennis > button");
        private readonly By _cookieBar = By.Id("cookie-bar");
        private readonly By _cookieIUnderstandButton = By.CssSelector("#cookie-bar > p > a.cb-enable");
        // Below elements for swipe acccount
        public readonly By _swipeFrame = By.CssSelector("body > iframe:nth-child(11)");
        public readonly By _stripeCardNumber = By.XPath("(//input[@class='Fieldset-input Textbox-control'])[1]");
        public readonly By _mmyy = By.XPath("(//input[@class='Fieldset-input Textbox-control'])[2]");
        public readonly By _cvc = By.XPath("(//input[@class='Fieldset-input Textbox-control'])[3]");
        public readonly By _pay = By.CssSelector("main > form > nav > div > div > div > button");

        
        public void SelectCourseBooking()
        {
            if (driver.FindElement(_cookieBar).Displayed)
            {
                driver.FindElement(_cookieIUnderstandButton).Click();
            }
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_selectToAttend));

            var element = driver.FindElement(_selectToAttend);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
            element.Click();

            driver.FindElement(_selectToAttend).Click();
            driver.FindElement(_termsAndConditions).Click();
            driver.FindElement(_payNow).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        public void EnterStripeAccount()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());       
            IWebElement iframe = driver.FindElement(_swipeFrame);
            driver.SwitchTo().Frame(iframe);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            GeneralMethods.WaitForElement(driver,_stripeCardNumber);            
            driver.FindElement(_stripeCardNumber).SendKeys("4242 4242 4242 4242");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_mmyy));
            driver.FindElement(_mmyy).SendKeys("12 / 22");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_cvc));
            driver.FindElement(_cvc).SendKeys("123");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_pay));
            driver.FindElement(_pay).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.SwitchTo().DefaultContent();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        
       
    }
}
