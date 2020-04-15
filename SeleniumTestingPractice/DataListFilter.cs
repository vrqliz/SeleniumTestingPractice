using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System;
using Xunit;
using OpenQA.Selenium.Interactions;

namespace SeleniumSandbox.Tests.ListBox
{
    public class DataListFilter : IDisposable
    {
        private IWebDriver _driver;
        
        //Search Attendees filter box and name field for business cards 
        public By SearchBox = By.Id("input-search");
        public By NameField = By.XPath("//div[4]/div/h4");
        


        public DataListFilter()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/data-list-filter-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void DataListFilterTest()
        {

            //Enter "Brian Hoyies" in the the Search Box and make sure that Brian Hoyies business card displays
            _driver.FindElement(SearchBox).SendKeys("Brian Hoyies");
            _driver.FindElement(SearchBox).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(NameField).Text.Should().Contain("Brian Hoyies");
        }
    }
}

