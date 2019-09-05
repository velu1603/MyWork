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
    public class MemberHolidayCampDetailPage : Base
    {
        public MemberHolidayCampDetailPage(IWebDriver driver) { this.driver = driver; }


        public readonly By _selectSpace = By.CssSelector("tbody > tr.full-day > td:nth-child(4) > a");

        public readonly By _continueOrderSummary = By.CssSelector("#content > section > div.content-box > div > form > div:nth-child(5) > div > button");
        private readonly By _cookieBar = By.Id("cookie-bar");
        private readonly By _cookieIUnderstandButton = By.CssSelector("#cookie-bar > p > a.cb-enable");
        public void ClickSession()
        {
            if (driver.FindElement(_cookieBar).Displayed)
            {
                driver.FindElement(_cookieIUnderstandButton).Click();
            }
            IWebElement element = driver.FindElement(_selectSpace);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        public void ContinueToOrderSummary()
        {
            IWebElement element = driver.FindElement(_continueOrderSummary);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }



    }
}
