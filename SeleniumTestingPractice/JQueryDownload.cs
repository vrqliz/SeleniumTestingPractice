using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.ProgressBars
{
    public class JQueryDownloadTests : IDisposable
    {
        private IWebDriver _driver;

        public By StartDownload = By.Id("downloadButton");
        public By DownloadType = By.Id("ui-id-1");
        public By DownloadStatus = By.ClassName("progress-label");
        public By CloseButton = By.CssSelector("div.ui-dialog-buttonset > button[type='button']");


        public JQueryDownloadTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/jquery-download-progress-bar-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(10000);
            _driver.Quit();
        }

        [Fact]
        public void JQueryProgressBarCompleteTest()
        {
            _driver.FindElement(StartDownload).Click();
            System.Threading.Thread.Sleep(10000);
            _driver.FindElement(DownloadType).Text.Should().Be("File Download");
            _driver.FindElement(DownloadStatus).Text.Should().Be("Complete!");
            _driver.FindElement(CloseButton).Click();
        }
    }
}
