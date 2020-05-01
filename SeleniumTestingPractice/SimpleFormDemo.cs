using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.InputForms
{
    public class SimpleFormDemoTests : IDisposable
    {
        private IWebDriver _driver;

        public By enterMessageField = By.Id("user-message");
        public By showMessageButton = By.CssSelector("button.btn-default[onclick='showInput();']");
        public By yourMessageText = By.Id("display");

        public By enterAField = By.Id("sum1");
        public By enterBField = By.Id("sum2");
        public By getTotalButton = By.CssSelector("button.btn-default[onclick='return total()']");
        public By yourTotalValue = By.Id("displayvalue");



        public SimpleFormDemoTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(10000);
            _driver.Quit();
        }

        [Fact]
        public void SingleInputFieldTest()
        {
            _driver.FindElement(enterMessageField).SendKeys("Sample Message");
            _driver.FindElement(showMessageButton).Click();

            _driver.FindElement(yourMessageText).Text.Should().Be("Sample Message"); jkhjadf
        }

        [Fact]
        public void TwoInputFieldsTest()
        {
            _driver.FindElement(enterAField).SendKeys("1");
            _driver.FindElement(enterBField).SendKeys("2");
            _driver.FindElement(getTotalButton).Click();

            _driver.FindElement(yourTotalValue).Text.Should().Be("3");
        }
    }
}
