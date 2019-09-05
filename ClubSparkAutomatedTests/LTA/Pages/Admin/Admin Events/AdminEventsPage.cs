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
    public class AdminEventsPage : Base
    {
        public AdminEventsPage(IWebDriver driver) { this.driver = driver; }

        public readonly By _viewingLeftPanelIcon = By.XPath("//*[@id='dashboard-menu']/li[7]/a/span[1]");

        public readonly By _createNew = By.LinkText("Create new");

        public readonly By _selectBrtishTennisFestivals = By.XPath("//div[@class='inline-control btf']//div[@class='bg']");

        public void SelectEvents()
        {
            driver.FindElement(_viewingLeftPanelIcon).Click();
        }

        public void SelectCreateNew()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_createNew));
            driver.FindElement(_createNew).Click();
        }

        public void SelectEventToHost()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            driver.FindElement(_selectBrtishTennisFestivals).Click();
        }



    }
}
