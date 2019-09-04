using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.WebDriver.Extensions.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using Sizzle = Selenium.WebDriver.Extensions.Sizzle.SizzleSelector;

namespace ClubSparkAutomatedTests._Help
{
    public static class ExtensionMethods
    {
        //private static Dictionary<String, Uri> _environmentMap = new Dictionary<String, Uri>(StringComparer.InvariantCultureIgnoreCase)
        //{
        //    { "DEV", new Uri("http://ta.dev.clubspark.co/") },
        //    { "TEST", new Uri("http://ta.test.clubspark.co/") },
        //    { "STAGE", new Uri("http://ta.stage.clubspark.co/") },
        //    { "PREPROD", new Uri("http://ta.preprod.clubspark.co/") },
        //    { "PROD", new Uri("https://bookacourt.tennis.com.au/") },
        //};

        //private static Uri _baseURL = _environmentMap[SeleniumContext.ENVIRONMENT];

        //public static void GoToRelativeUrl(this IWebDriver driver, String relativeUrl, params String[] args)
        //{
        //    String absoluteUrl = new Uri(ExtensionMethods._baseURL, String.Format(relativeUrl, args)).AbsoluteUri;
        //    Console.WriteLine("[{0}] Navigate", absoluteUrl);
        //    driver.Navigate().GoToUrl(absoluteUrl);
        //    Assert.IsFalse(driver.Url.Contains("Error?aspxerrorpath"), String.Format("Error loading URL {0}", absoluteUrl));
        //    var headings = driver.FindElements(new Sizzle("body span h1"));
        //    if (headings.Count == 1)
        //    {
        //        Assert.IsFalse(headings.First().Text == @"Server Error in '/' Application.", String.Format("Error loading URL {0}", absoluteUrl));
        //    }
        //}

        public static IWebElement WaitForElement(this IWebDriver driver, String selector, String message = "Error finding element", Int32 timeout = 30000)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until((d) => { return driver.FindElements(new Sizzle(selector)).Any(); });
            return driver.AssertElement(selector, message);
        }

        public static IEnumerable<IWebElement> WaitForElements(this IWebDriver driver, String selector, String message = "Error finding element", Int32 timeout = 30000, Int32 minResults = 1, Int32 maxResults = Int32.MaxValue)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until((d) => { return driver.FindElements(new Sizzle(selector)).Any(); });
            return driver.AssertElements(selector, message, minResults, maxResults);
        }

        public static IWebElement AssertElement(this IWebDriver driver, String selector, String message = "Error finding element")
        {
            ReadOnlyCollection<WebElement> elements = driver.FindElements(new Sizzle(selector));
            Assert.IsTrue(elements.Count == 1, message);
            Console.WriteLine("[{0}] Find '{2}': {1}x", driver.Url, elements.Count, selector);
            return elements.SingleOrDefault();
        }

        public static IEnumerable<IWebElement> AssertElements(this IWebDriver driver, String selector, String message = "Error finding elements", Int32 minResults = 1, Int32 maxResults = Int32.MaxValue)
        {
            ReadOnlyCollection<WebElement> elements = driver.FindElements(new Sizzle(selector));
            Assert.IsTrue(elements.Count >= minResults, message);
            Assert.IsTrue(elements.Count <= maxResults, message);
            Console.WriteLine("[{0}] Find '{2}': {1}x", driver.Url, elements.Count, selector);
            return elements.Select<IWebElement, IWebElement>(e => e).ToArray();
        }
    }
}
