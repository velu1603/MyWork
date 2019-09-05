using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin.Admin_Events
{
    public class AdminEventsActivitiesPage : Base
    {
        public AdminEventsActivitiesPage(IWebDriver driver) { this.driver = driver; }

        public readonly By _ballType = By.XPath("//select[@id='CreateOpenDaysActivity_BallColour']");

        

        public void SelectBallType()
        {
            IWebElement ballType = driver.FindElement(_ballType);
            SelectElement selectBallType = new SelectElement(ballType);
            selectBallType.SelectByIndex(0);
        }

    }  
}
