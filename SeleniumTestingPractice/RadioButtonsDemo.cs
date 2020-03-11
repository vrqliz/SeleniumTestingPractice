using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.InputForms
{
    public class RadioButtonsTests : IDisposable
    {
        private IWebDriver _driver;

        public By MaleRadio = By.CssSelector(".radio-inline [name='optradio'][value='Male']");
        public By FemaleRadio = By.CssSelector(".radio-inline [name='optradio'][value='Female']");
        public By GetCheckedValue = By.Id("buttoncheck");
        public By CheckedValue = By.ClassName("radiobutton");

        public By GroupMaleRadio = By.CssSelector(".radio-inline [name='gender'][value='Male']");
        public By GroupFemaleRadio = By.CssSelector(".radio-inline [name='gender'][value='Female']");

        public By ZeroToFive = By.CssSelector(".radio-inline [name='ageGroup'][value='0 - 5']");
        public By FiveToFifthteen = By.CssSelector(".radio-inline [name='ageGroup'][value='5 - 15']");
        public By FifthteenToFifty = By.CssSelector(".radio-inline [name='ageGroup'][value='15 - 50']");
        public By GetValues = By.CssSelector("button[onclick='getValues();']");
        public By Values = By.ClassName("groupradiobutton");

        public RadioButtonsTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(10000);
            _driver.Quit();
        }

        [Fact]
        public void SingleRadioButtons()
        {
            _driver.FindElement(MaleRadio).Click();
            _driver.FindElement(GetCheckedValue).Click();
            _driver.FindElement(CheckedValue).Text.Should().Be("Radio button 'Male' is checked");

            _driver.FindElement(FemaleRadio).Click();
            _driver.FindElement(GetCheckedValue).Click();
            _driver.FindElement(CheckedValue).Text.Should().Be("Radio button 'Female' is checked");
        }

        [Fact]
        public void GroupRadioButtons()
        {
            _driver.FindElement(GroupMaleRadio).Click();
            _driver.FindElement(ZeroToFive).Click();
            _driver.FindElement(GetValues).Click();
            _driver.FindElement(Values).Text.Should().Contain("Sex : Male");
            _driver.FindElement(Values).Text.Should().Contain("Age group: 0 - 5");


        }
    }
}