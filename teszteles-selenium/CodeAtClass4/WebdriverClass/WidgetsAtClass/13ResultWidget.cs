using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass.WidgetsAtClass
{
    public class ResultWidget : BasePage
    {
        public ResultWidget(IWebDriver driver) : base(driver)
        {
        }

        // TASK 4.2: Create a new timetable webelement using Expression body
        private IWebElement timeTable => Driver.FindElement(By.Id("timetable"));
        // TASK 4.3: localize lines as a sub element of the timetable use ".//table/tbody/tr[@style]" xpath locator to this
        // Call the ToList function on the ReadOnlyCollection
        private List<IWebElement> Lines => timeTable.FindElements(By.XPath(".//table/tbody/tr[@style]")).ToList();

        public int GetNoOfResults()
        {
            return Lines.Count;
        }
    }
}
