using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using Selenium.WebDriver.Extensions.Sizzle;
using By = OpenQA.Selenium.By;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using Selenium.WebDriver.Extensions.Core;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin.AdminBooking
{
    public class FeaturesPage :Base
    {
        ///
        //Locators
        //

        private readonly By _featuresLeftPanelIcon = By.XPath("//*[@id='dashboard-menu']/li[3]/a/span[1]");
        //private readonly By _hardwareACT365FeatureCheckbox = By.CssSelector("checkbox:nth-child(26) .styled-checkbox-bg");
        private readonly By _hardwareACT365FeatureCheckbox = By.XPath("//div[26]/label/span");
        private readonly By _hardwareLightingFeatureCheckbox = By.CssSelector(".checkbox:nth-child(28) .styled-checkbox-bg");
        private readonly By _featureSaveButton = By.CssSelector(".btn-style-1");
        private readonly By _bookingLeftPanelIcon = By.XPath("//*[@id='dashboard-menu']/li[5]/a/span[1]");
        private readonly By _bookingSettingsHyperLink = By.LinkText("Settings");
        private readonly By _manageBasicSettingsOnBookingPageButton = By.LinkText("Manage basic settings");
        private readonly By _saveBasicSettings = By.CssSelector(".btn-style-1:nth-child(1)");
        private readonly By _bookingManageCourtsLink = By.LinkText("Manage courts");
        private readonly By _saveCourtsButton = By.CssSelector(".form - actions > .btn");

        ///
        //Constructor
        //
        public FeaturesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        ///
        //Methods
        //
        public void SetupGatedAccess()
        {
            driver.FindElement(_featuresLeftPanelIcon).Click();
            driver.FindElement(_hardwareACT365FeatureCheckbox).Click();
            driver.FindElement(_hardwareLightingFeatureCheckbox).Click();
            driver.FindElement(_featureSaveButton).Click();
            driver.FindElement(_bookingLeftPanelIcon).Click();
            driver.FindElement(_bookingSettingsHyperLink).Click();
            driver.FindElement(_manageBasicSettingsOnBookingPageButton).Click();

            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.CssSelector(".panel:nth-child(2) h2"));
            Console.WriteLine(elements);
            Assert.IsTrue(elements.Count > 0);
            Assert.IsTrue(driver.FindElement(By.CssSelector(".radio-inline .checked")).Enabled);
            var value = driver.FindElement(By.Id("select2-Hardware_Act365_SiteID-container")).Text;
            Assert.AreEqual("SportLabs", value);

            driver.FindElement(_saveBasicSettings).Click();
            driver.FindElement(_bookingSettingsHyperLink).Click();
            driver.FindElement(_bookingManageCourtsLink).Click();
            driver.FindElement(By.CssSelector(".select2-container--focus .select2-selection__rendered")).Click();
            var gateValueText = driver.FindElement(By.CssSelector(".select2-container--focus .select2-selection__choice")).Text;
            Assert.AreSame("Door Controller-3(Circuit-1)", gateValueText);
            driver.FindElement(By.CssSelector(".form-actions > .btn")).Click();
            IReadOnlyCollection<IWebElement> elements1 = driver.FindElements(By.CssSelector(".modal-title:nth-child(2)"));

            Console.WriteLine(elements1);

            Assert.IsTrue(elements1.Count > 0);

            driver.FindElement(_featuresLeftPanelIcon).Click();
            driver.FindElement(_hardwareACT365FeatureCheckbox).Click();
            driver.FindElement(_hardwareLightingFeatureCheckbox).Click();
            driver.FindElement(_featureSaveButton).Click();
        }

    }
}
