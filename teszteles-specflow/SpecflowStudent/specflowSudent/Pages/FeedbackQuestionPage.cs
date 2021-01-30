using OpenQA.Selenium;
using specflowSudent.Widgets;
using SpecflowSudent.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specflowSudent.Pages
{
    public class FeedbackQuestionPage : BasePage
    {
        public FeedbackQuestionPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public static FeedbackQuestionPage Navigate(IWebDriver webDriver)
        {
            const string target = "https://forms.office.com/Pages/ResponsePage.aspx?id=0HIbtJ9OJkyKaflJ82fJHemFnY1uiJpLseLCaxLxmwlUNUFPRjJFSU1VNDdYWlo0MFQyVTExTjBWVC4u";
            webDriver.Navigate().GoToUrl(target);
            if (webDriver.Url != target)
            {
                throw new Exception($"webDriver has been redirected from target url:\r\nExpected: {target}\r\nValue: {webDriver.Url}");
            }
            return new FeedbackQuestionPage(webDriver);
        }

        public FeedbackFillWidget GetFillWidget()
        {
            return new FeedbackFillWidget(Driver, this);
        }

        public FeedbackTextBoxWidget GetTextBoxWidget(int index)
        {
            return new FeedbackTextBoxWidget(Driver, index);
        }

        public FeedbackRadioButtonWidget GetRadioButtonWidget(int index)
        {
            return new FeedbackRadioButtonWidget(Driver, index);
        }

        public FeedbackRadioButtonItemWidget GetRadioButtonItemWidget(int index)
        {
            return new FeedbackRadioButtonItemWidget(Driver, index);
        }

        public FeedbackRadioButtonMatrixWidget GetRadioButtonMatrixWidget(int index)
        {
            return new FeedbackRadioButtonMatrixWidget(Driver, index);
        }

        public FeedbackNavigationWidget GetNavigationWidget()
        {
            return new FeedbackNavigationWidget(Driver);
        }
    }
}
