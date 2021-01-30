using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass.WidgetsAtClass
{
    public class FeedbackQuestionWidgetBase : BasePage
    {
        protected readonly string questionDivXPath;
        public FeedbackQuestionWidgetBase(IWebDriver driver, int questionNumber) : base(driver)
        {
            this.questionDivXPath = "//div[@class='__question__ office-form-question  '][" + questionNumber + "]";
        }

        public IWebElement QuestionDiv => Driver.FindElement(By.XPath(this.questionDivXPath));
    }
}
