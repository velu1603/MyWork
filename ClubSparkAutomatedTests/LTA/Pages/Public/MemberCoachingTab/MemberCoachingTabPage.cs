using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public.MemberCoachingTab
{
    public class MemberCoachingTabPage : Base
    {
        public MemberCoachingTabPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        

        public readonly By _moreResult = By.XPath("//a[contains(text(),'More results')]");


        public void JoinACourse(string course)
        {
            MemberJoiningPage memberJoiningPage = new MemberJoiningPage(driver);
            
            
            string xpath = "//a[contains(text(),'" + course + "')]";
            var element = driver.FindElement(By.XPath(xpath));            
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            memberJoiningPage.ClickBookYourPlace();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
        }

    }
}
