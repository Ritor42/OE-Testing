using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebdriverClass
{
    class WebdriverWaitTestAtClass : TestBase
    {
        [Test]
        public void WaitTitle()
        {
            Driver.Navigate().GoToUrl("http://www.google.hu");
            
            IWebElement query = Driver.FindElement(By.Name("q"));
            query.SendKeys("Selenium");
            query.Submit();

            //create a WebDriverWait which waits until the page title starts with "Selenium"
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(By.Name("q")).GetAttribute("value") == "Selenium");
            Assert.AreEqual("Selenium - Google-keresés", Driver.Title);
        }

        [Test]
        public void WaitKeyboard()
        {
            Driver.Navigate().GoToUrl("http://www.google.hu");
            Driver.Manage().Cookies.DeleteCookieNamed("CONSENT");
            var cookie = new Cookie("CONSENT", "YES+HU.hu+V12+BX");
            Driver.Manage().Cookies.AddCookie(cookie);
            Driver.Navigate().Refresh();

            Driver.FindElement(By.CssSelector("div.J9leP")).Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //wait until the keyboard is shown
            wait.Until(driver => driver.FindElement(By.Id("kbd")));

            Driver.FindElement(By.Id("K81")).Click(); //this clicks on q key on keyboard

            Driver.FindElement(By.CssSelector("div[class='FPdoLc tfB0Bf'] [name=btnK]")).Click();

            Assert.AreEqual("q - Google-keresés", Driver.Title);
        }
    }
}