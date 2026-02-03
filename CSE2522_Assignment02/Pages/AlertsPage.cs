using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSE2522_Assignment02.Pages
{
    public class AlertsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private const string BaseUrl = "http://uitestingplayground.com/";

        public AlertsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // Locators
        private readonly By _alertBtn = By.Id("alertButton");
        private readonly By _confirmBtn = By.Id("confirmButton");
        private readonly By _promptBtn = By.Id("promptButton");

        public void GoToPage()
        {
            _driver.Navigate().GoToUrl(BaseUrl);
            _driver.FindElement(By.LinkText("Alerts")).Click();
        }

        public void ClickAlertButton() => _driver.FindElement(_alertBtn).Click();
        public void ClickConfirmButton() => _driver.FindElement(_confirmBtn).Click();
        public void ClickPromptButton() => _driver.FindElement(_promptBtn).Click();

        public bool AreAllButtonsDisplayed()
        {
            return _driver.FindElement(_alertBtn).Displayed
                && _driver.FindElement(_confirmBtn).Displayed
                && _driver.FindElement(_promptBtn).Displayed;
        }

        private IAlert WaitUntilAlertAppears()
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public string GetAlertText()
        {
            return WaitUntilAlertAppears().Text;
        }

        public void AcceptAlert()
        {
            WaitUntilAlertAppears().Accept();
        }

        public void DismissAlert()
        {
            WaitUntilAlertAppears().Dismiss();
        }

        public void TypeInAlert(string text)
        {
            WaitUntilAlertAppears().SendKeys(text);
        }
    }
}
