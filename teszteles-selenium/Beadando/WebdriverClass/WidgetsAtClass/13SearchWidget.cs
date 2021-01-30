using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebdriverClass.Models;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass.WidgetsAtClass
{
    public class SearchWidget : BasePage
    {
        public SearchWidget(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement SearchBottom => Driver.FindElement(By.Id("searchbottom"));
        public IWebElement RouteFrom => Driver.FindElement(By.Id("i"));
        public IWebElement RouteTo => Driver.FindElement(By.Id("e"));
        public IWebElement RouteVia => Driver.FindElement(By.Id("v"));
        public IWebElement ReductionSlct => Driver.FindElement(By.Id("u"));
        public IWebElement SearchButton => Driver.FindElement(By.Name("go"));

        private readonly Dictionary<SearchOptions, string> searchOptionLocators = new Dictionary<SearchOptions, string>()
        {
            { SearchOptions.PotjegyNelkul , "s1" },
            { SearchOptions.AtszallasNelkul , "sk" },
            { SearchOptions.HelyiKozlekedesNelkul , "hkn" },
            { SearchOptions.BudapestBerlettel , "sb" },
            { SearchOptions.Kerekparral , "s2" },
            { SearchOptions.BudapestFejpalyaudvaronAt , "s1" }
        };

        private readonly Dictionary<Reductions, string> reductionLocators = new Dictionary<Reductions, string>()
        {
            { Reductions.TanuloBerlet, "1161" }
        };

        public enum SearchOptions
        {
            PotjegyNelkul,
            AtszallasNelkul,
            HelyiKozlekedesNelkul,
            BudapestBerlettel,
            Kerekparral,
            BudapestFejpalyaudvaronAt,
        }

        public enum Reductions
        {
            TanuloBerlet
        }

        public void SetRoute(String fromCity, String toCity)
        {
            RouteFrom.SendKeys(fromCity);
            RouteTo.SendKeys(toCity);
        }
        
        public void SetRoute(String fromCity, String toCity, String viaCity)
        {
            SetRoute(fromCity, toCity);
            RouteVia.SendKeys(viaCity);
        }

        public void SetReduction(Reductions? reduction){
            if (reduction != null)
            {
                new SelectElement(ReductionSlct).SelectByValue(reductionLocators[reduction.Value]);
            }
        }

        public void SetSearchOptionTo(SearchOptions? searchOption)
        {
            if (searchOption != null)
            {
                SearchBottom.FindElement(By.Id(searchOptionLocators[searchOption.Value])).Click();
            }
        }

        public SearchPage SearchFor(SearchModel search)
        {
            SetRoute(search.FromCity, search.ToCity, search.ViaCity);
            SetReduction(search.Reduction);
            SetSearchOptionTo(search.SearchOption);
            return ClickTimetableButton();
        }

        // TASK 2.2: implement searchWidget's ClickTimetableButton function to click on Menetrend button and return a search page instance
        public SearchPage ClickTimetableButton()
        {
            // Click on searchButton
            SearchButton.Click();
            // Return a SearchPage instance
            return new SearchPage(Driver);
        }
    }
}
