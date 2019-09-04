using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests._Help
{
    public class JSWaiter
    {

        //private static Selenium.WebDriver jsWaitDriver;

        //private static WebDriverWait jsWait;

        //private static JavascriptExecutor jsExec;

        //// Get the driver 
        //public static void setDriver(IWebDriver driver)
        //{
        //    jsWaitDriver = driver;
        //    jsWait = new WebDriverWait(jsWaitDriver, TimeSpan.FromMilliseconds(30000));
        //    jsExec = ((IJavaScriptExecutor)(jsWaitDriver));
        //}

        //private void ajaxComplete()
        //{
        //    jsExec.executeScript(("var callback = arguments[arguments.length - 1];" + ("var xhr = new XMLHttpRequest();" + ("xhr.open(\'GET\', \'/Ajax_call\', true);" + ("xhr.onreadystatechange = function() {" + ("  if (xhr.readyState == 4) {" + ("    callback(xhr.responseText);" + ("  }" + ("};" + "xhr.send();")))))))));
        //}

        //private void waitForJQueryLoad()
        //{
        //    try
        //    {
        //        ExpectedCondition<Boolean> jQueryLoad;
        //        (((Long)(((JavascriptExecutor)(this.driver)).executeScript("return jQuery.active"))) == 0);
        //        bool jqueryReady = ((Boolean)(jsExec.executeScript("return jQuery.active==0")));
        //        if (!jqueryReady)
        //        {
        //            jsWait.Until(jQueryLoad);
        //        }

        //    }
        //    catch (WebDriverException ignored)
        //    {

        //    }

        //}

        //private void waitForAngularLoad()
        //{
        //    String angularReadyScript = "return angular.element(document).injector().get(\'$http\').pendingRequests.length === 0";
        //    this.angularLoads(angularReadyScript);
        //}

        //private void waitUntilJSReady()
        //{
        //    try
        //    {
        //        ExpectedCondition<Boolean> jsLoad;
        //        ((JavascriptExecutor)(this.driver)).executeScript("return document.readyState").toString().equals("complete");
        //        bool jsReady = jsExec.executeScript("return document.readyState").toString().equals("complete");
        //        if (!jsReady)
        //        {
        //            jsWait.until(jsLoad);
        //        }

        //    }
        //    catch (WebDriverException ignored)
        //    {

        //    }

        //}

        //private void waitUntilJQueryReady()
        //{
        //    Boolean jQueryDefined = ((Boolean)(jsExec.executeScript("return typeof jQuery != \'undefined\'")));
        //    if (jQueryDefined)
        //    {
        //        this.poll(20);
        //        this.waitForJQueryLoad();
        //        this.poll(20);
        //    }

        //}

        //public void waitUntilAngularReady()
        //{
        //    try
        //    {
        //        Boolean angularUnDefined = ((Boolean)(jsExec.executeScript("return window.angular === undefined")));
        //        if (!angularUnDefined)
        //        {
        //            Boolean angularInjectorUnDefined = ((Boolean)(jsExec.executeScript("return angular.element(document).injector() === undefined")));
        //            if (!angularInjectorUnDefined)
        //            {
        //                this.poll(20);
        //                this.waitForAngularLoad();
        //                this.poll(20);
        //            }

        //        }

        //    }
        //    catch (WebDriverException ignored)
        //    {

        //    }

        //}

        //public void waitUntilAngular5Ready()
        //{
        //    try
        //    {
        //        Object angular5Check = jsExec.executeScript("return getAllAngularRootElements()[0].attributes[\'ng-version\']");
        //        if ((angular5Check != null))
        //        {
        //            Boolean angularPageLoaded = ((Boolean)(jsExec.executeScript("return window.getAllAngularTestabilities().findIndex(x=>!x.isStable()) === -1")));
        //            if (!angularPageLoaded)
        //            {
        //                this.poll(20);
        //                this.waitForAngular5Load();
        //                this.poll(20);
        //            }

        //        }

        //    }
        //    catch (WebDriverException ignored)
        //    {

        //    }

        //}

        //private void waitForAngular5Load()
        //{
        //    String angularReadyScript = "return window.getAllAngularTestabilities().findIndex(x=>!x.isStable()) === -1";
        //    this.angularLoads(angularReadyScript);
        //}

        //private void angularLoads(String angularReadyScript)
        //{
        //    try
        //    {
        //        ExpectedCondition<Boolean> angularLoad;
        //        Boolean.valueOf(((JavascriptExecutor)(driver)).executeScript(angularReadyScript).toString());
        //        bool angularReady = Boolean.valueOf(jsExec.executeScript(angularReadyScript).toString());
        //        if (!angularReady)
        //        {
        //            jsWait.until(angularLoad);
        //        }

        //    }
        //    catch (WebDriverException ignored)
        //    {

        //    }

        //}

        //public void waitAllRequest()
        //{
        //    this.waitUntilJSReady();
        //    this.ajaxComplete();
        //    this.waitUntilJQueryReady();
        //    this.waitUntilAngularReady();
        //    this.waitUntilAngular5Ready();
        //}

        //public void waitForElementAreComplete(By by, int expected)
        //{
        //    ExpectedCondition<Boolean> angularLoad;
        //    int loadingElements = this.driver.findElements(by).size();
        //    return (loadingElements >= expected);

        //    jsWait.until(angularLoad);
        //}

        //public void waitForAnimationToComplete(String css)
        //{
        //    ExpectedCondition<Boolean> angularLoad;
        //    int loadingElements = this.driver.findElements(By.cssSelector(css)).size();
        //    return (loadingElements == 0);

        //    jsWait.until(angularLoad);
        //}

        //private void poll(long milis)
        //{
        //    try
        //    {
        //        Thread.sleep(milis);
        //    }
        //    catch (InterruptedException e)
        //    {
        //        e.printStackTrace();
        //    }

        //}
    }
}

