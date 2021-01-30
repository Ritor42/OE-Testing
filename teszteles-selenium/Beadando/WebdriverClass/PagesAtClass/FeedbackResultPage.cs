using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverClass.WidgetsAtClass;

namespace WebdriverClass.PagesAtClass
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
