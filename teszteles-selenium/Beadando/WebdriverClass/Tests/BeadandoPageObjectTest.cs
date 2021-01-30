using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebdriverClass.Models;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass.Tests
{
    public class BeadandoPageObjectTest : TestBase
    {
        [Test, TestCaseSource("FeedbackData")]
        public void PageObjectBeadandoTest(FeedbackModel model)
        {
            Driver.Manage().Window.Maximize();
            FeedbackQuestionPage.Navigate(Driver)
                .GetTextBoxWidget(1).SetText(model.FirstAnswer)
                .GetRadioButtonWidget(2).SetChecked(model.SecondAnswer)
                .GetNavigationWidget().ClickButton()
                .GetRadioButtonMatrixWidget(1)
                    .SetChecked(1, model.ThirdAnswer[0])
                    .SetChecked(2, model.ThirdAnswer[1])
                    .SetChecked(3, model.ThirdAnswer[2])
                    .SetChecked(4, model.ThirdAnswer[3])
                    .ReturnToPage()
                .GetRadioButtonWidget(2).SetChecked(model.FourthAnswer)
                .GetTextBoxWidget(3).SetText(model.FifthAnswer)
                .GetRadioButtonItemWidget(4).SetChecked(model.SixthAnswer)
                .GetNavigationWidget().ClickButton();
            var resultPage = new FeedbackResultPage(Driver);
            Assert.IsTrue(resultPage.GetResultWidget().IsCompleteIconExists());
        }

        static IEnumerable<FeedbackModel> FeedbackData()
        {
            var doc = XElement.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + "\\data.xml");
            return
                from vars in doc.Descendants("testData")
                let firstAnswer = vars.Attribute("firstAnswer").Value
                let secondAnswer = int.Parse(vars.Attribute("secondAnswer").Value) - 1
                let thirdAnswer = vars.Attribute("thirdAnswer").Value.Split(',').Select(x => int.Parse(x) - 1).ToArray()
                let fourthAnswer = int.Parse(vars.Attribute("fourthAnswer").Value) - 1
                let fifthAnswer = vars.Attribute("fifthAnswer").Value
                let sixthAnswer = int.Parse(vars.Attribute("sixthAnswer").Value)
                select new FeedbackModel
                {
                    FirstAnswer = firstAnswer,
                    SecondAnswer = secondAnswer,
                    ThirdAnswer = thirdAnswer,
                    FourthAnswer = fourthAnswer,
                    FifthAnswer = fifthAnswer,
                    SixthAnswer = sixthAnswer
                };
        }
    }
}
