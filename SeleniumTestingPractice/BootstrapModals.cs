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
        public By SingleModal = By.XPath("//div[@id='myModal0']/div/div/div[3]");
        public By SingleModalClose = By.CssSelector("div.modal-footer > a.btn");
        public By MultipleModalLaunchButton = By.XPath("(//a[contains(text(),'Launch modal')])[2]");
        public By MutlipleModal = By.CssSelector("#myModal > div.modal-dialog > div.modal-content > div.modal-body");
        public By SecondMultiModal = By.XPath("(//a[contains(text(),'Launch modal')])[3]");
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
            _driver.FindElement(SingleModal).Text.Should().Contain("This is the place where the content for the modal dialog displays");
            _driver.FindElement(SingleModalClose).Click();
        }

        [Fact]
        public void BootstrapMultiplePopupTest()
        {
            _driver.FindElement(MultipleModalLaunchButton).Click();
            _driver.FindElement(MutlipleModal).Text.Should().Contain(" This is the place where the content for the modal dialog displays. Click launch modal button to launch second modal. Click close link to close the modal. Clicking on Save Changes button will close the modal and refresh the page");
            _driver.FindElement(MultipleModalLaunchButton).Click();
            _driver.FindElement(SecondMultiModal).Text.Should().Contain("This is the place where the content for the modal dialog displays.");
            _driver.FindElement(SecondMultiModalClose).Click();
        }
    }
}
