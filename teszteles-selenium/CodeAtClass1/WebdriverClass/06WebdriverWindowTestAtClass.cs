using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace WebdriverClass
{
    class WebdriverWindowTestAtClass : TestBase
    {
        [Test]
        public void ResponsiveWindow()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Navigate().GoToUrl("http://www.expedia.com/");
            //Maximize browser window
            Driver.Manage().Window.Maximize();
            wait.Until(driver => Driver.FindElement(By.CssSelector("a[id='listYourProperty']")));
            Assert.IsTrue(Driver.FindElement(By.CssSelector("a[id='listYourProperty']")).Displayed);
            Assert.AreEqual(0, Driver.FindElements(By.CssSelector("#itinerary>svg")).Count);
            //Set browser window size to 600x600
            Driver.Manage().Window.Size = new Size(600, 600);
            wait.Until(driver => Driver.FindElement(By.CssSelector("#itinerary>svg")));
            Assert.IsTrue(Driver.FindElement(By.CssSelector("#itinerary>svg")).Displayed);
            Assert.AreEqual(0, Driver.FindElements(By.CssSelector("a[id='listYourProperty']")).Count);
        }

        [Test]
        public void MultipleWindow()
        {
            // have to use Chrome because of SHIFT+Click, so Driver is overwritten
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://www.amazon.com/gp/gw/ajax/s.html");
            // String mainWindow <= save current window's handle in this string
            string mainWindow = Driver.CurrentWindowHandle;
            new Actions(Driver).KeyDown(Keys.Shift).Click(Driver.FindElement(By.CssSelector("a[href*='cart']"))).KeyUp(Keys.Shift).Perform();
            // ReadOnlyCollection<string> windows <= save all window handles here
            ReadOnlyCollection<string> windows = Driver.WindowHandles;
            // Switch to last opened window
            Driver.SwitchTo().Window(windows.Last());
            StringAssert.Contains("Cart", Driver.Title);
            // Close active window
            Driver.Close();
            // Switch to our main window
            Driver.SwitchTo().Window(mainWindow);
            Assert.IsTrue(Driver.FindElement(By.Id("gw-card-layout")).Displayed);
        }


    }
}
