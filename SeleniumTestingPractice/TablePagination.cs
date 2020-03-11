using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.Table
{
    public class TablePaginationTests : IDisposable
    {
        private IWebDriver _driver;

        public By PageOne = By.XPath("//a[contains(text(),'1')]");
        public By PageTwo = By.XPath("//a[contains(text(),'2')]");
        public By PageThree = By.XPath("//a[contains(text(),'3')]");

        public By BackButton = By.XPath("//a[contains(text(),'»')]");
        public By FrontButton = By.XPath("//a[contains(text(),'«')]");



        public TablePaginationTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/table-pagination-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void PaginationTest()
        {
            _driver.FindElement(PageOne).Click();
            _driver.FindElement(PageTwo).Click();
            _driver.FindElement(PageThree).Click();

            _driver.FindElement(FrontButton).Click();
            _driver.FindElement(FrontButton).Click();

            _driver.FindElement(BackButton).Click();
            _driver.FindElement(BackButton).Click();

        }
    }
}
