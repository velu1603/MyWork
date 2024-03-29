﻿using ClubSparkAutomatedTests._Help;
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

        public readonly By _selectATennisFestival = By.XPath("//div[@class='row-fluid sortable ui-sortable']//div[2]//div[2]//div[2]//dl[1]//dt[1]//a[1]");

        public readonly By _publishEvent = By.XPath("//a[@id='open-days-publish']");

        public readonly By _viewEventOnline = By.XPath("//strong[contains(text(),'View event online')]");
        public readonly By _activities = By.XPath("//a[contains(text(),'Activities')]");

        public readonly By _addActivity = By.XPath("//a[@class='ns-btn activity-btn btn-style-1']");

        public readonly By _homePage = By.XPath("//span[contains(text(),'Home')]");

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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            driver.FindElement(_selectBrtishTennisFestivals).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        public void ClickOnTennisFestival()
        {
            driver.FindElement(_selectATennisFestival).Click();
        }

        public void ClickPublishEventToWebsite()
        {
            driver.FindElement(_publishEvent).Click();
            
        }

        public bool CheckViewEventOnline()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(_viewEventOnline));
            return driver.FindElement(_viewEventOnline).Displayed;
        }


        public void ClickActivities()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(_activities));
            driver.FindElement(_activities).Click();
        }
        public void ClickAddActivity()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_addActivity));
            driver.FindElement(_addActivity).Click();
        }

        public void GoToHome()
        {
            driver.FindElement(_homePage).Click();
        }



    }
}
