using ClubSparkAutomatedTests._Help;
using ClubSparkAutomatedTests.LTA.Pages;
using ClubSparkAutomatedTests.LTA.Pages.Admin;
using ClubSparkAutomatedTests.LTA.Pages.Admin.Admin_Events;
using ClubSparkAutomatedTests.LTA.Pages.Admin.AdminHolidayCamp;
using ClubSparkAutomatedTests.LTA.Pages.Public;
using ClubSparkAutomatedTests.LTA.Pages.Public.Member_Holiday_Camp;
using ClubSparkAutomatedTests.LTA.Pages.Public.MemberCoachingTab;
using ClubSparkAutomatedTests.LTA.Pages.Public.MemberEventsBooking;
using ClubSparkAutomatedTests.LTA.Pages.Stripe;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Tests
{
    [TestFixture]
    public class UnitTest
    {
        private IWebDriver _driver;

       

        [SetUp]
        public void Initialization()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["LTA_AdminURL"]);

        }

        [TestCase]
        public void CreateAnEventAndMakeABooking()
        {
            
            //Arrange
            var loginPage = new LoginPage(_driver);  // >>>>>>>Loginto Admnin portal 
            AdminEventsPage adminEvents = new AdminEventsPage(_driver);
            AdminEventsActivitiesPage addActivities = new AdminEventsActivitiesPage(_driver);
            AdminLogOutPage adminLogout = new AdminLogOutPage(_driver);
            CreateNewMemberPage createNewMember = new CreateNewMemberPage(_driver);
            MemberEventsBookingPage memberEventsBooking = new MemberEventsBookingPage(_driver);
            NewEventDetailsForTennisFestival newEventDetails = new NewEventDetailsForTennisFestival(_driver);
            MemberBookingPage memberBookingPage = new MemberBookingPage(_driver);
            /*
            loginPage.Login();
            adminEvents.SelectEvents();
            adminEvents.SelectCreateNew();
            adminEvents.SelectEventToHost();

            newEventDetails.SelectTheme();

            newEventDetails.SelectDate();
            newEventDetails.StartTime();
            newEventDetails.EndTime();

            string competitionName = "Competition Name_" + RandomGenerator.RandomString(4, false);
            newEventDetails.CompetitionName(competitionName);

            newEventDetails.CheckTakeOnlinePayment();
            newEventDetails.EnterInroduction("Introducing while running the automation script");
            newEventDetails.EnterCompetitionDetails("Competition running the automation script");
            newEventDetails.ContactEmail("contact@contact.com");
            newEventDetails.ContactPhoneNumber("02073717700");
            newEventDetails.SaveEvent();
            adminEvents.ClickActivities();
            adminEvents.ClickAddActivity();
            addActivities.SelectBallType();
            addActivities.EventName(competitionName);            
            addActivities.SelectGender();
            addActivities.EntryFeePerPlayer("30");
            addActivities.StartTime();
            addActivities.EndTime();
            addActivities.Description("This is while running the automation script " + competitionName);
            addActivities.SaveActivity();
            string getEventName = addActivities.getEventName(competitionName);
            // Assert that the event has been created
            Assert.AreEqual(competitionName, getEventName, "The names should match");

            adminEvents.ClickPublishEventToWebsite();
            Assert.IsTrue(adminEvents.CheckViewEventOnline());
            adminEvents.GoToHome();
            adminLogout.LogoutOfAdmin(); // Logout of Admin 
            var id = SQLHelperMethods.GetIdFromDb(competitionName);
            Console.WriteLine("id returned :"+id);
            */

           // string emailid = GenerateEmailId.GenerateRandomEmailId();

            /*
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["LTA_MemberURL"]);
            _driver.FindElement(By.CssSelector("#account-options > ul > li:nth-child(1) > span.sign-in > a")).Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.FindElement(By.XPath("//*[@id='EmailAddress']")).SendKeys("autoYGBO946@gmail.com");
            _driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("clubspark");
            _driver.FindElement(By.Id("signin-btn")).Click();

            memberEventsBooking.ClickEvents();
            memberEventsBooking.SelectTennisFestival();

            string eventName = "Competition Name_OZCJ";
            string getEventNameForBooking = addActivities.getEventName(eventName);
            //getEventNameForBooking

            // Assert that the events are the sane for booking
            Assert.AreEqual(getEventNameForBooking, eventName, "The names should match");

            memberEventsBooking.Book();
            memberEventsBooking.ClickBasket();
            memberEventsBooking.BookNow();
            memberEventsBooking.SelectMember();
            memberEventsBooking.ClickConfirm();
            memberEventsBooking.ClickTermsAndConditions();
            memberEventsBooking.ConfirmAndPayNow();
            memberBookingPage.EnterStripeAccount();
            */
            var id = SQLHelperMethods.GetIdFromDb("A2Z");
            Console.WriteLine("id returned :"+id);
            SQLHelperMethods.DeleteIdFromDb(id);
            
        }

        //[Ignore("ignore this test")]
        [TestCase] 
        public void CreateAHolidayCampAndBookOnToIt()
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
            string campCreatedMessage = adminNewCamp.addNewHolidayCamp(courseName, "30", "60");
            Console.WriteLine(campCreatedMessage);

            // Assert
            Assert.AreEqual(campCreatedMessage, "CAMP SAVED", "The names match");
            adminLogout.LogoutOfAdmin();

            // Below to generate random email      
            string emailid = GenerateEmailId.GenerateRandomEmailId();
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

        [TestCase]
        public void RefundACourseBooking()
        {
            //Arrange
            var loginPage = new LoginPage(_driver);  // >>>>>>>Login to Admnin portal 
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

            // Below to generate random email      
            string emailid = GenerateEmailId.GenerateRandomEmailId();

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

            //Assert 
            Assert.AreEqual(refundStatus, "Refunded", "The names should match");
        }


        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }

        



    }
}
