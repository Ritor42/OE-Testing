using NUnit.Framework;
using OpenQA.Selenium;
using specflowSudent.Extensions;
using specflowSudent.Models;
using SpecflowSudent.Pages;
using TechTalk.SpecFlow;
using TestProject;

namespace SpecflowSudent
{
    [Binding]
    class BDDTestSteps : Steps
    {
        [Given(@"I open elvira mav-start page")]
        public void GivenIOpenElviraMav_StartPage()
        {
            var searchPage = SearchPage.Navigate(ScenarioContext.Get<IWebDriver>(BDDTestBase.webDriver));
            ScenarioContext.Add(BDDTestBase.currentPage, searchPage);
        }

        [When(@"I create a search from (.*) to (.*)")]
        public void WhenICreateASearchFromTo(string from, string to)
        {
            var searchPage = ScenarioContext.Get<SearchPage>(BDDTestBase.currentPage);
            searchPage.GetSearchWidget().SetRoute(from, to);
        }

        [When(@"I submit the search from")]
        public void WhenISubmitTheSearchFrom()
        {
            var searchPage = ScenarioContext.Get<SearchPage>(BDDTestBase.currentPage);
            ScenarioContext[BDDTestBase.currentPage] = searchPage.GetSearchWidget().ClickTimetableButton();
        }

        [When(@"I create a search with the following parameters")]
        public void WhenICreateASearchWithTheFollowingParameters(SearchModel searchModel)
        {
            var searchPage = ScenarioContext.Get<SearchPage>(BDDTestBase.currentPage);
            searchPage.GetSearchWidget().FillForm(searchModel);
        }

        [Then(@"the search result title should contain (.*) and (.*)")]
        public void ThenTheSearchResultTitleShouldContainTheFollowingCities(string from, string to)
        {
            var searchPage = ScenarioContext.Get<SearchPage>(BDDTestBase.currentPage);
            var resultTitle = searchPage.GetResultWidget().ResultTitle.Text;
            StringAssert.Contains(from.ToLower(), resultTitle.ToLower());
            StringAssert.Contains(to.ToLower(), resultTitle.ToLower());
        }

        [Then(@"the search result title should contain the following city names")]
        public void ThenTheSearchResultTitleShouldContainTheFollowingCityNames(Table table)
        {
            var cities = table.AsStrings("cities");
            var searchPage = ScenarioContext.Get<SearchPage>(BDDTestBase.currentPage);
            var resultTitle = searchPage.GetResultWidget().ResultTitle.Text;
            foreach (string city in cities)
            {
                StringAssert.Contains(city.ToLower(), resultTitle.ToLower());
            }
        }
    }
}
