using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin
{
    public class AdminCoachingNormalAdultTablePage : Base
    {
        public AdminCoachingNormalAdultTablePage(IWebDriver driver) { this.driver = driver; }

        public readonly By _shortCourse = By.CssSelector("#content > div:nth-child(6) > div > div > div.panel-body > p > a");
        public readonly By _getCourceTextFromLink = By.CssSelector("#content > div.rolling-courses > section > div.generic-header.has-content > div > div > div > div > h1");
        
        public void SearchCourseUI(string course)
        {
            var table = driver.FindElement(By.Id("scheme-listing"));
            var rows = table.FindElements(By.TagName("tr"));
            Console.WriteLine(rows.Count);
            string beforeXpath = "//*[@id='scheme-listing']/tbody/tr[";
            string afterXpath = "]/td[3]";

            for (int i = 4; i < rows.Count; i++)
            {
                string courseNameXpath = beforeXpath + i + afterXpath;               
                IWebElement courseNameCols = driver.FindElement(By.XPath(courseNameXpath));

                if (courseNameCols.Text.Contains(course))
                {
                    courseNameCols.Click();
                    break;
                }
            }
        }

        public void ClickDirectLink()
        {
            driver.FindElement(_shortCourse).Click();
        }

        public void SwitchToDirectLinkPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);            
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public string GetCourseNameFromDirectLinkPage()
        {
            return driver.FindElement(_getCourceTextFromLink).Text;
        }
    }
}
