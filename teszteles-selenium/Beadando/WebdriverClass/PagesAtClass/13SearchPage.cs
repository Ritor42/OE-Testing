using OpenQA.Selenium;
using System;
using WebdriverClass.WidgetsAtClass;
using SearchWidget = WebdriverClass.WidgetsAtClass.SearchWidget;

namespace WebdriverClass.PagesAtClass
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        // TASK 1.1: implement a static navigate function to search page which returns a search page instance
        public static SearchPage Navigate(IWebDriver webDriver)
        {
            // Navigate to "http://elvira.mav-start.hu/elvira.dll/x/index?language=1"
            const string target = "https://elvira.mav-start.hu/elvira.dll/x/index?language=1";
            webDriver.Navigate().GoToUrl(target);
            if (webDriver.Url != target)
            {
                throw new Exception($"webDriver has been redirected from target url:\r\nExpected: {target}\r\nValue: {webDriver.Url}");
            }
            return new SearchPage(webDriver);
        }

        // TASK 1.2: implement GetSearchWidget function
        public SearchWidget GetSearchWidget()
        {
            return new SearchWidget(Driver);
        }

        // TASK 3.1: implement GetResultWidget function to return back with resultWidget
        public ResultWidget GetResultWidget()
        {
            return new ResultWidget(Driver);
        }
    }
}
