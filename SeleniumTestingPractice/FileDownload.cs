using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.AlertsandModals
{
    public class FileDownloadTests : IDisposable
    {
        private IWebDriver _driver;

        public By EnterData = By.Id("textbox");
        public By GenerateFile = By.Id("create");
        public By Download = By.Id("link-to-download");


        public FileDownloadTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/generate-file-to-download-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void GenerateFileTest()
        {
            _driver.FindElement(EnterData).SendKeys("Testing Enter Data Textarea");
            _driver.FindElement(GenerateFile).Click();
            _driver.FindElement(Download).Click();
        }
    }
}

