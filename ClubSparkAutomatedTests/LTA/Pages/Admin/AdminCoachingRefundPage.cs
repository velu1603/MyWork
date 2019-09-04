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
    public class AdminCoachingRefundPage : Base
    {
        public AdminCoachingRefundPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public readonly By _refundStatus = By.XPath("//*[@id='players']/div[2]/div[2]/div/form/div/table/tbody/tr/td[2]/span");


        public string RefundStatus()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_refundStatus));
            return driver.FindElement(_refundStatus).Text;
        }


    }
}
