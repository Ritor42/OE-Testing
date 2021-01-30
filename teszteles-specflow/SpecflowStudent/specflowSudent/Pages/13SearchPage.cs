using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SpecflowSudent.Widgets;

namespace SpecflowSudent.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public static SearchPage Navigate(IWebDriver webDriver)
        {
            webDriver.Navigate().GoToUrl("http://elvira.mav-start.hu/elvira.dll/xslvzs/index?language=1");
            return new SearchPage(webDriver);
        }

        public SearchWidget GetSearchWidget()
        {
            return new SearchWidget(Driver);
        }

        public ResultWidget GetResultWidget()
        {
            return new ResultWidget(Driver);
        }
    }
}
