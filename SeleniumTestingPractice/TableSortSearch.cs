using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System;
using Xunit;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SeleniumSandbox.Tests.Table
{
    public class TableSortSearchTests : IDisposable
    {
        private IWebDriver _driver;
        //Entries and Page Test
        public By EntriesDropBox = By.CssSelector("select[name='example_length']");
        public By PageNumber = By.Id("example_info");

        //Search Test
        public By SearchBox = By.CssSelector("input[type='search']");

        //SortTest
        public By NameSort = By.XPath("//table[@id='example']/thead/tr/th");
        public By PositionSort = By.XPath("//table[@id='example']/thead/tr/th[2]");
        public By OfficeSort = By.XPath("//table[@id='example']/thead/tr/th[3]");
        public By AgeSort = By.XPath("//table[@id='example']/thead/tr/th[4]");
        public By StartDateSort = By.XPath("//table[@id='example']/thead/tr/th[5]");
        public By SalarySort = By.XPath("//table[@id='example']/thead/tr/th[6]");

        //Sort and Search Test
        public By NameField = By.CssSelector("td[data-search]");
        public By PositionField = By.XPath("//table[@id='example']/tbody/tr/td[2]");
        public By OfficeField = By.XPath("//table[@id='example']/tbody/tr/td[3]");
        public By AgeField = By.XPath("//table[@id='example']/tbody/tr/td[4]");
        public By StartDateField = By.XPath("//table[@id='example']/tbody/tr/td[5]");
        public By SalaryField = By.XPath("//table[@id='example']/tbody/tr/td[6]");

        //PageTest
        public By PreviousButton = By.CssSelector("a.paginate_button.previous");
        public By PageOne = By.XPath("//a[contains(text(),'1')]");
        public By PageTwo = By.XPath("//a[contains(text(),'2')]");
        public By PageThree = By.XPath("//a[contains(text(),'3')]");
        public By PageFour = By.XPath("//a[contains(text(),'4')]");
        public By NextButton = By.CssSelector("a.paginate_button.next");
        
        public TableSortSearchTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/table-sort-search-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void EntriesTest()
        {
            _driver.FindElement(EntriesDropBox).Click();
            SelectElement selectEntry = new SelectElement(_driver.FindElement(EntriesDropBox));
            selectEntry.SelectByText("100");
            SelectElement selectEntryFifty = new SelectElement(_driver.FindElement(EntriesDropBox));
            selectEntryFifty.SelectByText("50");
            SelectElement selectEntryTwentyFive = new SelectElement(_driver.FindElement(EntriesDropBox));
            selectEntryTwentyFive.SelectByText("25");
            SelectElement selectEntryTen = new SelectElement(_driver.FindElement(EntriesDropBox));
            selectEntryTen.SelectByText("10");

            Actions scroll = new Actions(_driver);
            scroll.MoveToElement(_driver.FindElement(PageNumber));
            scroll.Perform();

            _driver.FindElement(PageNumber).Text.Should().Contain("Showing 1 to 10");

        }

        [Fact]
        public void SearchTest()
        {
            _driver.FindElement(SearchBox).SendKeys("Wilder");
            _driver.FindElement(NameField).Text.Should().Contain("Wilder");
            _driver.FindElement(SearchBox).Clear();

            _driver.FindElement(SearchBox).SendKeys("Sales Assistant");
            _driver.FindElement(PositionField).Text.Should().Contain("Sales Assistant");
            _driver.FindElement(SearchBox).Clear();

            _driver.FindElement(SearchBox).SendKeys("Edinburgh");
            _driver.FindElement(OfficeField).Text.Should().Contain("Edinburgh");
            _driver.FindElement(SearchBox).Clear();

            _driver.FindElement(SearchBox).SendKeys("21");
            _driver.FindElement(AgeField).Text.Should().Contain("21");
            _driver.FindElement(SearchBox).Clear();

        }

        [Fact]
        public void SortTest()
        { 
            _driver.FindElement(NameSort).Click();
            _driver.FindElement(NameField).Text.Should().Contain("Berry");


            _driver.FindElement(PositionSort).Click();
            _driver.FindElement(PositionField).Text.Should().Be("Accountant");

            _driver.FindElement(OfficeSort).Click();
            _driver.FindElement(OfficeField).Text.Should().Be("Edinburgh");

            _driver.FindElement(AgeSort).Click();
            _driver.FindElement(AgeField).Text.Should().Be("19");
   
            _driver.FindElement(StartDateSort).Click();
            _driver.FindElement(StartDateField).Text.Should().Contain("Thu 16th Oct 08");

            _driver.FindElement(SalarySort).Click();
            _driver.FindElement(SalaryField).Text.Should().Contain("$85,600");
        }

        [Fact]
        public void PageTest()
        {
            _driver.FindElement(PageOne).Click();
            _driver.FindElement(PageNumber).Text.Should().Contain("Showing 1 to 10");

            _driver.FindElement(PageTwo).Click();
            _driver.FindElement(PageNumber).Text.Should().Contain("Showing 11 to 20");

            _driver.FindElement(PageThree).Click();
            _driver.FindElement(PageNumber).Text.Should().Contain("Showing 21 to 30");

            _driver.FindElement(PageFour).Click();
            _driver.FindElement(PageNumber).Text.Should().Contain("Showing 31 to 32");

            _driver.FindElement(PreviousButton).Click();
            _driver.FindElement(PageNumber).Text.Should().Contain("Showing 21 to 30");

            _driver.FindElement(NextButton).Click();
            _driver.FindElement(PageNumber).Text.Should().Contain("Showing 31 to 32");

        }
    }
}
