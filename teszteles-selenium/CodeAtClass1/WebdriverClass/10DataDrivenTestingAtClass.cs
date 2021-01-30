using System;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebdriverClass
{
    class DataDrivenTestingAtClass : TestBase
    {
        // Expand test attributes - localizationData
        [Test, TestCaseSource("LocalizationData")]
        public void LocalizationXMLTest(String lang, String text)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=" + lang);
            Driver = new ChromeDriver(options);

            Driver.Navigate().GoToUrl("http://elvira.mav-start.hu/");
            var timetableText = Driver.FindElement(By.Name("go")).GetAttribute("value");
            Console.WriteLine(timetableText);
            StringAssert.Contains(timetableText, text);
        }

        // Expand test attributes - testData
        [Test, TestCaseSource("TestData")]
        public void XMLTest(String country, String desc)
        {

            Driver.Navigate().GoToUrl("http://en.wikipedia.org/wiki/Main_Page");
            Driver.FindElement(By.Id("searchInput")).Clear();
            Driver.FindElement(By.Id("searchInput")).SendKeys(country);
            Driver.FindElement(By.Id("searchButton")).Click();
            String officialName = Driver.FindElement(By.ClassName("country-name")).Text;
            Console.WriteLine(officialName);
            Assert.True(desc.Equals(officialName.Trim()));
        }

        static IEnumerable LocalizationData()
        {
            // Open and read the contents of localization.xml like data.xml below
            var doc = XElement.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + "\\localization.xml");
            return
                from vars in doc.Descendants("localizationData")
                let lang = vars.Attribute("lang").Value
                let text = vars.Attribute("text").Value
                select new object[] { lang, text };
        }

        static IEnumerable TestData()
        {
            var doc = XElement.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + "\\data.xml");
            return
                from vars in doc.Descendants("testData")
                let country = vars.Attribute("country").Value
                let desc = vars.Attribute("desc").Value
                select new object[] { country, desc };
        }
    }
}
