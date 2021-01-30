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
    public class FeedbackResultWidget : BasePage
    {
        public FeedbackResultWidget(IWebDriver driver) : base(driver)
        {
        }

        public bool IsCompleteIconExists()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            return wait.Until(driver => driver.FindElements(By.XPath("//i[@class='ms-Icon ms-Icon--Completed office-form-theme-primary-color thank-you-page-font-icon']")).Count > 0);
        }
    }
}
