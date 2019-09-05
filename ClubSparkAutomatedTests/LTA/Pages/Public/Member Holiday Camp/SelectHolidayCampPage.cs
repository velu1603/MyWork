using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public.Member_Holiday_Camp
{
    public class SelectHolidayCampPage : Base
    {
        public SelectHolidayCampPage(IWebDriver driver) { this.driver = driver; }

        public readonly By _holidayCamps = By.CssSelector("#content > div.venue-navigation.desktop.tablet > div > div > div > ul > li:nth-child(5) > a");

        public void ClickHolidayCamp()
        {
            driver.FindElement(_holidayCamps).Click();
        }



    }
}
