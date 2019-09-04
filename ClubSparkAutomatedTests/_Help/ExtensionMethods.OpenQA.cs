using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;

namespace ClubSparkAutomatedTests._Help
{
    public static class ExtensionMethods2
    {
        public static IWebElement WaitForElement(this IWebDriver driver, By selector,
            String message = "Error finding element", Int32 timeout = 30000)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until((d) => { return driver.FindElements(selector).Any(); });
            return driver.AssertElement(selector, message);
        }

        public static IEnumerable<IWebElement> WaitForElements(this IWebDriver driver, By selector,
            String message = "Error finding element", Int32 timeout = 30000, Int32 minResults = 1,
            Int32 maxResults = Int32.MaxValue)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until((d) => { return driver.FindElements(selector).Any(); });
            return driver.AssertElements(selector, message, minResults, maxResults);
        }

        public static IWebElement AssertElement(this IWebDriver driver, By selector,
            String message = "Error finding element")
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(selector);
            Assert.IsTrue(elements.Count == 1, message);
            Console.WriteLine("[{0}] Find '{2}': {1}x", driver.Url, elements.Count, selector);
            return elements.SingleOrDefault();
        }

        public static IEnumerable<IWebElement> AssertElements(this IWebDriver driver, By selector,
            String message = "Error finding elements", Int32 minResults = 1, Int32 maxResults = Int32.MaxValue)
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(selector);
            Assert.IsTrue(elements.Count >= minResults, message);
            Assert.IsTrue(elements.Count <= maxResults, message);
            Console.WriteLine("[{0}] Find '{2}': {1}x", driver.Url, elements.Count, selector);
            return elements.Select<IWebElement, IWebElement>(e => e).ToArray();
        }
    }
}