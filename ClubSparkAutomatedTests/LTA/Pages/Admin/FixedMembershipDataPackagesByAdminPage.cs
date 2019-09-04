using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ClubSparkAutomatedTests.LTA.Pages.Admin
{
    public class FixedMembershipDataPackagesByAdminPage : Base
    {
        //This Class will contain all elements needed to create fixed membership packages


        public FixedMembershipDataPackagesByAdminPage(IWebDriver driver) {
            this.driver = driver;
        }
       
       
        public readonly By _membershipLeftPanelIcon = By.XPath("//*[@id='dashboard-menu']/li[6]/a/span[1]");

        // Below two elements are related to Fixed membership package 
        public readonly By _FixedDatePackages = By.CssSelector("#package-type-navigation > li:nth-child(2) > a");
        public readonly By _addPackageFixedMembership = By.XPath("//a[contains(.,'+ New Package')]");

        public readonly By _membershipName = By.Id("Name");
        public readonly By _membershipCode = By.Id("Code");
        public readonly By _membershipTypeIndividual = By.Id("//*[@id='content']/form/div[1]/div/div/div[2]/div[4]/div[2]/div[1]/label/span[1]");
        public readonly By _membershipTypeGroup = By.Id("//*[@id='content']/form/div[1]/div/div/div[2]/div[4]/div[2]/div[2]/label/span[1]");

       
        public readonly By _summaryText = By.Id("Summary");
        public readonly By _descriptionText = By.Id("Description");
        public readonly By _eligibilityText = By.Id("Eligibility");

       

        // ******************for fixed membership date *******************************************************
        public readonly By _fixedMembershipStartDate = By.CssSelector("#MembershipStartDate");
        public readonly By _fixedMembershipEndDate = By.CssSelector("#MembershipEndDate");

        // ************* For Allow payment in full? , used for fixed membership creation **********************
        public readonly By _fixedmembershipAllowPaymentInFull = By.XPath("//*[@id='full-toggle']/div[2]/div/label/span[1]");



        public readonly By _membershipDateTypeDateOfPurchased = By.XPath("//*[@id='content']/form/div[2]/div/div/div[2]/div[1]/div/div[2]/div[2]/label/span[1]");

       
        public readonly By _gracePeriod = By.Id("GracePeriod");

        public readonly By _fullCostForNewMembersText = By.Id("Cost");
        public readonly By _fullCostForRenewalsText = By.Id("RenewalCost");

      

        public readonly By _savePackageButton = By.CssSelector("button[class='btn btn-style-1 btn-lg js-save-package']");
                

        public bool? IsVisible { get; internal set; }




        // Clickon the membership to go to membership page
        public void ClickMembership()
        {
            driver.FindElement(_membershipLeftPanelIcon).Click();
            GoToFixedDataPackage();
            AddNewPackage();
            CreateFixedMembershipPackage();

            // need to add wait for the member page to load. 

        }

        public void GoToFixedDataPackage()
        {
            driver.FindElement(_membershipLeftPanelIcon).Click();  //--> Remove it after the sroll test
            driver.FindElement(_FixedDatePackages).Click();

            // need to add wait for the fixed member page to load. 

        }

        public void AddNewPackage() {

            
            driver.FindElement(_addPackageFixedMembership).Click();

            Console.WriteLine("Inside the new package");


        }
        public void CreateFixedMembershipPackage()
        {
            // Member name
            driver.FindElement(_membershipName).SendKeys("_FixedMemberShip_A"+RandomGenerator.RandomString(5, false));

            driver.FindElement(_membershipCode).SendKeys("_FixedMemberShip_Automated_"+DateTime.Now);

            // Sending keys for summary,description and Eligibility
            driver.FindElement(_summaryText).SendKeys(RandomGenerator.RandomString(20, false) + "_FixedMembershipSummary");
            driver.FindElement(_descriptionText).SendKeys(RandomGenerator.RandomString(20, false) + "_FixedMembershipDescription");
            driver.FindElement(_eligibilityText).SendKeys(RandomGenerator.RandomString(20, false) + "_FixedMembershipEligibility");


            // Membership start and end date             
            SelectStartDate();
            SelectEndDate();

            // Payment information 
            SelectAllowPaymentInFull();
            FixedMembershipCosts();

            // Save packages 
            SavePackage();

            


        }

        public void SelectStartDate()
        /*
         * This method will select the start date of the fixed membership
         * This will input (current day + 5)
         * Note: This date can be changed by changing the values withingthe Adddays() method below 
         * 
         */

        {

            var selectStartDate = DateTime.Now.AddDays(5).ToString("dd/MM/yyyy");

            Console.WriteLine(selectStartDate);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.querySelector('#MembershipStartDate').value=\'"+ selectStartDate+ "\'");

            //_fixedMembershipStartDate 

         }

        public void SelectEndDate()
        /*
         * This method will select the start date of the fixed membership
         * This will input (current day + 35)  ==> it will cretate a 30 day membership period
         * 
         * Note: This date can be changed by changing the values withingthe Adddays() method below 
         * 
         */
        {
            var today = DateTime.Now.ToString("dd/MM/yyyy");

            var selectStartDate = DateTime.Now.AddDays(35).ToString("dd/MM/yyyy");

            Console.WriteLine(selectStartDate);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.querySelector('#MembershipEndDate').value=\'" + selectStartDate + "\'");
        }

        public void SelectAllowPaymentInFull()
        {
            if(!driver.FindElement(_fixedmembershipAllowPaymentInFull).Selected) // select the check box only if it is not selected
            {
                driver.FindElement(_fixedmembershipAllowPaymentInFull).Click();

            }          

        }

        public void FixedMembershipCosts()
        {
            //Membership Costs
            driver.FindElement(_fullCostForNewMembersText).SendKeys("35");
            driver.FindElement(_fullCostForRenewalsText).SendKeys("30");

        }

        public void PaymentMethod()
        {


        }

        public void SavePackage()
        {           
            driver.FindElement(_savePackageButton).Click();
        }
        // Below method for creating duplicate of a fixed membership package
        public void DuplicateMemberPackage(string memberPackageJoined)
        {
            IWebElement next = driver.FindElement(By.XPath("//*[@id='f-date-package-table_next']/a"));
            var table = driver.FindElement(By.Id("f-date-package-table"));
            var rows = table.FindElements(By.TagName("tr"));
            Console.WriteLine(rows.Count);
            // Working code below 
            string beforeXpath = "//*[@id='f-date-package-table']/tbody/tr["; 
            string afterXpath = "]/td[12]/div/button";
            string firstcolsxpath = "]/td[1]";
           
            for (int i = 1;i < rows.Count; i++)
            {
                string completeXpath = beforeXpath + i + afterXpath;
                string firstcoltext = beforeXpath + i + firstcolsxpath;
                IWebElement firstCols = driver.FindElement(By.XPath(firstcoltext));// First column contains the membership package
                IWebElement lastCols = driver.FindElement(By.XPath(completeXpath));// last column contains the options to be clicked
                
                //-------> Click the corresponding Options based on the passed membership package <--------------
                if (firstCols.Text.Contains(memberPackageJoined))
                {
                    Console.WriteLine("Inside the loop "+firstCols.Text);
                    Console.WriteLine("Inside the loop reading the last column " + lastCols.Text);
                    lastCols.Click();
                     break;
                }
             }
            // Wait for 5 seconds and then click the duplicate 
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("Duplicate")));
            element.Click();
            Thread.Sleep(6000);

            //Click on the duplicate button on the pop up window
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.FindElement(By.XPath("//*[@id='duplicate-package']/div/div/div[3]/button")).Click();
            Thread.Sleep(40000);

        }   
        
    }
}
