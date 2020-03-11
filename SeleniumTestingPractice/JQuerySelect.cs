using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.InputForms
{
    public class JQuerySelectFormTests : IDisposable
    {
        private IWebDriver _driver;

        public By Country = By.Id("country");
        public By State = By.CssSelector("select.js-example-basic-multiple.select2-hidden-accessible");
        public By Territories = By.CssSelector("select.js-example-disabled-results.select2-hidden-accessible");
        public By SelectFile = By.Id("files");


        public JQuerySelectFormTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/jquery-dropdown-search-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void AjaxFormTest()
        {
            SelectElement selectCountry = new SelectElement(_driver.FindElement(Country));
            selectCountry.SelectByText("Denmark");
            SelectElement selectState = new SelectElement(_driver.FindElement(State));
            selectState.SelectByText("Iowa");
            selectState.SelectByText("Ohio");
            SelectElement selectTerritory = new SelectElement(_driver.FindElement(Territories));
            selectTerritory.SelectByText("Puerto Rico");
            SelectElement Files = new SelectElement(_driver.FindElement(SelectFile));
            Files.SelectByText("Java");

        }
    }
}
