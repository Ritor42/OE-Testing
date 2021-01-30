using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass.WidgetsAtClass
{
    public class FeedbackNavigationWidget : BasePage
    {
        public FeedbackNavigationWidget(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement NavigationButton => Driver.FindElement(By.XPath("//div[@class='office-form-navigation-container']//button[last()]"));

        public FeedbackQuestionPage ClickButton()
        {
            this.NavigationButton.Click();
            return new FeedbackQuestionPage(Driver);
        }
    }
}
