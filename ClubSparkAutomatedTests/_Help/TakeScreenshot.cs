using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests._Help
{
    public class TakeScreenshot
    {
            public void GetScreenshot(IWebDriver driver, string StepName)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var screenshotLocation = ConfigurationManager.AppSettings[""];
                var imageName = screenshotLocation + "_" + StepName + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";
                screenshot.SaveAsFile(imageName, ScreenshotImageFormat.Png);
            }

    }
}
