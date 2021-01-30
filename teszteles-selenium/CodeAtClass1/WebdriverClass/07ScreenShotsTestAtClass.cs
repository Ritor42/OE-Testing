using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebdriverClass
{
    class ScreenShotsTestAtClass : TestBase
    {
        [Test]
        public void ScreenShots()
        {
            Driver.Navigate().GoToUrl("http://www.elvira.hu");

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string screenshotName = baseDirectory + TestContext.CurrentContext.Test.Name + "_" +
                DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + "_error.png";

            //Maximize browser window
            Driver.Manage().Window.Maximize();
            //Create a screenshot and save the file as screenshot.png
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotName, ScreenshotImageFormat.Png);
            Assert.IsTrue(File.Exists(screenshotName));
        }
    }
}
