using OpenQA.Selenium;
using specflowSudent.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specflowSudent.Widgets
{
    public class FeedbackRadioButtonMatrixWidget : FeedbackQuestionWidgetBase
    {
        public FeedbackRadioButtonMatrixWidget(IWebDriver driver, int questionNumber) : base(driver, questionNumber)
        {
        }

        public IEnumerable<IWebElement> GetRadioButtons(int matrixIndex) => Driver.FindElements(By.XPath(this.questionDivXPath + "//div[@class='office-form-matrix-row'][" + matrixIndex + "]//input"));

        public FeedbackQuestionPage ReturnToPage()
        {
            return new FeedbackQuestionPage(Driver);
        }

        public FeedbackRadioButtonMatrixWidget SetChecked(int matrixIndex, int radioButtonIndex)
        {
            var radioButtons = this.GetRadioButtons(matrixIndex).ToList();
            if (radioButtonIndex >= 0 && radioButtonIndex < radioButtons.Count)
            {
                radioButtons[radioButtonIndex].Click();
            }
            return this;
        }
    }
}
