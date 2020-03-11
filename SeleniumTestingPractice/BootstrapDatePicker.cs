using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.DatePickers
{
    public class BootstrapDate : IDisposable
    {
        private IWebDriver _driver;

        public By SingleDateBox = By.CssSelector("input[placeholder='dd/mm/yyyy']");
        /*public By CalendarElement = By.XPath("/html/body/div[3]/div[1]/table/tbody/tr[4]/td[2]");*/

        public By StartDate = By.CssSelector("input[placeholder='Start date']");
        public By EndDate = By.CssSelector("input[placeholder='End date']");
        public By StartCalendarDate = By.XPath("/html/body/div[3]/div[1]/table/tbody/tr[2]/td[2]");
        public By EndCalendarDate = By.XPath("/html/body/div[3]/div[1]/table/tbody/tr[2]/td[6]");

        public BootstrapDate()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/bootstrap-date-picker-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void BootstrapSingleDateTest()
        {
            _driver.FindElement(SingleDateBox).Click();
            /*_driver.FindElement(CalendarElement).Click();*/

            List<IWebElement> Calendar = new List<IWebElement>(_driver.FindElements(By.CssSelector(".datepicker-days td.day"))); // get all the dates.

            foreach (IWebElement day in Calendar) // use foreach iterate each cell.
            {
                string date = day.Text; // get the text of the element.

                if (date.Equals("3")) // check if the date is 3
                {
                    day.Click(); // if date is 20, select it.
                    break;
                }
            }
 
        }

        [Fact]
        public void BootstrapDateRangeTest()
        {
            _driver.FindElement(StartDate).Click();
            _driver.FindElement(EndDate).Click();
            _driver.FindElement(StartCalendarDate).Click();
            _driver.FindElement(EndCalendarDate).Click();

        }
    }
}
