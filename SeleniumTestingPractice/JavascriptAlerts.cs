using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.AlertsandModals
{
    public class JavasScriptAlertTests : IDisposable
    {
        private IWebDriver _driver;

        public By AlertBox = By.CssSelector("button.btn.btn-default[onclick='myAlertFunction()']");
        public By ConfirmationBox = By.CssSelector("button.btn.btn-default[onclick='myConfirmFunction()']");
        public By PromptBox = By.CssSelector("button.btn.btn-default[onclick='myPromptFunction()']");
        public By ConfirmationMessage = By.Id("confirm-demo");
        public By PromptConfirmation = By.Id("prompt-demo");

        public JavasScriptAlertTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(9000);
            _driver.Quit();
        }

        [Fact]
        public void JavascriptAlertBoxesTest()
        {
            _driver.FindElement(AlertBox).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Alert().Text.Should().Contain("I am an alert box!");
            _driver.SwitchTo().Alert().Accept();

            _driver.FindElement(ConfirmationBox).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Alert().Text.Should().Contain("Press a button!");
            _driver.SwitchTo().Alert().Accept();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(ConfirmationMessage).Text.Should().Contain("You pressed OK!");

            _driver.FindElement(ConfirmationBox).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Alert().Text.Should().Contain("Press a button!");
            _driver.SwitchTo().Alert().Dismiss();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(ConfirmationMessage).Text.Should().Contain("You pressed Cancel!");

            _driver.FindElement(PromptBox).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Alert().SendKeys("John Doe");
            _driver.SwitchTo().Alert().Accept();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(PromptConfirmation).Text.Should().Contain("John Doe");
        }
    }
}
