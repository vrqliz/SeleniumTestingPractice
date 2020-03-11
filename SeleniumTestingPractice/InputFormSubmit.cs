using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.InputForms
{
    public class InputFormDemo : IDisposable
    {
        private IWebDriver _driver;

        public By FirstName = By.CssSelector("input[name='first_name']");
        public By LastName = By.CssSelector("input[name='last_name']");
        public By EMail = By.CssSelector("input[name='email']");
        public By Phone = By.CssSelector("input[name='phone']");
        public By Address = By.CssSelector("input[name='address']");
        public By City = By.CssSelector("input[name='city']");
        public By State = By.CssSelector("select[name='state']");
        public By Zip = By.CssSelector("input[name='zip']");
        public By Website = By.CssSelector("input[name='website']");
        public By NoRadio = By.CssSelector("input[value='no']");
        public By ProjectDesc = By.CssSelector("textarea[name='comment']");
        public By Send = By.CssSelector("button[type='submit']");


        public InputFormDemo()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/input-form-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void InputFields()
        {
            _driver.FindElement(FirstName).SendKeys("John");
            _driver.FindElement(LastName).SendKeys("Doe");
            _driver.FindElement(EMail).SendKeys("john.doe@gmail.com");
            _driver.FindElement(Phone).SendKeys("704-555-5555");
            _driver.FindElement(Address).SendKeys("5555 Central Ave");
            _driver.FindElement(City).SendKeys("Charlotte");
            _driver.FindElement(State).Click();
            SelectElement selectState = new SelectElement(_driver.FindElement(State));
            selectState.SelectByText("North Carolina");
            _driver.FindElement(Zip).SendKeys("28207");
            _driver.FindElement(Website).SendKeys("IP address");
            _driver.FindElement(NoRadio).Click();
            _driver.FindElement(ProjectDesc).SendKeys("Project descrption comment.");
            _driver.FindElement(Send).Click();

        }
    }
}
