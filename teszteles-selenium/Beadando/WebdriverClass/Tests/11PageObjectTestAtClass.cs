using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchWidget = WebdriverClass.WidgetsAtClass.SearchWidget;
using ResultWidget = WebdriverClass.WidgetsAtClass.ResultWidget;
using WebdriverClass.PagesAtClass;
using WebdriverClass.Models;

namespace WebdriverClass
{
    class PageObjectTestAtClass : TestBase
    {
        [Test]
        public void PageObjectSearchExample()
        {
            // TASK 1.1: implement a static navigate function to search page which returns a search page instance
            SearchPage searchPage = SearchPage.Navigate(Driver);
            // TASK 1.2: implement GetSearchWidget function and instantiate searchWidget 
            SearchWidget searchWidget = searchPage.GetSearchWidget();

            // TASK 2.1: search for route from "Budapest" to "Szeged" via "Kecskemet"
            // with "Tanuló bérlet" reduction and with SearchWidget.searchOptions.PotjegyNelkul search option
            SearchModel searchModel = new SearchModel()
            {
                FromCity = "Budapest",
                ToCity = "Szeged",
                ViaCity = "Kecskemét",
                Reduction = SearchWidget.Reductions.TanuloBerlet,
                SearchOption = SearchWidget.SearchOptions.PotjegyNelkul,
            };
            // TASK 2.2: implement searchWidget's ClickTimetableButton function to click on Menetrend button and return a search page instance
            SearchPage resultPage = searchWidget.SearchFor(searchModel);
            // TASK 3.1: implement GetResultWidget function to return back with resultWidget
            ResultWidget resultWidget = resultPage.GetResultWidget();

            // TASK 4.1: Finish ResultWidget to give back the number of results
            Assert.Greater(resultWidget?.GetNoOfResults(), 0);
        }

        [Test]
        public void PageObjectSearchWithChainCall()
        {
            SearchModel searchModel = new SearchModel()
            {
                FromCity = "Budapest",
                ToCity = "Szeged",
                ViaCity = "Kecskemét",
                Reduction = SearchWidget.Reductions.TanuloBerlet,
                SearchOption = SearchWidget.SearchOptions.PotjegyNelkul,
            };

            // TASK 5.1: Refactor to use call chain in the test
            int noOfResults = SearchPage.Navigate(Driver)
                .GetSearchWidget()
                .SearchFor(searchModel)
                .GetResultWidget()
                .GetNoOfResults();
            Assert.Greater(noOfResults, 0);
        }
    }
}
