using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.ProgressBars
{
    public class DragDropSlidersTests : IDisposable
    {
        private IWebDriver _driver;

        public By SliderOne = By.XPath("//div[@id='slider1']/div/input");
        public By SliderOneValue = By.XPath("//div[@id='slider1']/div/output");
        public By SliderTwo = By.XPath("//div[@id='slider2']/div/input");
        public By SliderTwoValue = By.XPath("//div[@id='slider2']/div/output");
        public By SliderThree = By.XPath("//div[@id='slider3']/div/input");
        public By SliderThreeValue = By.XPath("//div[@id='slider3']/div/output");
        public By SliderFour = By.XPath("//div[@id='slider4']/div/input");
        public By SliderFourValue = By.XPath("//div[@id='slider4']/div/output");
        public By SliderFive = By.XPath("//div[@id='slider5']/div/input");
        public By SliderFiveValue = By.XPath("//div[@id='slider5']/div/output");
        public By SliderSix = By.XPath("//div[@id='slider6']/div/input");
        public By SliderSixValue = By.XPath("//div[@id='slider6']/div/output");


        public DragDropSlidersTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/drag-drop-range-sliders-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }

        [Fact]
        public void SliderOneTest()
        {
            _driver.FindElement(SliderOne).Click();
            Actions slide = new Actions(_driver);
            slide.ClickAndHold(_driver.FindElement(SliderOne));
            slide.DragAndDropToOffset(_driver.FindElement(SliderOne),70,0).Build().Perform();
            _driver.FindElement(SliderOneValue).Text.Should().Be("80");
        }

        [Fact]
        public void SliderTwoTest()
        {
            _driver.FindElement(SliderTwo).Click();
            Actions slide = new Actions(_driver);
            slide.ClickAndHold(_driver.FindElement(SliderTwo));
            slide.DragAndDropToOffset(_driver.FindElement(SliderTwo), 50, 0).Build().Perform();
            _driver.FindElement(SliderTwoValue).Text.Should().Be("71");
        }

        [Fact]
        public void SliderThreeTest()
        {
            _driver.FindElement(SliderThree).Click();
            Actions slide = new Actions(_driver);
            slide.ClickAndHold(_driver.FindElement(SliderThree));
            slide.DragAndDropToOffset(_driver.FindElement(SliderThree), 20, 0).Build().Perform();
            _driver.FindElement(SliderThreeValue).Text.Should().Be("59");
        }

        [Fact]
        public void SliderFourTest()
        {
            _driver.FindElement(SliderFour).Click();
            Actions slide = new Actions(_driver);
            slide.ClickAndHold(_driver.FindElement(SliderFour));
            slide.DragAndDropToOffset(_driver.FindElement(SliderFour), 40, 0).Build().Perform();
            _driver.FindElement(SliderFourValue).Text.Should().Be("67");
        }

        [Fact]
        public void SliderFiveTest()
        {
            _driver.FindElement(SliderFive).Click();
            Actions slide = new Actions(_driver);
            slide.ClickAndHold(_driver.FindElement(SliderFive));
            slide.DragAndDropToOffset(_driver.FindElement(SliderFive), 90, 0).Build().Perform();
            _driver.FindElement(SliderFiveValue).Text.Should().Be("88");
        }

        [Fact]
        public void SliderSixTest()
        {
            _driver.FindElement(SliderSix).Click();
            Actions slide = new Actions(_driver);
            slide.ClickAndHold(_driver.FindElement(SliderSix));
            slide.DragAndDropToOffset(_driver.FindElement(SliderSix), 10, 0).Build().Perform();
            _driver.FindElement(SliderSixValue).Text.Should().Be("55");
        }

    }
}
