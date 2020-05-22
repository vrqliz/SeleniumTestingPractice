using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.Others
{
    public class DynamicData : IDisposable
    {
        private IWebDriver _driver;

        public By GetNewUser = By.Id("save");

        public DynamicData()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/drag-and-drop-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void DynamicDataTest()
        {

            _driver.FindElement(GetNewUser).Click();


        }
    }
}