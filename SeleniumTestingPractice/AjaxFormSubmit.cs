using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.InputForms
{
    public class AjaxFormDemoTests : IDisposable
    {
        private IWebDriver _driver;

        public By NameField = By.Id("title");
        public By CommentField = By.Id("description");
        public By Submit = By.Id("btn-submit");
        public By FormSubmitted = By.Id("submit-control");

        public AjaxFormDemoTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/ajax-form-submit-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void AjaxFormTest()
        {
            _driver.FindElement(NameField).SendKeys("John Doe");
            _driver.FindElement(CommentField).SendKeys("Sample Comment");
            _driver.FindElement(Submit).Click();
            _driver.FindElement(FormSubmitted).Text.Contains("Ajax Request is Processing!");
            _driver.FindElement(FormSubmitted).Text.Contains("Form submitted Successfully!");
        }
    }
}
