using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace TestProject
{
    [Binding]
    class BDDTestBase : Steps
    {
        public const string webDriver = "driver";
        public const string currentPage = "currentPage";

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=hu");
            var driver = new ChromeDriver(options);
            ScenarioContext.Add(webDriver, driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = ScenarioContext.Get<IWebDriver>(webDriver); ;
            driver.Quit();
        }
    }
}
