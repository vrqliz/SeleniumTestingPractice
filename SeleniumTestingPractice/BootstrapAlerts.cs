using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.AlertsandModals
{
    public class BootstrapAlertTests : IDisposable
    {
        private IWebDriver _driver;

        public By AutoCloseSuccess = By.Id("autoclosable-btn-success");
        public By AutoCloseSuccessMessage = By.CssSelector("div.alert.alert-success.alert-autocloseable-success");
        public By NormalSuccess = By.Id("normal-btn-success");
        public By NormalSuccessMessage = By.CssSelector("div.alert.alert-success.alert-normal-success");
        public By AutoCloseWarning = By.Id("autoclosable-btn-warning");
        public By AutoCloseWarningMessage = By.CssSelector("div.alert.alert-warning.alert-autocloseable-warning");
        public By NormalWarning = By.Id("normal-btn-warning");
        public By NormalWarningMessage = By.CssSelector("div.alert.alert-warning.alert-normal-warning");
        public By AutoCloseDanger = By.Id("autoclosable-btn-danger");
        public By AutoCloseDangerMessage = By.CssSelector("div.alert.alert-danger.alert-autocloseable-danger");
        public By NormalDanger = By.Id("normal-btn-danger");
        public By NormalDangerMessage = By.CssSelector("div.alert.alert-danger.alert-normal-danger");
        public By AutoCloseInfo = By.Id("autoclosable-btn-info");
        public By AutoCloseInfoMessage = By.CssSelector("div.alert.alert-info.alert-autocloseable-info");
        public By NormalInfo = By.Id("normal-btn-info");
        public By NormalInfoMessage = By.CssSelector("div.alert.alert-info.alert-normal-info");

        public BootstrapAlertTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/bootstrap-alert-messages-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(9000);
            _driver.Quit();
        }

        [Fact]
        public void BootstrapAlertMessageTest()
        {
            _driver.FindElement(AutoCloseSuccess).Click();
            _driver.FindElement(AutoCloseSuccessMessage).Text.Should().Contain("I'm an autocloseable success message. I will hide in 5 seconds.");

            _driver.FindElement(NormalSuccess).Click();
            _driver.FindElement(NormalSuccessMessage).Text.Should().Contain("I'm a normal success message. To close use the appropriate button.");

            _driver.FindElement(AutoCloseWarning).Click();
            _driver.FindElement(AutoCloseWarningMessage).Text.Should().Contain("I'm an autocloseable warning message. I will hide in 3 seconds.");

            _driver.FindElement(NormalWarning).Click();
            _driver.FindElement(NormalWarningMessage).Text.Should().Contain("I'm a normal warning message. To close use the appropriate button.");

            _driver.FindElement(AutoCloseDanger).Click();
            _driver.FindElement(AutoCloseDangerMessage).Text.Should().Contain("I'm an autocloseable danger message. I will hide in 5 seconds.");

            _driver.FindElement(NormalDanger).Click();
            _driver.FindElement(NormalDangerMessage).Text.Should().Contain("I'm a normal danger message. To close use the appropriate button.");

            _driver.FindElement(AutoCloseInfo).Click();
            _driver.FindElement(AutoCloseInfoMessage).Text.Should().Contain("I'm an autocloseable info message. I will hide in 6 seconds.");

            _driver.FindElement(NormalInfo).Click();
            _driver.FindElement(NormalInfoMessage).Text.Should().Contain("I'm a normal info message. To close use the appropriate button.");

        }
    }
}
