using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.ListBox
{
    public class BootstrapListBoxes : IDisposable
    {
        private IWebDriver _driver;

        public By LeftSearchBox = By.CssSelector("input[name = 'SearchDualList']");
        public By RightSearchBox = By.XPath("(//input[@name='SearchDualList'])[2]");
        public By LeftOption1 = By.CssSelector("li.list-group-item");
        public By LeftOption2 = By.XPath("//div/div/div/ul/li[2]");
        public By ArrowRightButton = By.XPath("//button[2]");
        public By RightOption1 = By.XPath("//div[3]/div/ul/li");
        public By RightOption2 = By.XPath("//div[3]/div/ul/li[2]");
        public By ArrowLeftButton = By.XPath("//div[2]/button");
        public By LeftSelectAll = By.CssSelector("a.btn.btn-default.selector");
        public By RightSelectAll = By.XPath("(//div[@id='listhead']/div/div/a/i)[2]");



        public BootstrapListBoxes()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/bootstrap-dual-list-box-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void BootstrapListBoxTest()
        {
            _driver.FindElement(LeftOption1).Click();
            _driver.FindElement(LeftOption2).Click();
            _driver.FindElement(ArrowRightButton).Click();
            _driver.FindElement(RightOption1).Click();
            _driver.FindElement(RightOption2).Click();
            _driver.FindElement(ArrowRightButton).Click();
            _driver.FindElement(LeftSelectAll).Click();
            _driver.FindElement(RightSelectAll).Click();

        }
    }
}
