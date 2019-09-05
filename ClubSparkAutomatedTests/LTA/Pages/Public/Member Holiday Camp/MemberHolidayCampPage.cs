using ClubSparkAutomatedTests._Help;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests.LTA.Pages.Public.Member_Holiday_Camp
{
    class MemberHolidayCampPage : Base
    {
        public MemberHolidayCampPage(IWebDriver driver) { this.driver = driver; }

        


        public void SelectHolidayCamp(string holidayCampCourseName)
        {      
            
            string xpath = "//div[@class='description']/h2[contains(.,'"+ holidayCampCourseName +"')]";
            IWebElement holidayCampElement = driver.FindElement(By.XPath(xpath));
            
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", holidayCampElement);
            holidayCampElement.Click();
        }


    }
}

