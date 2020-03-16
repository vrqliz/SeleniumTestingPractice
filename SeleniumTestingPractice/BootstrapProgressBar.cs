using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.ProgressBars
{
    public class BootstrapProgressBarTests : IDisposable
    {
        private IWebDriver _driver;

        public By PercentageAmount = By.CssSelector("div.percenttext");
        public By DownloadSizeButton = By.Id("cricle-btn");


        public BootstrapProgressBarTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/bootstrap-download-progress-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(14000);
            _driver.Quit();
        }

        [Fact]
        public void BootstrapProgressDownloadTest()
        {
            _driver.FindElement(DownloadSizeButton).Click();
            System.Threading.Thread.Sleep(21000);
            _driver.FindElement(PercentageAmount).Text.Should().Contain("100%");

        }
    }
}
