using System;
using NUnit.Framework;

namespace WebdriverClass
{
    class NavigationTestAtClass : TestBase
    {
        private String AssertTitleChange(String oldTitle)
        {
            String newTitle = Driver.Title;
            Assert.AreNotEqual(oldTitle, newTitle);
            return newTitle;
        }

        [Test]
        public void NavigationExample()
        {
            String title = "";
            //Navigate to https://www.google.com
            Driver.Url = "https://www.google.com";
            title = AssertTitleChange(title);

            //Navigate to https://www.bing.com
            Driver.Url = "https://www.bing.com";
            title = AssertTitleChange(title);

            //Navigate back
            Driver.Navigate().Back();
            title = AssertTitleChange(title);

            //Navigate forward
            Driver.Navigate().Forward();
            title = AssertTitleChange(title);

            //Refresh browser window
            Driver.Navigate().Refresh();
            Assert.AreEqual(title, Driver.Title);
            Assert.AreEqual("https://www.bing.com/", Driver.Url);
        }
    }
}
