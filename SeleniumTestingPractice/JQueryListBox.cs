using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System;
using Xunit;
using OpenQA.Selenium.Interactions;

namespace SeleniumSandbox.Tests.ListBox
{
    public class JQueryListBoxes : IDisposable
    {
        private IWebDriver _driver;

        public By OptionOne = By.Id("1");
        public By OptionTwo = By.Id("2");
        public By OptionThree = By.Id("3");
        public By AddButton = By.CssSelector("button.pAdd.btn.btn-primary.btn-sm");
        public By AddAllButton = By.CssSelector("pAddAll.btn.btn-primary btn-sm");
        public By RemoveButton = By.CssSelector("button.pRemove.btn.btn-primary.btn-sm");
        public By RemoveAllButton = By.CssSelector("button.pRemoveAll.btn.btn-primary.btn-sm");


        public JQueryListBoxes()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/jquery-dual-list-box-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void JQueryListBoxTest()
        {
            _driver.FindElement(OptionOne).Click();
            IWebElement OptionNumTwo = _driver.FindElement(OptionTwo);
            IWebElement OptionNumThree = _driver.FindElement(OptionThree);
            Actions clickaction = new Actions(_driver);
            clickaction.KeyDown(Keys.Control)
            .Click(OptionNumTwo)
            .Click(OptionNumThree)
            .KeyUp(Keys.Control)
            .Build()
            .Perform();
        }
    }
}

