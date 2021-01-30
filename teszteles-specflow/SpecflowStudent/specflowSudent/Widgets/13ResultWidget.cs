using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SpecflowSudent.Pages;
using System.Linq;

namespace SpecflowSudent.Widgets
{
    public class ResultWidget : BasePage
    {
        public ResultWidget(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Timetable => Driver.FindElement(By.Id("timetable"));
        public IWebElement ResultTitle => Driver.FindElement(By.ClassName("lrtftop"));

        public int GetNoOfResults()
        {
            return (Timetable.FindElements(By.TagName("tr")).Count() / 2);
        }

        public string ReturnResultTitle()
        {
            return ResultTitle.Text;
        }
    }
}
