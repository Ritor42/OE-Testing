using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass.WidgetsAtClass
{
    public class FeedbackTextBoxWidget : FeedbackQuestionWidgetBase
    {
        public FeedbackTextBoxWidget(IWebDriver driver, int questionNumber) : base(driver, questionNumber)
        {
        }

        public IWebElement TextBox => Driver.FindElement(By.XPath(this.questionDivXPath + "//input"));

        public FeedbackQuestionPage SetText(string text)
        {
            this.TextBox.SendKeys(text);
            return new FeedbackQuestionPage(Driver);
        }
    }
}
