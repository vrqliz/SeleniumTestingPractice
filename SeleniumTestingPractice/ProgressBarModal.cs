using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.AlertsandModals
{
    public class ProgressBarModalTests : IDisposable
    {
        private IWebDriver _driver;

        public By SimpleDialogButton = By.XPath("(//button[@type='button'])[2]");
        public By CustomMessageDialogButton = By.XPath("(//button[@type='button'])[3]");
        public By CustomSettingsDialogButton = By.CssSelector("button.btn.btn-warning");
        public By Modal = By.CssSelector(".modal-header>h3");

        public ProgressBarModalTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/bootstrap-progress-bar-dialog-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(9000);
            _driver.Quit();
        }

        [Fact]
        public void ModalProgessBarTest()
        {
            _driver.FindElement(SimpleDialogButton).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(Modal).Text.Should().Contain("Loading");
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(CustomMessageDialogButton).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(Modal).Text.Should().Contain("Custom message");
            System.Threading.Thread.Sleep(4000);
            _driver.FindElement(CustomSettingsDialogButton).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(Modal).Text.Should().Contain("Hello Mr. Alert !");
        }
    }
}
