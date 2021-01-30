using NUnit.Framework;
using OpenQA.Selenium;
using specflowSudent.Extensions;
using specflowSudent.Models;
using specflowSudent.Pages;
using TechTalk.SpecFlow;
using TestProject;

namespace SpecflowSudent
{
    [Binding]
    class BeadandoTestSteps : Steps
    {
        [Given(@"I open microsoft forms survey page")]
        public void GivenIOpenMicrosoftFormsSurveyPage()
        {
            var questionPage = FeedbackQuestionPage.Navigate(ScenarioContext.Get<IWebDriver>(BDDTestBase.webDriver));
            ScenarioContext.Add(BDDTestBase.currentPage, questionPage);
        }

        [When(@"I fill the survey with the following parameters")]
        public void WhenIFillTheSurveyWithTheFollowingParameters(FeedbackModel feedbackModel)
        {
            var questionPage = ScenarioContext.Get<FeedbackQuestionPage>(BDDTestBase.currentPage);
            questionPage.GetFillWidget().FillForm(feedbackModel);
        }

        [When(@"I submit the survey from")]
        public void WhenISubmitTheSurveyFrom()
        {
            var questionPage = ScenarioContext.Get<FeedbackQuestionPage>(BDDTestBase.currentPage);
            ScenarioContext[BDDTestBase.currentPage] = new FeedbackResultPage(ScenarioContext.Get<IWebDriver>(BDDTestBase.webDriver));
        }

        [Then(@"the survey result should contain the tick symbol")]
        public void ThenTheSurveyResultShouldContainTheTickSymbol()
        {
            var resultPage = ScenarioContext.Get<FeedbackResultPage>(BDDTestBase.currentPage);
            Assert.IsTrue(resultPage.GetResultWidget().IsCompleteIconExists());
        }
    }
}
