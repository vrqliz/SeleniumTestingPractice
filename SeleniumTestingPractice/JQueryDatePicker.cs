using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.DatePickers
{
    public class JQueryCalendarFields : IDisposable
    {
        private IWebDriver _driver;

        public By FromField = By.Id("from");
        public By ToField = By.Id("to");


        public JQueryCalendarFields()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/jquery-date-picker-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void JQueryDateFields()
        {
            _driver.FindElement(FromField).Click();

            List<IWebElement> FromCalendar = new List<IWebElement>(_driver.FindElements(By.CssSelector(".ui-datepicker-calendar td .ui-state-default"))); // get all the dates.

            foreach (IWebElement day in FromCalendar) // use foreach iterate each cell.
            {
                string date = day.Text; // get the text of the element.

                if (date.Equals("3")) // check if the date is 3
                {
                    day.Click(); // if date is 20, select it.
                    break;
                }
            }

            _driver.FindElement(ToField).Click();

            List<IWebElement> ToCalendar = new List<IWebElement>(_driver.FindElements(By.CssSelector(".ui-datepicker-calendar td .ui-state-default"))); // get all the dates.

            foreach (IWebElement day in ToCalendar) // use foreach iterate each cell.
            {
                string date = day.Text; // get the text of the element.

                if (date.Equals("10")) // check if the date is 10
                {
                    day.Click(); // if date is 20, select it.
                    break;
                }
            }
        }
    }
}
