using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Stripe
{
    public class StripePaymentRefundPage : Base
    {
        public StripePaymentRefundPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public readonly By _refund = By.CssSelector("div > div:nth-child(2) > div > div > a > div > span > span > span");

        public readonly By _refundStatus = By.XPath("//span[@class='Badge-text Text-color--gray600 Text-fontSize--12 Text-fontWeight--medium Text-lineHeight--16 Text-numericSpacing--proportional Text-typeface--base Text-wrap--noWrap Text-display--inline']" +
                                                      "//span[contains(text(),'Refunded')]");

        public void CLickOnRefunded()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(_refund).Click();
        }


        public void SearchEmailId(string emailId)
        {
            var table = driver.FindElement(By.ClassName("Table"));
            var rows = table.FindElements(By.TagName("tr"));
            Console.WriteLine(rows.Count);
            string beforeXpath = "//*[@id='merch']/div[2]/span/div/div/div[1]/div[1]/div[2]/div[2]/div/div[2]/div[2]/div/table/tbody/tr[";
            string afterXpath = "]/td[6]";
            
            // i starting from 4 as 1st 3 rows are hidden
            for (int i = 1; i < rows.Count; i++)
            {
                string emailXpath = beforeXpath + i + afterXpath;
                IWebElement emailNameCols = driver.FindElement(By.XPath(emailXpath));

                if (emailNameCols.Text.Contains(emailId))
                {
                    emailNameCols.Click();
                    break;
                }
            }

        }

        public string RefundStatus()
        {
            return driver.FindElement(_refundStatus).Text;
        }





    }
}
