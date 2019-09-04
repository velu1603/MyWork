using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public.MemberCoachingTab
{
    public class MemberJoiningPage : Base
    {
        public MemberJoiningPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public readonly By _bookYourPlace = By.XPath("//a[contains(text(),'Book your place')]");
        

        public void ClickBookYourPlace()
        {
            var element = driver.FindElement(_bookYourPlace);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }



    }
}

            


