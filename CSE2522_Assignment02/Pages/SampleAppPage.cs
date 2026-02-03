using OpenQA.Selenium;

namespace CSE2522_Assignment02.Pages
{
    public class SampleAppPage
    {
        private readonly IWebDriver _driver;

        private const string BaseUrl = "http://uitestingplayground.com/";

        public SampleAppPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Locators
        private readonly By _userNameField = By.Name("UserName");
        private readonly By _passwordField = By.Name("Password");
        private readonly By _loginButton = By.Id("login");
        private readonly By _loginStatus = By.Id("loginstatus");

        public void GoToPage()
        {
            _driver.Navigate().GoToUrl(BaseUrl);
            _driver.FindElement(By.LinkText("Sample App")).Click();
        }

        public void Login(string user, string pass)
        {
            _driver.FindElement(_userNameField).Clear();
            _driver.FindElement(_userNameField).SendKeys(user);

            _driver.FindElement(_passwordField).Clear();
            _driver.FindElement(_passwordField).SendKeys(pass);

            _driver.FindElement(_loginButton).Click();
        }

        public string GetLoginStatus()
        {
            return _driver.FindElement(_loginStatus).Text;
        }

        public bool IsPageLoaded()
        {
            return _driver.FindElement(_loginButton).Displayed
                && _driver.FindElement(_userNameField).Displayed
                && _driver.FindElement(_passwordField).Displayed;
        }
    }
}
