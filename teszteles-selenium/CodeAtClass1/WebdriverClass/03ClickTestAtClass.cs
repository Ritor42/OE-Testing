using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WebdriverClass
{
    class ClickTestAtClass : TestBase
    {
        [Test]
        public void ClickExample()
        {
            Driver.Navigate().GoToUrl("https://stackoverflow.com/questions");
            //Assert that "Newest Questions - Stack Overflow" is the title
            Assert.AreEqual("Newest Questions - Stack Overflow", Driver.Title);

            //Click on Tags link (use Id selector)
            Driver.FindElement(By.Id("nav-tags")).Click();
            Assert.AreEqual("Tags - Stack Overflow", Driver.Title);

            //Click on Stackoverflow logo link (use CssSelector selector)
            Driver.FindElement(By.CssSelector("a[class='-logo js-gps-track']")).Click();
            StringAssert.Contains("Where Developers Learn", Driver.Title);
        }

        [Test]
        public void ShiftClickExample()
        {
            Driver.Navigate().GoToUrl("https://www.amazon.com/gp/gw/ajax/s.html");
            //Use Actions class to create a shift click on Cart link
            //You have to see two browser windows after a successful run
            new Actions(Driver)
                .KeyDown(Keys.Shift)
                .Click(Driver.FindElement(By.Id("nav-cart")))
                .KeyUp(Keys.Shift).Perform();
            Assert.AreEqual(2, Driver.WindowHandles.Count);
        }

        [Test]
        public void DragAndDropTestAtClass()
        {
            Driver.Navigate().GoToUrl("https://jqueryui.com/resources/demos/droppable/default.html");
            //Locate the draggable element
            //Locate the droppable element
            //Add the drag and drop action here
            new Actions(Driver).DragAndDrop(
                Driver.FindElement(By.Id("draggable")),
                Driver.FindElement(By.Id("droppable"))).Perform();
            Assert.IsTrue(Driver.FindElement(By.CssSelector("#droppable > p:nth-child(1)")).Text.Equals("Dropped!"));
        }
    }
}
