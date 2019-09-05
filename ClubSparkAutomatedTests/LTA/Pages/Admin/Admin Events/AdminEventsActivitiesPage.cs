using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
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

        public readonly By _addActivity = By.XPath("//a[@class='ns-btn activity-btn btn-style-1']");


    }

   
}
