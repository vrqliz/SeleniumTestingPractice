using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using Xunit;

namespace SeleniumSandbox.Tests.AlertsandModals
{
    public class WindowModalTests : IDisposable
    {
        private IWebDriver _driver;

        public By FollowOnTwitter = By.XPath("//a[contains(text(),'Follow On Twitter')]");
        public By FollowOnFacebook = By.XPath("//a[contains(text(),'Like us On Facebook')]");

        public By FollowTwitterFacebook = By.XPath("//a[contains(text(),'Follow Twitter & Facebook')]");
        public By FollowAll = By.XPath("//a[contains(text(),'Follow All')]");

        public WindowModalTests()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/window-popup-modal-demo.html";
        }

        public void Dispose()
        {
            System.Threading.Thread.Sleep(9000);
            _driver.Quit();
        }

        [Fact]
        public void SingleWindowPopupTest()
        {
            _driver.FindElement(FollowOnTwitter).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.SwitchTo().Window(_driver.WindowHandles.Last()).Close();
            _driver.SwitchTo().Window(_driver.WindowHandles.ToList().First());
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(FollowOnFacebook).Click();
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.SwitchTo().Window(_driver.WindowHandles.Last()).Close();
            _driver.SwitchTo().Window(_driver.WindowHandles.ToList().First());

        }

        [Fact]
        public void MultipleWindowPopupTest()
        {
            _driver.FindElement(FollowTwitterFacebook).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.SwitchTo().Window(_driver.WindowHandles.Last()).Close();
            _driver.SwitchTo().Window(_driver.WindowHandles.ToList().First());
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(FollowAll).Click();
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.SwitchTo().Window(_driver.WindowHandles.Last()).Close();
            _driver.SwitchTo().Window(_driver.WindowHandles.ToList().First());
        }
    }
}
