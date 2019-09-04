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
    public class AdminCoachingProgrammes : Base
    {

        // *****This page contains programmes like Normal Adult, LTA Tennis for kids etc. This page can be used to add further programmes****
        //Constructor
        public AdminCoachingProgrammes(IWebDriver driver)
        {
            this.driver = driver;
        }

        public readonly By _selectNormalAdult = By.XPath("//*[@id='membership-package-list']//following::div[14]");
        public void SelectNormalAdult()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_selectNormalAdult));
            driver.FindElement(_selectNormalAdult).Click();
        }

    }
}
