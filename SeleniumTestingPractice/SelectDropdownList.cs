using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.InputForms
{
    public class DropdownTests : IDisposable
    {
        private IWebDriver _driver;

        public By SingleDropdown = By.Id("select-demo");
        public By Wednesday = By.CssSelector("option[value='Wednesday']");
        public By SelectedDay = By.ClassName("selected-value");

        public By Ohio = By.CssSelector("option[value='Ohio']");
        public By Texas = By.CssSelector("option[value='Texas']");
        public By Washington = By.CssSelector("option[value='Washington']");
        public By FirstSelected = By.Id("printMe");
        public By GetAllSelected = By.Id("printAll");
        public By SelectdOption = By.ClassName("getall-selected");

        public DropdownTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void DayDropdown()
        {
            _driver.FindElement(SingleDropdown).Click();
            _driver.FindElement(Wednesday).Click();
            _driver.FindElement(SelectedDay).Text.Should().Contain("Day selected :- Wednesday");
        }

        [Fact]
        public void MultiSelect()
        {
            _driver.FindElement(Ohio).Click();
            IWebElement TexasState = _driver.FindElement(Texas);
            IWebElement WashingtonState = _driver.FindElement(Washington);
            Actions actions = new Actions(_driver);
            actions.KeyDown(Keys.Control)
            .Click(TexasState)
            .Click(WashingtonState)
            .KeyUp(Keys.Control)
            .Build()
            .Perform();

            _driver.FindElement(FirstSelected).Click();
            _driver.FindElement(SelectdOption).Text.Should().Contain("First selected option is : Ohio");
            _driver.FindElement(GetAllSelected).Click();
            _driver.FindElement(SelectdOption).Text.Should().Contain("Options selected are : Ohio,Texas,Washington");
            


        }
    }
}
