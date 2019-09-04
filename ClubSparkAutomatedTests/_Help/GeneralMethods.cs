using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests._Help
{
    public static class GeneralMethods
    {
        public static By DataLocator(string elementName)
        {
            return By.XPath("*['data-locator='" + elementName + "]");
        }

        public static void WaitForAjax(IWebDriver driver, string waitForElement)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(Driver => (bool)((IJavaScriptExecutor)Driver).ExecuteScript("return jQuery.active == 0"));
            {

            }
        }

        public static void SelectByListValue(IWebDriver driver, string elementName, string value)
        {
            var listBox = new SelectElement(driver.FindElement(By.Id(elementName)));
            listBox.SelectByValue(value);


        }

        internal static void SelectByListValue(IWebDriver driver, By propertySubType1, string propertySubType2)
        {
            throw new NotImplementedException();
        }

        internal static void ClickLinkByHref(IWebDriver driver, string href)
        {
            IReadOnlyCollection<IWebElement> anchors = driver.FindElements(By.TagName("a"));
            foreach (var anchor in anchors)
            {
                if (anchor.GetAttribute("href").Contains(href))
                {
                    anchor.Click();
                    break;
                }
            }
        }

        public static IWebElement WaitForElement(IWebDriver driver,By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(30000));
            wait.Until((d) =>
            {
                return driver.FindElements(by).Any(); 

            });
            return driver.FindElement(by);
        }

        
    }
}
