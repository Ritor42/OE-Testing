using OpenQA.Selenium;
using specflowSudent.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specflowSudent.Widgets
{
    public class FeedbackRadioButtonWidget : FeedbackQuestionWidgetBase
    {
        public FeedbackRadioButtonWidget(IWebDriver driver, int questionNumber) : base(driver, questionNumber)
        {
        }

        public IEnumerable<IWebElement> RadioButtons => Driver.FindElements(By.XPath(this.questionDivXPath + "//input"));

        public FeedbackQuestionPage SetChecked(int index)
        {
            var radioButtons = this.RadioButtons.ToList();
            if (index >= 0 && index < radioButtons.Count)
            {
                radioButtons[index].Click();
            }
            return new FeedbackQuestionPage(Driver);
        }
    }
}
