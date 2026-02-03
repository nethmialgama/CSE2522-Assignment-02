using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace CSE2522_Assignment02.Pages
{
    public class ClientSideDelayPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private const string BaseUrl = "http://uitestingplayground.com/";

        public ClientSideDelayPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        // Locators
        private readonly By _triggerButton = By.Id("ajaxButton");
        private readonly By _spinner = By.Id("spinner");
        private readonly By _successMessage = By.ClassName("bg-success");

        public void GoToPage()
        {
            _driver.Navigate().GoToUrl(BaseUrl);
            _driver.FindElement(By.LinkText("Client Side Delay")).Click();
        }

        public void ClickButton()
        {
            _driver.FindElement(_triggerButton).Click();
        }

        public bool IsButtonDisplayed()
        {
            return _driver.FindElement(_triggerButton).Displayed;
        }

        public bool IsSpinnerDisplayed()
        {
            return _driver.FindElement(_spinner).Displayed;
        }

        public void WaitForSpinnerToDisappear()
        {
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_spinner));
        }

        public string WaitForSuccessText()
        {
            IWebElement element =
                _wait.Until(ExpectedConditions.ElementIsVisible(_successMessage));
            return element.Text;
        }
    }
}
