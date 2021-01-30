using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass.WidgetsAtClass
{
    public class FeedbackRadioButtonItemWidget : FeedbackQuestionWidgetBase
    {
        public FeedbackRadioButtonItemWidget(IWebDriver driver, int questionNumber) : base(driver, questionNumber)
        {
        }

        public IEnumerable<IWebElement> RadioButtons => Driver.FindElements(By.XPath(this.questionDivXPath + "//span[@class='radio-button-display']"));

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
