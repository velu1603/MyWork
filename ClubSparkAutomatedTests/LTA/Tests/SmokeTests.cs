using ClubSparkAutomatedTests._Help;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using ClubSparkAutomatedTests.LTA.Pages.Admin;
using ClubSparkAutomatedTests.LTA.Pages.Admin.AdminBooking;
using ClubSparkAutomatedTests.LTA.Pages.Public.PublicBooking;
using ClubSparkAutomatedTests.LTA.Pages.Public;
using OpenQA.Selenium.Remote;
using System.Threading;
using ClubSparkAutomatedTests.LTA.Pages;
using ClubSparkAutomatedTests.LTA.Pages.Public.MemberCoachingTab;
using ClubSparkAutomatedTests.LTA.Pages.Stripe;

namespace ClubSparkAutomatedTests.LTA.Tests
{
    [TestFixture]
    public class SmokeTests 
    {
        private IWebDriver _driver;

        [SetUp]
        public void Initialization()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
           _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["LTA_AdminURL"]);
           
        }

        
        //[Ignore("ignore this test")]
        [TestCase]
        public void ValidateSigningInToAdminPortalTest()
        {
            //Arrange
            var loginPage = new LoginPage(_driver);
            //Action
            loginPage.Login();
            var pageTitle =_driver.Title;
            //Assert
            try
            {
                Assert.IsTrue(pageTitle.Contains("ClubSpark / Admin / Home"));
                TestRailMethods.AddResultForTestCase("182", 1,ConfigurationManager.AppSettings["PassedComment"]); //Test Case Passed status =1

            }
            catch (Exception e)
            {
               var failedEMessage = "PageTitle"+Environment.NewLine+e.Message;
               TestRailMethods.AddResultForTestCase("182", 5, failedEMessage); //Test Case Failed status =5

            }

        }
        //[Ignore("ignore this test")]
        [TestCase("Individual", "Adult",1,7)]
        //[TestCase("Group", "Family", 1, 7)]
        public void ValidateCreateMemberShipPackageTest(string membershipType, string membershipCategoryType, int directDebitInstallmentDate, int paymentReminder)
        {
            //Arrange
            var loginPage = new LoginPage(_driver);
            var membershipPage = new MembershipPage(_driver);
            //Act
            loginPage.Login();
            membershipPage.CreateMembershipPackage(membershipType,membershipCategoryType,directDebitInstallmentDate,paymentReminder);
            var pageTitle = _driver.Title;
            //Assert
            try
            {
                Assert.IsTrue(pageTitle.Contains("ClubSpark / Admin / Membership package confirmation"));
                TestRailMethods.AddResultForTestCase("183", 1,
                    ConfigurationManager.AppSettings["PassedComment"]); //Test Case Passed status =1

            }
            catch (Exception e)
            {
                var failedEMessage = "PageTitle" + Environment.NewLine + e.Message;
                TestRailMethods.AddResultForTestCase("183", 5, failedEMessage); //Test Case Failed status =5

            }
        }

        //[Ignore("ignore this test")]
        [TestCase()]
        public void ValidateCreateBookingScheduleTest()
        {
            //Arrange
            var loginPage = new LoginPage(_driver);
            var bookingHomePage = new AdminBookingHomePage(_driver);

            //Act
            loginPage.Login();
            bookingHomePage.BookingSchedule();

            //Assert
            try
            {
                TestRailMethods.AddResultForTestCase("185", 1,
                    ConfigurationManager.AppSettings["PassedComment"]); //Test Case Passed status =1

            }
            catch (Exception e)
            {
                var failedEMessage = Environment.NewLine + e.Message;
                TestRailMethods.AddResultForTestCase("185", 5, failedEMessage); //Test Case Failed status =5

            }
        }


        //[Ignore("ignore this test")]
        [TestCase("Test1","Court1", "1PositiveTestCase:ConfirmedBooking")]
        [TestCase("Test2","Court1", "2NegativeTestCase:DuplicateBooking")]

        public void ValidateCreateBookingForMemberByAdminTest(string testNumber,string courtNumber, string testScenarioType)
        {

            //Arrange
            
            var loginPage = new LoginPage(_driver);
            var publicBookingHomePage = new PublicBookingHomePage(_driver);


            //Act
            loginPage.Login();
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["LTA_MemberURL"]+"/booking/edit");
            publicBookingHomePage.CreateBookingByAdmin("Court1",testScenarioType);

            //Assert
            if (testNumber.Equals("Test1"))
            {
                try
                {
                    TestRailMethods.AddResultForTestCase("12962", 1,
                    ConfigurationManager.AppSettings["PassedComment"]); //Test Case Passed status =1

                }
                catch (Exception e)
                {
                    var failedEMessage = Environment.NewLine + e.Message;
                    TestRailMethods.AddResultForTestCase("12962", 5, failedEMessage); //Test Case Failed status =5
                }
            }
            else if(testNumber.Equals("Test2"))
            {
                try
                {
                    TestRailMethods.AddResultForTestCase("12963", 1,
                    ConfigurationManager.AppSettings["PassedComment"]); //Test Case Passed status =1

                }
                catch (Exception e)
                {
                    var failedEMessage = Environment.NewLine + e.Message;
                    TestRailMethods.AddResultForTestCase("12963", 5, failedEMessage); //Test Case Failed status =5
                }
            }
            //var memberHomePage = new MemberHomePage(_driver);
            //memberHomePage.SelectBookingTab();

            //var bookingHomePage =  new PublicBookingHomePage(_driver);
            // bookingHomePage.BookIntervalFromNotBooked(courtNumber);

        }

        //[TestCase()]
        //public void ValidateSetupAGatedAccessVenueTest()
        //{
        //    //Arrange

        //    var loginPage = new LoginPage(_driver);
        //    var featuresPage = new FeaturesPage(_driver);


        //    //Act
        //    loginPage.Login();
        //    featuresPage.SetupGatedAccess();
        //}

        [Ignore("ignore this test")]
        [TestCase]
        public void GenerateAnAutoPaymentForFixedDateMembershipPackage()
        {
            //Arrange 

            var loginPage = new LoginPage(_driver);           
            FixedMembershipDataPackagesByAdminPage fixedMembershipPackage = new FixedMembershipDataPackagesByAdminPage(_driver);
            FixedMemberShipConfirmationPage fixedMemberShipConfirmationPage = new FixedMemberShipConfirmationPage(_driver);
            
            var newUser = new NewMemberCreationPage(_driver);
            var newUserActions = new MemberLoggedInPage(_driver);
            var joinNow = new JoinNowPage(_driver);

            NewMemberDetailsAfterjoiningFixedMemberShipPackage memberPackageDetails = new NewMemberDetailsAfterjoiningFixedMemberShipPackage(_driver);
            MemberSetUpGoCardlessDirectDebit memberSetUpDirectDebit = new MemberSetUpGoCardlessDirectDebit(_driver);
            FixedMembershipDataPackagesByAdminPage fixedMembershipPackageAdmin = new FixedMembershipDataPackagesByAdminPage(_driver);
            FixedMembershipDuplicatePackagePage duplicatePage = new FixedMembershipDuplicatePackagePage(_driver);
            AdminLogOutPage adminLogout = new AdminLogOutPage(_driver);

            //Act
            loginPage.Login();
            fixedMembershipPackage.ClickMembership();
            var newMembershipPackage = fixedMemberShipConfirmationPage.TextOfNewlyCreatedPakage();
            Console.WriteLine("The new package is :"+ newMembershipPackage);           
            adminLogout.LogoutOfAdmin();


            newUser.RegisterUser();  // ------> register a new user 

            string newMember = newUser.getMemberText();
            Console.WriteLine("The new member created is :"+ newMember);

            //Assert   --> Verify the new member created
            Assert.AreEqual(newUser.getMemberText(), "John Abraham", "The names should match");

            //Act 
            newUserActions.clickOnMembership();
            //Assert
            Assert.AreEqual(newUserActions.joinNow(), "Join Now!!");

            //Act   --> Select the new fixed membership package
            /************On new member page*************/
            string memberPackageJoined = joinNow.JoinFixedMershipPackage(newMembershipPackage);
            // Assert
            Assert.AreEqual(newMembershipPackage, memberPackageJoined);
            //Act   -- click to go to the next page
            joinNow.clickNext();
            

            //Act --> after next (from the previous step) enter manadatory details like address,town , select the terms and conditions and click next
            memberPackageDetails.Address1("41-47 Hartfield Road");
            memberPackageDetails.Town("London");
            memberPackageDetails.ClickTermsAndConditions();
            memberPackageDetails.ClickNext();
            memberPackageDetails.clickContinue();

            // Act --> Create the setUp for gocardless account             
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

            memberSetUpDirectDebit.SignOut();  //--> The new member will be sign out, after he/she has selected the fixed membership package
            
            loginPage.Login();  //--> Loginto Admnin portal 

            fixedMembershipPackageAdmin.GoToFixedDataPackage();
            fixedMembershipPackageAdmin.DuplicateMemberPackage(newMembershipPackage);  //--->pass the newly created memberpackage in the test 
            duplicatePage.clickEditPackage();
            duplicatePage.selectAvailability();
            duplicatePage.SavePackage();
            Assert.AreEqual(duplicatePage.Availability(), "Anyone (public)", "The names match");
            duplicatePage.NavigateToDuplicatedMembershipPackage();

            duplicatePage.SelectMemberUsingCheckbox();
            duplicatePage.SelectDropDownForPayment();
            Thread.Sleep(4000);
            duplicatePage.SelectAutoPayment();
            Thread.Sleep(4000);
            duplicatePage.SelectMoreColumns();
            duplicatePage.CheckAutopayment();
            string statusOfMember = duplicatePage.GetStatus();
            Assert.AreEqual(statusOfMember, "Pending", "The names match");
        }
        //[Ignore("ignore this test")]
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
            Assert.AreEqual(advancedBookingMessage, "Your booking has been confirmed.", "The names match");
        }

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
            var courseName = "Automation_ " + RandomGenerator.RandomString(3, false);
            Console.WriteLine(courseName);
            string courseCreatedMessage = adminAddCourse.addNewCourse(courseName, "100");

            // Assert
            Assert.AreEqual(courseCreatedMessage, "COURSE SUCCESSFULLY CREATED", "The names match");

            // Go back to the active courses
            adminNewCourse.SelectCoaching();
            adminNewCourse.ClickViewCourse();
            adminNewCourse.ClickProgrammes();

            //Search the UI for the verifying that the course is present
            courseUI.SearchCourseUI(courseName);
            //Click the course direct link 
            courseUI.ClickDirectLink();            
            //Switch to the new tab when the course direct link has launched
            courseUI.SwitchToDirectLinkPage();

            // Assert that the course name on the direct link matches with the name that was used to create the course. 
            string courseNameFromDirectLinkPage = courseUI.GetCourseNameFromDirectLinkPage();
            Assert.AreEqual(courseName, courseNameFromDirectLinkPage, "The names match");

        }

        // [Ignore("ignore this test")]
        [TestCase("marry6072@gmail.com")]
        public void RefundACourseBooking(string emailid)
        {
            
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
            // stripe details 
            StripeLogInPage logIn = new StripeLogInPage(_driver);
            StripePaymentRefundPage stripeRefund = new StripePaymentRefundPage(_driver);


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
            // Sign into admin account and search for the course enrolled by the member as above
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
            //  Start the refunding process
            selectAttendeeForRefund.ClickRefund();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            selectAttendeeForRefund.SelectConfirmCheckbox();
            selectAttendeeForRefund.ClickYes();
            Thread.Sleep(10000);//--> this is used as a jquery call updates the payment status. Webdriver Implicit and explicit is not working 
            string status = selectAttendeeForRefund.RefundStatus();
            Console.WriteLine(status);
            Assert.AreEqual(status, "REFUNDED", "The names should match");
            adminLogout.LogoutOfAdmin();

            // Act 
            // Verify in stripe for refund
            logIn.LogInToStripe("nathan.punzalan@clubspark.com", "Sp0rtlabs123");
            stripeRefund.CLickOnRefunded();
            stripeRefund.SearchEmailId(emailid);
            string refundStatus = stripeRefund.RefundStatus();
            Console.WriteLine(refundStatus);
            Assert.AreEqual(refundStatus, "Refunded", "The names should match");
        }

        public void CreateAHolidayCampAndBookOnToIt()
        {
            //1
            //Arrange
            var loginPage = new LoginPage(_driver);  // >>>>>>>Loginto Admnin portal 
            AdminNewCoursePage adminNewCourse = new AdminNewCoursePage(_driver);




            // Act
            loginPage.Login();
            adminNewCourse.SelectCoaching();


        }



        [TearDown]
        public void CleanUp()
        {
         _driver.Quit();
        }

        static void Main(string[] args)
        {
        }
    }
}
