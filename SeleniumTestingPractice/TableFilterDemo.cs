using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.Table
{
    public class TableFilterDemoTests : IDisposable
    {
        private IWebDriver _driver;

        public By GreenButton = By.CssSelector("button.btn.btn-success.btn-filter");
        public By OrangeButton = By.CssSelector("button.btn.btn-warning.btn-filter");
        public By RedButton = By.CssSelector("button.btn.btn-danger.btn-filter");
        public By AllButton = By.CssSelector("button.btn.btn-default.btn-filter");

        public By CheckboxOne = By.Id("checkbox1");
        public By CheckboxThree = By.Id("checkbox3");
        public By CheckboxTwo = By.Id("checkbox2");
        public By CheckboxFour = By.Id("checkbox4");
        public By CheckboxFive = By.Id("checkbox5");

        public By StarOne = By.XPath("//a/i");
        public By StartTwo = By.XPath("//tr[2]/td[2]/a/i");
        public By StarThree = By.XPath("//tr[3]/td[2]/a/i");
        public By StarFour = By.XPath("//tr[4]/td[2]/a/i");
        public By StarFive = By.XPath("//tr[5]/td[2]/a/i");

        public TableFilterDemoTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/table-records-filter-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(7000);
            _driver.Quit();
        }

        [Fact]
        public void TableFilterButtonTests()
        {
            _driver.FindElement(GreenButton).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(OrangeButton).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(RedButton).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(AllButton).Click();
        }

        [Fact]
        public void TableFilterCheckboxes()
        {
            Actions check = new Actions(_driver);
            check.MoveToElement(_driver.FindElement(CheckboxOne)).Click().Perform();
            check.MoveToElement(_driver.FindElement(CheckboxThree)).Click().Perform();
            check.MoveToElement(_driver.FindElement(CheckboxTwo)).Click().Perform();
            check.MoveToElement(_driver.FindElement(CheckboxFour)).Click().Perform();
            check.MoveToElement(_driver.FindElement(CheckboxFive)).Click().Perform();
        }

        [Fact]
        public void TableFilterStars()
        {
            _driver.FindElement(StarOne).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(StartTwo).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(StarThree).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(StarFour).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(StarFive).Click();
        }
    }
}
