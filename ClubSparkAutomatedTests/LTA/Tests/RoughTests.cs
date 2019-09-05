using ClubSparkAutomatedTests._Help;
using ClubSparkAutomatedTests.LTA.Pages;
using ClubSparkAutomatedTests.LTA.Pages.Admin;
using ClubSparkAutomatedTests.LTA.Pages.Admin.Admin_Events;
using ClubSparkAutomatedTests.LTA.Pages.Admin.AdminHolidayCamp;
using ClubSparkAutomatedTests.LTA.Pages.Public;
using ClubSparkAutomatedTests.LTA.Pages.Public.Member_Holiday_Camp;
using ClubSparkAutomatedTests.LTA.Pages.Public.MemberCoachingTab;
using ClubSparkAutomatedTests.LTA.Pages.Stripe;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Tests
{
    [TestFixture]
    public class RoughTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Initialization()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
           // _driver.Navigate().GoToUrl("http://test.clubspark.uk/regressiontestvenue/Membership/Join");
           // _driver.Navigate().GoToUrl("http://test.clubspark.uk/regressiontestvenue");

        }
        //[Ignore("ignore this test")]
        [TestCase]
        public void ClickOnAFixedMembershipPackage()
        {
            _driver.Navigate().GoToUrl("http://test.clubspark.uk/regressiontestvenue");
            _driver.FindElement(By.LinkText("Sign in")).Click();
            //_driver.FindElement(By.XPath("//*[@id='account - options']/ul/li[1]/span[1]/a")).Click();

            _driver.FindElement(By.XPath("//*[@id='EmailAddress']")).SendKeys("David12311@gmail.com");
            _driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("clubspark");

            _driver.FindElement(By.Id("signin-btn")).Click();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _driver.FindElement(By.XPath("//div[@class='container']/descendant::li[contains(.,'Membership')]")).Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            JoinNowPage fixedMembershipPackage = new JoinNowPage(_driver);
            fixedMembershipPackage.JoinFixedMershipPackage("_FixedMemberShip_AITIK");
            fixedMembershipPackage.clickNext();

            NewMemberDetailsAfterjoiningFixedMemberShipPackage memberPackageDetails = new NewMemberDetailsAfterjoiningFixedMemberShipPackage(_driver);

           //memberPackageDetails.MemberPackageDetails();
            //Console.WriteLine(memberpackage);

            memberPackageDetails.Address1("41-47 Hartfield Road");
            memberPackageDetails.Town("London");
            memberPackageDetails.ClickTermsAndConditions();
            memberPackageDetails.ClickNext();

            // Assert
            //string paymentSelected = memberPackageDetails.directDebitIsSelected();
            // Assert

            // Assert.IsTrue(paymentSelected.Equals("True"));
            memberPackageDetails.clickContinue();

            MemberSetUpGoCardlessDirectDebit memberSetUpDirectDebit = new MemberSetUpGoCardlessDirectDebit(_driver);

            memberSetUpDirectDebit.EnterSortCode("200000");
            memberSetUpDirectDebit.EnterAccountNumber("44779911");
            memberSetUpDirectDebit.ClickToEnterAddress();
            memberSetUpDirectDebit.Address1("41-47 Hartfield Road");
            memberSetUpDirectDebit.Town("London");
            memberSetUpDirectDebit.PostCode("SW193RQ");
            memberSetUpDirectDebit.ClickOnSetUpDirectDebit();
            memberSetUpDirectDebit.ClickConfirm();
            //Assert  --> member has purchased the package 
            Assert.AreEqual(memberSetUpDirectDebit.MemberShipConfirmation(), "Thank you for your membership purchase", "The names should match");

            memberSetUpDirectDebit.SignOut();



        }
        //[Ignore("ignore this test")]
        [TestCase]
        public void AdmniPageDuplicatePackage()
        {
            var loginPage = new LoginPage(_driver);  // >>>>>>>Loginto Admnin portal 
            loginPage.Login();
            FixedMembershipDataPackagesByAdminPage fixedMembershipPackage = new FixedMembershipDataPackagesByAdminPage(_driver);
            FixedMembershipDuplicatePackagePage duplicatePage = new FixedMembershipDuplicatePackagePage(_driver);
            fixedMembershipPackage.GoToFixedDataPackage();
            fixedMembershipPackage.DuplicateMemberPackage("_FixedMemberShip_MXDWY");  //--->\here pass the newly created memberpackage in the test 
            duplicatePage.clickEditPackage();
            duplicatePage.selectAvailability();
            duplicatePage.SavePackage();
            Assert.AreEqual(duplicatePage.Availability(), "Anyone (public)", "The names match");
            duplicatePage.NavigateToDuplicatedMembershipPackage();
        }
        //[Ignore("ignore this test")]
        [TestCase]
        public void SelectMemberUsingCheckbox()
        {
            _driver.Navigate().GoToUrl("http://test.clubspark.uk/regressiontestvenue/Admin/Membership/Members/ef7ff811-3b67-4d3f-9f64-02c9d8d1b866");
            var loginPage = new LoginPage(_driver);
            loginPage.Login();
            _driver.Navigate().GoToUrl("http://test.clubspark.uk/regressiontestvenue/Admin/Membership/Members/edaba010-6142-4aee-9df2-f0800692f2da");
            FixedMembershipDuplicatePackagePage duplicatePage = new FixedMembershipDuplicatePackagePage(_driver);
           // duplicatePage.SelectMemberUsingCheckbox();
            //_driver.FindElement(By.XPath("id('members-table')//tbody//tr/td//span[@class='styled-checkbox-bg']")).Click();
           // duplicatePage.SelectDropDownForPayment();
            Thread.Sleep(40000);
           // duplicatePage.SelectAutoPayment();
            //duplicatePage.Close();
            duplicatePage.SelectMoreColumns();
            duplicatePage.CheckAutopayment();

            string statusOfMember = duplicatePage.GetStatus();
            Assert.AreEqual(statusOfMember, "Pending", "The names match");
            Assert.That(statusOfMember,Is.EqualTo(statusOfMember));
        }
        [Ignore("ignore this test")]
        [TestCase]
        public void CreateAnAdvancedBooking()
        {
            //Arrange
            var loginPage = new LoginPage(_driver);
            AdminHomePage adminPage = new AdminHomePage(_driver);
            AdminBookingPage adminBookingPage = new AdminBookingPage(_driver);
            AdminAdvancedBookingPage adminAdvancedBookingPage = new AdminAdvancedBookingPage(_driver);
            AdminAdvancedBookingConfirmationPage advancedBookingConfirmationMessage = new AdminAdvancedBookingConfirmationPage(_driver);

            //Act-->on admin home page
            loginPage.Login();
            adminPage.ClickOnBooking();

            //Assert-->on admin home page
            var pageTitle = _driver.Title;
            Console.WriteLine(pageTitle);
            Assert.IsTrue(pageTitle.Contains("ClubSpark / Admin / Booking"));

            //Act -->on booking page
            adminBookingPage.ClickOnBookingSheet();
           
            //Assert-->booking page
            var bookingPageTitle = _driver.Title;
            Console.WriteLine(bookingPageTitle);
            Assert.IsTrue(bookingPageTitle.Contains("Regression Test Venue / Booking / Book by date"));

            //Act -->on advancebooking page
            adminAdvancedBookingPage.ClicktoSelectNextDay();
            adminAdvancedBookingPage.clickOnATimeSlot();
            adminAdvancedBookingPage.ClickOnAdvancedOptions();
            //Assert-->advancebooking page
            var advancebookingPageTitle = _driver.Title;
            Console.WriteLine(advancebookingPageTitle);
            Assert.IsTrue(advancebookingPageTitle.Contains("Regression Test Venue / Booking / Advanced booking"));

            //Act 
            adminAdvancedBookingPage.ClickSumbit();
            string advancedBookingMessage = advancedBookingConfirmationMessage.ConfirmationText();
            //Assert --> Advanced booking message page
            Assert.AreEqual(advancedBookingMessage, "Your booking has been confirmed.","The names match");
        }
        [Ignore("ignore this test")]
        [TestCase]
        public void CreateACourse()
        {
            //Arrange
            var loginPage = new LoginPage(_driver);  // >>>>>>>Loginto Admnin portal 
            AdminNewCoursePage adminNewCourse = new AdminNewCoursePage(_driver);
            AdminCoachingNormalAdultPage normalAdult = new AdminCoachingNormalAdultPage(_driver);
            AdminAddCoursePage adminAddCourse = new AdminAddCoursePage(_driver);
            AdminCoachingNormalAdultTablePage courseUI = new AdminCoachingNormalAdultTablePage(_driver);

            // Act
            loginPage.Login();
            adminNewCourse.SelectCoaching();
            adminNewCourse.ClickViewCourse();
            adminNewCourse.ClickProgrammes();
            normalAdult.ClickAddNewCourse();
            normalAdult.SelectShortCourse();
           
           //Generate a course name --> this will be passed as name to create the new course 
           var courseName = "Automation "+RandomGenerator.RandomString(3, false);
            Console.WriteLine(courseName);
            string courseCreatedMessage = adminAddCourse.addNewCourse(courseName, "100");
            
           // Assert
            Assert.AreEqual(courseCreatedMessage, "COURSE SUCCESSFULLY CREATED", "The names match");

            // To go back to the active courses
            adminNewCourse.SelectCoaching();
            adminNewCourse.ClickViewCourse();
            adminNewCourse.ClickProgrammes();

            //Search the UI for the verifying the course 

            courseUI.SearchCourseUI(courseName);
            courseUI.ClickDirectLink();
            //Thread.Sleep(4000);
            //WaitForAjax();
            
            courseUI.SwitchToDirectLinkPage();

            string courseNameFromDirectLinkPage = courseUI.GetCourseNameFromDirectLinkPage();
            Assert.AreEqual(courseName, courseNameFromDirectLinkPage, "The names match");

        }

        [Ignore("ignore this test")]
        [TestCase("marry6067@gmail.com")]
        public void RefundACourseBooking(string emailid)
        {
            //----------------------> Step 1. Create a new course in admin >-----------------------------------
            //Arrange
            var loginPage = new LoginPage(_driver);  // >>>>>>>Loginto Admnin portal 
            AdminNewCoursePage adminNewCourse = new AdminNewCoursePage(_driver);
            AdminCoachingNormalAdultPage normalAdult = new AdminCoachingNormalAdultPage(_driver);
            AdminAddCoursePage adminAddCourse = new AdminAddCoursePage(_driver);
            AdminCoachingNormalAdultTablePage courseUI = new AdminCoachingNormalAdultTablePage(_driver);
            AdminLogOutPage adminLogout = new AdminLogOutPage(_driver);
            CreateNewMemberPage createNewMember = new CreateNewMemberPage(_driver);
            MemberHomePage memberHomePage = new MemberHomePage(_driver);
            MemberCoachingTabPage memberCoachingTabPage = new MemberCoachingTabPage(_driver);
            MemberBookingPage memberBookingPage = new MemberBookingPage(_driver);
            MemberCoachingBookingConfirmationPage bookingConfirmation = new MemberCoachingBookingConfirmationPage(_driver);
            MemberLogoutPage memberLogout = new MemberLogoutPage(_driver);
            AdminCoachingSearchCoursePage searchCourse = new AdminCoachingSearchCoursePage(_driver);
            AdminCoachingAttendeesListPage selectAttendee = new AdminCoachingAttendeesListPage(_driver);
            AdminCoachingIndividualAttendeePage selectAttendeeForRefund = new AdminCoachingIndividualAttendeePage(_driver);

            // Act
            loginPage.Login();
            adminNewCourse.SelectCoaching();
            adminNewCourse.ClickViewCourse();
            adminNewCourse.ClickProgrammes();
            normalAdult.ClickAddNewCourse();
            normalAdult.SelectShortCourse();

            //Generate a course name --> this will be passed as name to create the new course 
            var courseName = "Automation_1" + RandomGenerator.RandomString(3, false);
            Console.WriteLine(courseName);
            string courseCreatedMessage = adminAddCourse.addNewCourse(courseName, "100");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            // Assert
            Assert.AreEqual(courseCreatedMessage, "COURSE SUCCESSFULLY CREATED", "The names match");
            adminLogout.LogoutOfAdmin();
            

            // create a new user and join the course created above
            createNewMember.RegisterUser("Mary", "Lin", emailid, emailid);

            string newMember = createNewMember.getMemberText();
            Console.WriteLine("The new member created is :" + newMember);

            //Assert   --> Verify the new member created
            Assert.AreEqual(createNewMember.getMemberText(), "Mary Lin", "The names should match");

            //Act
            memberHomePage.SelectCoachingTab();
            memberCoachingTabPage.JoinACourse(courseName);
            memberBookingPage.SelectCourseBooking();           
            memberBookingPage.EnterStripeAccount();            
            string bookingConfirmText = bookingConfirmation.BookingConfirmationText();
            //Assert
            Assert.AreEqual(bookingConfirmText, "Thank you for booking", "The names should match");
            memberLogout.SignOut();

            //Act
            loginPage.Login();
            memberHomePage.SelectCoachingTab();
            adminNewCourse.ClickViewCourse();
            adminNewCourse.ClickProgrammes();
            searchCourse.SearchCourseForCancellation(courseName);
            selectAttendee.SelectAttendee();
            string emailIdFromRefund = selectAttendeeForRefund.ReadEmailID();
            Console.WriteLine(emailIdFromRefund);
            //Assert 
            Assert.AreEqual(emailIdFromRefund, emailid, "The names should match");

            // Act 
            selectAttendeeForRefund.ClickRefund();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            selectAttendeeForRefund.SelectConfirmCheckbox();
            selectAttendeeForRefund.ClickYes();            
            Thread.Sleep(10000);//--> this is used as a jquery call updates the payment status. Webdriver Implicit and explicit is not working 
            string status = selectAttendeeForRefund.RefundStatus();
            Console.WriteLine(status);
            Assert.AreEqual(status, "REFUNDED", "The names should match");

        }
        [Ignore("ignore this test")]
        [TestCase]
        public void StripeAccountTest()
        {                 
            var loginPage = new LoginPage(_driver);
            loginPage.Login();
            _driver.Navigate().GoToUrl("http://test.clubspark.uk/regressiontestvenue/Coaching/CourseConfirmation/b805d0eb-decf-42c6-a1c7-e79939d0e5e0?bid=eb5fc080-fe15-4695-bb20-950ffc5bca81&p=1");
            MemberBookingPage memberBookingPage = new MemberBookingPage(_driver);
            MemberCoachingBookingConfirmationPage bookingConfirmation = new MemberCoachingBookingConfirmationPage(_driver);
           
            //memberBookingPage.SelectCourseBooking();
           
           // _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            //memberBookingPage.EnterStripeAccount();
            string bookingConfirmText = bookingConfirmation.BookingConfirmationText();           
            Assert.AreEqual(bookingConfirmText, "Thank you for booking", "The names should match");

        }
        [Ignore("ignore this test")]
        [TestCase]
        public void TableSerachTest()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.Login();
            MemberHomePage memberHomePage = new MemberHomePage(_driver);
            AdminNewCoursePage adminNewCourse = new AdminNewCoursePage(_driver);
            AdminCoachingSearchCoursePage searchCourse = new AdminCoachingSearchCoursePage(_driver);
            AdminCoachingAttendeesListPage selectAttendee = new AdminCoachingAttendeesListPage(_driver);
            AdminCoachingIndividualAttendeePage selectAttendeeForRefund = new AdminCoachingIndividualAttendeePage(_driver);
            //AdminCoachingRefundPage refundStatus = new AdminCoachingRefundPage(_driver);
            AdminLogOutPage adminLogout = new AdminLogOutPage(_driver);
            memberHomePage.SelectCoachingTab();
            adminNewCourse.ClickViewCourse();
            adminNewCourse.ClickProgrammes();
            searchCourse.SearchCourseForCancellation("Automation_1KPC"); //Automation_1EHB
            selectAttendee.SelectAttendee();
            string emailId = selectAttendeeForRefund.ReadEmailID();
            Console.WriteLine(emailId);
            selectAttendeeForRefund.ClickRefund();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            selectAttendeeForRefund.SelectConfirmCheckbox();           
            selectAttendeeForRefund.ClickYes();
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Thread.Sleep(10000);
            string status = selectAttendeeForRefund.RefundStatus();
            Console.WriteLine(status);
            Assert.AreEqual(status, "REFUNDED", "The names should match");
            adminLogout.LogoutOfAdmin();            

        }

        [Ignore("ignore this test")]
        [TestCase]
        public void LoginToStripe()
        {
            StripeLogInPage logIn = new StripeLogInPage(_driver);
            StripePaymentRefundPage stripeRefund = new StripePaymentRefundPage(_driver);
            logIn.LogInToStripe("nathan.punzalan@clubspark.com", "Sp0rtlabs123");     

            stripeRefund.CLickOnRefunded();
            stripeRefund.SearchEmailId("marry6058@gmail.com");

            string refundStatus = stripeRefund.RefundStatus();
            Console.WriteLine(refundStatus);
            Assert.AreEqual(refundStatus, "Refunded", "The names should match");
        }


        //[Ignore("ignore this test")]
        [TestCase("jadu1123@gmail.com")]
        public void CreateAHolidayCampAndBookOnToIt(string emailid)
        {
            //Arrange
            var loginPage = new LoginPage(_driver);  // >>>>>>>Loginto Admnin portal 
            AdminNewCoursePage adminNewCourse = new AdminNewCoursePage(_driver);
            AdminHolidayCampPage adminHolidayCamp = new AdminHolidayCampPage(_driver);
            AdminAddCampPage adminNewCamp = new AdminAddCampPage(_driver);
            AdminLogOutPage adminLogout = new AdminLogOutPage(_driver);
            CreateNewMemberPage createNewMember = new CreateNewMemberPage(_driver);
            SelectHolidayCampPage selectHolidayCamp = new SelectHolidayCampPage(_driver);
            MemberHolidayCampPage memberHolidayCamp = new MemberHolidayCampPage(_driver);
            MemberHolidayCampDetailPage memberHolidayCampDetail = new MemberHolidayCampDetailPage(_driver);
            MemberHolidayCampBookingPage memberHolidayCampBooking = new MemberHolidayCampBookingPage(_driver);
            MemberBookingPage memberBookingPage = new MemberBookingPage(_driver);
            MemberHolidayCampBookingConfirmationPage memberBookingConfirmation = new MemberHolidayCampBookingConfirmationPage(_driver);

            // Act
            loginPage.Login();
            adminNewCourse.SelectCoaching();
            adminNewCourse.ClickHolidayCamps();

            //Assert-->on holiday camp page
            var holidayCampPageTitle = _driver.Title;
            Console.WriteLine(holidayCampPageTitle);
            Assert.IsTrue(holidayCampPageTitle.Contains("ClubSpark / Admin / Coaching / Holiday Camps"));

            // Act --> click add new camp
            adminHolidayCamp.ClickAddNewCamp();

            // Assert --> on add camp 
            var addCampPageTitle = _driver.Title;
            Console.WriteLine(addCampPageTitle);
            Assert.IsTrue(addCampPageTitle.Contains("ClubSpark / Admin / Coaching /Holiday Camps / Add camp"));

            //Generate a course name --> this will be passed as name to create the new course 
            var courseName = "Automation_HolidayCamp_" + RandomGenerator.RandomString(3, false);
            Console.WriteLine(courseName);
            string campCreatedMessage = adminNewCamp.addNewHolidayCamp(courseName,"30","60");
            Console.WriteLine(campCreatedMessage);

            // Assert
            Assert.AreEqual(campCreatedMessage, "CAMP SAVED", "The names match");
            adminLogout.LogoutOfAdmin();

            //Act
            createNewMember.RegisterUser("Jennifer", "Jane", emailid, emailid);

            string newMember = createNewMember.getMemberText();
            Console.WriteLine("The new member created is :" + newMember);
            selectHolidayCamp.ClickHolidayCamp();
            memberHolidayCamp.SelectHolidayCamp(courseName);
            memberHolidayCampDetail.ClickSession();
            memberHolidayCampDetail.ContinueToOrderSummary();
            memberHolidayCampBooking.EnterDetails();
            memberHolidayCampBooking.SelectMember();
            memberHolidayCampBooking.SelectTermsAndConditions();
            memberHolidayCampBooking.ClickPayNow();
            memberBookingPage.EnterStripeAccount();
            string bookingConfirmText = memberBookingConfirmation.BookingConfirmationText();
            Assert.AreEqual(bookingConfirmText, "Confirmed! Your Holiday camp is booked.", "The names should match");
        }

        [TestCase("janeetz6554zffz123@gmail.com")]
        public void CreateMember(string emailid)
        {
            CreateNewMemberPage createNewMember = new CreateNewMemberPage(_driver);
            SelectHolidayCampPage selectHolidayCamp = new SelectHolidayCampPage(_driver);
            MemberHolidayCampPage memberHolidayCamp = new MemberHolidayCampPage(_driver);
            MemberHolidayCampDetailPage memberHolidayCampDetail = new MemberHolidayCampDetailPage(_driver);
            MemberHolidayCampBookingPage memberHolidayCampBooking = new MemberHolidayCampBookingPage(_driver);
            MemberBookingPage memberBookingPage = new MemberBookingPage(_driver);
            MemberHolidayCampBookingConfirmationPage memberBookingConfirmation = new MemberHolidayCampBookingConfirmationPage(_driver);
            // create a new user and join the course created above
            createNewMember.RegisterUser("Jennifer", "Jane", emailid, emailid);

            string newMember = createNewMember.getMemberText();
            Console.WriteLine("The new member created is :" + newMember);
            selectHolidayCamp.ClickHolidayCamp();
            memberHolidayCamp.SelectHolidayCamp("Automation_HolidayCamp_OVN");
            memberHolidayCampDetail.ClickSession();
            memberHolidayCampDetail.ContinueToOrderSummary();
            memberHolidayCampBooking.EnterDetails();
            memberHolidayCampBooking.SelectMember();
            memberHolidayCampBooking.SelectTermsAndConditions();
            memberHolidayCampBooking.ClickPayNow();
            memberBookingPage.EnterStripeAccount();
            string bookingConfirmText = memberBookingConfirmation.BookingConfirmationText();
            Assert.AreEqual(bookingConfirmText, "Confirmed! Your Holiday camp is booked.", "The names should match");
        }

        [TestCase]
        public void Createaneventandmakeabooking()
        {
            //Arrange
            var loginPage = new LoginPage(_driver);  // >>>>>>>Loginto Admnin portal 
            AdminEventsPage adminEvents = new AdminEventsPage(_driver);
            // Act
            loginPage.Login();
            adminEvents.SelectEvents();
            adminEvents.SelectCreateNew();
            adminEvents.SelectEventToHost();

        }





        [TearDown]        
         public void CleanUp()
         {
         // _driver.Quit();
         }            

        }
}
