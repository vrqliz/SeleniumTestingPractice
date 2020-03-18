using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace SeleniumSandbox.Tests.AlertsandModals
{
    public class BootstrapModalTests : IDisposable
    {
        private IWebDriver _driver;

        public By SingleModalLaunchButton = By.XPath("//a[contains(text(),'Launch modal')]");
        public By SingleModal = By.XPath("//*[@id='myModal0']/div/div");
        public By SingleModalClose = By.XPath("//a[contains(text(),'Close')]");

        public By MultiModalLaunchButton = By.XPath("(//a[contains(text(),'Launch modal')])[2]");
        public By MutliModal = By.XPath("//*[@id='myModal']/div/div");
        public By MultiModalLaunch = By.XPath("//*[@id='myModal']/div/div/div[3]/a");
        public By SecondMultiModal = By.XPath("//*[@id='myModal2']/div/div");
        public By SecondMultiModalClose = By.XPath("(//a[contains(text(),'Close')])[3]");
        public By MultiModalSave = By.XPath("(//a[contains(text(),'Save changes')])[2]");

        public BootstrapModalTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/bootstrap-modal-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(9000);
            _driver.Quit();
        }

        [Fact]
        public void BootstrapSinglePopupTest()
        {
            _driver.FindElement(SingleModalLaunchButton).Click();
            System.Threading.Thread.Sleep(2000);
            //_driver.FindElement(SingleModal);
            _driver.FindElement(SingleModalClose).Click();
        }

        [Fact]
        public void BootstrapMultiplePopupTest()
        {
            _driver.FindElement(MultiModalLaunchButton).Click();
            System.Threading.Thread.Sleep(2000);
            //_driver.FindElement(MutliModal);
            _driver.FindElement(MultiModalLaunch).Click();
            System.Threading.Thread.Sleep(2000);
            //_driver.FindElement(SecondMultiModal);
            _driver.FindElement(SecondMultiModalClose).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(MultiModalSave).Click();
        }
    }
}
