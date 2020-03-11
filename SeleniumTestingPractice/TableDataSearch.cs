using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.Table
{
    public class TasksSearchBoxTests : IDisposable
    {
        private IWebDriver _driver;

        public By TaskSearch = By.Id("task-table-filter");

        public By FilterButton = By.CssSelector("button.btn.btn-default.btn-xs.btn-filter");
        public By NumberBox = By.CssSelector("input[placeholder='#']");
        public By Username = By.CssSelector("input[placeholder='Username']");
        public By FirstName = By.CssSelector("input[placeholder='First Name']");
        public By LastName = By.CssSelector("input[placeholder='Last Name']");


        public TasksSearchBoxTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/table-search-filter-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(7000);
            _driver.Quit();
        }

        [Fact]
        public void TasksBoxTest()
        {
            _driver.FindElement(TaskSearch).Click();
            _driver.FindElement(TaskSearch).SendKeys("Wireframes");
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(TaskSearch).Clear();
            _driver.FindElement(TaskSearch).SendKeys("Emily");
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(TaskSearch).Clear();
            _driver.FindElement(TaskSearch).SendKeys("completed");
        }

        [Fact]
        public void ListedUserBoxesTest()
        {
            _driver.FindElement(FilterButton).Click();
            _driver.FindElement(NumberBox).SendKeys("2");
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(NumberBox).Clear();
            _driver.FindElement(Username).SendKeys("mikesali");
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(Username).Clear();
            _driver.FindElement(FirstName).SendKeys("Daniel");
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(FirstName).Clear();
            _driver.FindElement(LastName).SendKeys("Karano");
        }
    }
}
