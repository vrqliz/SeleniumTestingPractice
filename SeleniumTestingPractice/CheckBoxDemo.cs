using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SeleniumSandbox.Tests.InputForms
{
    public class CheckBoxTests : IDisposable
    {
        private IWebDriver _driver;

        public By singleCheckbox = By.Id("isAgeSelected");
        public By successMessage = By.Id("txtAge");

        public By listCheckbox = By.CssSelector("input.cb1-element");
        public By checkAllButton = By.Id("check1");

        public CheckBoxTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(10000);
            _driver.Quit();
        }

        [Fact]
        public void SingleCheckboxTest()
        {
            _driver.FindElement(singleCheckbox).Click();

            _driver.FindElement(successMessage).Text.Should().Be("Success - Check box is checked");
        }

        [Fact]
        public void MultipleCheckboxTest()
        {
            IReadOnlyCollection<IWebElement> checkboxList = _driver.FindElements(listCheckbox);

            _driver.FindElement(checkAllButton).GetAttribute("value").Should().Be("Check All");

            checkboxList.ElementAt(0).Click();
            checkboxList.ElementAt(1).Click();
            checkboxList.ElementAt(2).Click();
            checkboxList.ElementAt(3).Click();

            _driver.FindElement(checkAllButton).GetAttribute("value").Should().Be("Uncheck All");
        }
    }
}
