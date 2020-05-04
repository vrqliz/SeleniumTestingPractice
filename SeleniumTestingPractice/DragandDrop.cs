using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.Others
{
    public class DragandDropTests : IDisposable
    {
        private IWebDriver _driver;

        //public By DraggableItems = By.XPath("//div[@id='todrag']/span");
        //public By DropBox = By.Id("mydropzone");
        public By DroppedItemList = By.Id("droppedlist");

        public DragandDropTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/drag-and-drop-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void DraggableItemsTest()
        {
            IWebElement DraggableItem = _driver.FindElement(By.XPath("//div[@id='todrag']/span"));

            IWebElement DropBox = _driver.FindElement(By.Id("mydropzone"));

            Actions move = new Actions(_driver);

            IAction DragandDrop = move.ClickAndHold(DraggableItem)
                .MoveToElement(DropBox)
                .Release()
                .Build();
                DragandDrop.Perform();
            System.Threading.Thread.Sleep(2000);
        }
    }
}