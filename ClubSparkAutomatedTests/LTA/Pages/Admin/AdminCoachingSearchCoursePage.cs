using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin
{
    public class AdminCoachingSearchCoursePage : Base
    {
        public AdminCoachingSearchCoursePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SearchCourseForCancellation(string course)
        {
            var table = driver.FindElement(By.Id("scheme-listing"));
            var rows = table.FindElements(By.TagName("tr"));
            Console.WriteLine(rows.Count);
            string beforeXpath = "//*[@id='scheme-listing']/tbody/tr[";
            string afterXpath = "]/td[3]";

            // i starting from 4 as 1st 3 rows are hidden
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
    }
}
