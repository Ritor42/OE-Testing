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
    public class FeedbackResultPage : BasePage
    {
        public FeedbackResultPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public FeedbackResultWidget GetResultWidget()
        {
            return new FeedbackResultWidget(Driver);
        }
    }
}
