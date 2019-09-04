    using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin
{
    public class MembershipPage : Base
    {
        ///
        //Locators
        //

        private readonly By _membershipLeftPanelIcon = By.XPath("//*[@id='dashboard-menu']/li[6]/a/span[1]");

        // ***********Below two elements are related to Fixed membership package ***********************
        private readonly By _FixedDatePackages = By.CssSelector("#package-type-navigation > li:nth-child(2) > a");
        private readonly By _addPackageFixedMembership = By.XPath("//a[contains(.,'+ New Package')]");

        private readonly By _addPackage = By.XPath("//*[@id='fixed-date-package']/div[1]/div/div[2]/a");
        private readonly By _membershipName = By.Id("Name");
        private readonly By _membershipCode = By.Id("Code");
        private readonly By _membershipTypeIndividual = By.Id("//*[@id='content']/form/div[1]/div/div/div[2]/div[4]/div[2]/div[1]/label/span[1]");
        private readonly By _membershipTypeGroup = By.Id("//*[@id='content']/form/div[1]/div/div/div[2]/div[4]/div[2]/div[2]/label/span[1]");

        private readonly By _individualSubCategoryListContainer = By.Id("select2-IndividualSubCategory-container");
        private readonly By _individualSubCategoryAdult = By.CssSelector("#select2-IndividualSubCategory-results > li:nth-of-type(1)");
        private readonly By _individualSubCategoryChild = By.CssSelector("#select2-IndividualSubCategory-results > li:nth-of-type(2)");
        private readonly By _individualSubCategoryJunior = By.CssSelector("#select2-IndividualSubCategory-results > li:nth-of-type(3)");
        private readonly By _individualSubCategorySocial = By.CssSelector("#select2-IndividualSubCategory-results > li:nth-of-type(4)");
        private readonly By _individualSubCategoryStudent = By.CssSelector("#select2-IndividualSubCategory-results > li:nth-of-type(5)");

        private readonly By _groupSubCategoryListContainer = By.Id("select2-GroupSubCategory-container");
        private readonly By _groupSubCategoryCouple = By.CssSelector("#select2-GroupSubCategory-results > li:nth-of-type(1)");
        private readonly By _groupSubCategoryFamily = By.CssSelector("#select2-GroupSubCategory-results > li:nth-of-type(2)");
        private readonly By _groupSubCategoryOther = By.CssSelector("#select2-GroupSubCategory-results > li:nth-of-type(3)");

        private readonly By _summaryText = By.Id("Summary");
        private readonly By _descriptionText = By.Id("Description");
        private readonly By _eligibilityText = By.Id("Eligibility");

        private readonly By _membershipDateTypeSameDate = By.XPath("//*[@id='content']/form/div[2]/div/div/div[2]/div[1]/div/div[2]/div[1]/label/span[1]");
        /* Implement this later when calender is change to a text field.
        private readonly By _membershipStartDate = By.Id();
        private readonly By _membershipEndDate = By.Id();
        */
        private readonly By _membershipDateTypeDateOfPurchased = By.XPath("//*[@id='content']/form/div[2]/div/div/div[2]/div[1]/div/div[2]/div[2]/label/span[1]");
        private readonly By _dopTermLengthListBoxContainer = By.Id("select2-TermLength-container");
        private readonly By _dopTermLengthContinuousNoEndDate= By.CssSelector("#select2-TermLength-results > li:nth-child(1)");
        private readonly By _dopTermLengthTwoWeeks= By.CssSelector("#select2-TermLength-results > li:nth-child(2)");
        private readonly By _dopTermLengthOneMonth = By.CssSelector("#select2-TermLength-results > li:nth-child(3)");
        private readonly By _dopTermLengthSixWeeks = By.CssSelector("#select2-TermLength-results > li:nth-child(4)");
        private readonly By _dopTermLengthTwoMonths = By.CssSelector("#select2-TermLength-results > li:nth-child(5)");
        private readonly By _gracePeriod = By.Id("GracePeriod");

        private readonly By _fullCostForNewMembersText = By.Id("Cost");
        private readonly By _fullCostForRenewalsText = By.Id("RenewalCost");

        private readonly By _directDebitInstallmentDateDefault = By.XPath("//*[@id='content']/form/div[5]/div/div/div[2]/div[1]/div[2]/div[1]/label/span[1]");
        private readonly By _directDebitInstallmentDateFirstOfMonth = By.XPath("//*[@id='content']/form/div[5]/div/div/div[2]/div[1]/div[2]/div[2]/label/span[1]");
        private readonly By _directDebitInstallmentDateFourteenOfMonth = By.XPath("//*[@id='content']/form/div[5]/div/div/div[2]/div[1]/div[2]/div[3]/label/span[1]");

        private readonly By _paymentReminderSevenDay = By.XPath("//input[@name='SevenDayReminderEmailEnabled']");
        private readonly By _paymentReminderFourteenDay = By.XPath("//input[@name='FourteenDayReminderEmailEnabled']");
        private readonly By _paymentReminderTwentyOneDay = By.XPath("//input[@name='SevenDayReminderEmailEnabled']");

        private readonly By _savePackageButton = By.CssSelector("button[class='btn btn-style-1 btn-lg js-save-package']");

        ///
        //Constructor
        //
        public MembershipPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        ///
        //Methods
        //

        public void CreateMembershipPackage(string membershipType, string membershipCategoryType, int directDebitInstallmentDate, int paymentReminder)
        {

            driver.FindElement(_membershipLeftPanelIcon).Click();
            driver.FindElement(_addPackage).Click();

            //Membership Details
            driver.FindElement(_membershipName).SendKeys(RandomGenerator.RandomString(5, false) + "_AutomatedMembership");
            var membershipCode = Convert.ToString(RandomGenerator.RandomNumber(400, 999999999));
            driver.FindElement(_membershipCode).SendKeys(membershipCode);
            SelectMembershipPackageType(membershipType,membershipCategoryType);

            //SelectMembershipPackageType(driver, membershipType, membershipCategoryType);
            driver.FindElement(_summaryText).SendKeys(RandomGenerator.RandomString(20,false)+"_AutomatedMembershipSummary");
            driver.FindElement(_descriptionText).SendKeys(RandomGenerator.RandomString(20, false) + "_AutomatedMembershipDescription");
            driver.FindElement(_eligibilityText).SendKeys(RandomGenerator.RandomString(20, false) + "_AutomatedMembershipEligibility");

            //Membership Dates
            driver.FindElement(_membershipDateTypeDateOfPurchased).Click();
            SelectItemFromList(_dopTermLengthListBoxContainer,_dopTermLengthTwoWeeks);
            //driver.FindElement(_dopTermLengthOneMonth).
            driver.FindElement(_gracePeriod).SendKeys("5");

            //Membership Costs
            driver.FindElement(_fullCostForNewMembersText).SendKeys(Convert.ToString(RandomGenerator.RandomNumber(150,200)));
            driver.FindElement(_fullCostForRenewalsText).SendKeys(Convert.ToString(RandomGenerator.RandomNumber(10,50)));

            //DirectDebit Options
            if (directDebitInstallmentDate.Equals(1))
            {
                driver.FindElement(_directDebitInstallmentDateFirstOfMonth).Click();
            }
            else
            {
                driver.FindElement(_directDebitInstallmentDateFourteenOfMonth).Click();
            }

            //PaymentReminders
            if (paymentReminder.Equals(7))
            {
                JavascriptExecuter(_paymentReminderSevenDay);

            }
            if (paymentReminder.Equals(14))
            {

                JavascriptExecuter(_paymentReminderFourteenDay);
            }
            else
            {
                JavascriptExecuter(_paymentReminderTwentyOneDay);
            }

           
            driver.FindElement(_savePackageButton).Click();
            
        }

        public void JavascriptExecuter(By element)
        {
            var element1 = driver.FindElement(element);
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element1);
        }
        public void SelectItemFromList(By containerElementName, By listElement)
        {
            var action = new Actions(driver);
            driver.FindElement(containerElementName).Click();
            driver.FindElement(listElement).Click();
        }

        public void SelectMembershipPackageType(string membershipType, string membershipCategoryType)
        {
            if (membershipType.Equals("Individual"))
            {
                switch(membershipCategoryType)
                {
                    case "Adult":
                        SelectItemFromList(_individualSubCategoryListContainer,_individualSubCategoryAdult);
                        break;
                    case "Child":
                        SelectItemFromList(_individualSubCategoryListContainer, _individualSubCategoryChild);
                        break;
                    case "Junior":
                        SelectItemFromList(_individualSubCategoryListContainer, _individualSubCategoryJunior);
                        break;
                    case "Social":
                        SelectItemFromList(_individualSubCategoryListContainer, _individualSubCategorySocial);
                        break;
                    case "Student":
                        SelectItemFromList(_individualSubCategoryListContainer, _individualSubCategoryStudent);
                        break;

                }
            }
            if(membershipType.Equals("Group"))
            {
                switch (membershipCategoryType)
                {
                    case "Couple":
                        SelectItemFromList(_groupSubCategoryListContainer, _groupSubCategoryCouple);
                        break;
                    case "Family":
                        SelectItemFromList(_groupSubCategoryListContainer, _groupSubCategoryFamily);
                        break;
                    case "Other":
                        SelectItemFromList(_groupSubCategoryListContainer, _groupSubCategoryOther);
                        break;

                }
            }
        }

       


    }
}
