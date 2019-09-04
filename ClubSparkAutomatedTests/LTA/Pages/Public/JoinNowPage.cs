using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public
{
    class JoinNowPage : Base
    {
        public JoinNowPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public readonly By _memberPackageInfo = By.CssSelector("#membership-packages > div > div.row.gutters > div.col.span_4 > div > div > h2");
        public readonly By _clickNext = By.XPath("//div[@class='form-actions right']/a");


        public string JoinFixedMershipPackage(string fixedMembershipPackage)
        {
            String xpath = "//a[contains(text(),'" + fixedMembershipPackage + "')]";
            var element = driver.FindElement(By.XPath(xpath));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            element.Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_memberPackageInfo));

            return driver.FindElement(_memberPackageInfo).Text;
        }

        public void clickNext()
        {
            driver.FindElement(_clickNext).Click();

        }





    }
}
