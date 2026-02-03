using OpenQA.Selenium;

namespace CSE2522_Assignment02.Pages
{
    public class TextInputPage
    {
        private readonly IWebDriver _driver;

        private const string BaseUrl = "http://uitestingplayground.com/";

        public TextInputPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Locators
        private readonly By _textInputBox = By.Id("newButtonName");
        private readonly By _updateButton = By.Id("updatingButton");

        public void GoToPage()
        {
            _driver.Navigate().GoToUrl(BaseUrl);
            _driver.FindElement(By.LinkText("Text Input")).Click();
        }

        public void EnterText(string text)
        {
            _driver.FindElement(_textInputBox).Clear();
            _driver.FindElement(_textInputBox).SendKeys(text);
        }

        public void ClickButton()
        {
            _driver.FindElement(_updateButton).Click();
        }

        public string GetButtonText()
        {
            return _driver.FindElement(_updateButton).Text;
        }

        public bool IsInputBoxDisplayed()
        {
            return _driver.FindElement(_textInputBox).Displayed;
        }

        public bool IsButtonDisplayed()
        {
            return _driver.FindElement(_updateButton).Displayed;
        }
    }
}
