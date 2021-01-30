using OpenQA.Selenium;
using specflowSudent.Models;
using specflowSudent.Pages;
using SpecflowSudent.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specflowSudent.Widgets
{
    public class FeedbackFillWidget : BasePage
    {
        private readonly FeedbackQuestionPage page;

        public FeedbackFillWidget(IWebDriver driver, FeedbackQuestionPage page)
            : base(driver)
        {
            this.page = page;
        }

        public void FillForm(FeedbackModel model)
        {
            int[] thirdAnswer = model.ThirdAnswer
                .Split(new[] { ", " }, StringSplitOptions.None)
                .Select(x => int.Parse(x)).ToArray();

            Driver.Manage().Window.Maximize();
            this.page
            .GetTextBoxWidget(1).SetText(model.FirstAnswer)
            .GetRadioButtonWidget(2).SetChecked(model.SecondAnswer)
            .GetNavigationWidget().ClickButton()
            .GetRadioButtonMatrixWidget(1)
                .SetChecked(1, thirdAnswer[0])
                .SetChecked(2, thirdAnswer[1])
                .SetChecked(3, thirdAnswer[2])
                .SetChecked(4, thirdAnswer[3])
                .ReturnToPage()
            .GetRadioButtonWidget(2).SetChecked(model.FourthAnswer)
            .GetTextBoxWidget(3).SetText(model.FifthAnswer)
            .GetRadioButtonItemWidget(4).SetChecked(model.SixthAnswer)
            .GetNavigationWidget().ClickButton();
        }
    }
}
