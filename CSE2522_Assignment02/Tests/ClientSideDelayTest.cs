using CSE2522_Assignment02.Pages;
using CSE2522_Assignment02.Utilities;
using NUnit.Framework;
using System.Threading;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class ClientSideDelayTest : BaseTest
    {
        private ClientSideDelayPage _delayPage;

        private void ShortPause()
        {
            Thread.Sleep(1000);
        }

        [TestCase(TestName = "TC003_1 - Client Side Delay - Verificaiton of the page")]
        public void TC003_1_ClientSideDelay()
        {
            _delayPage = new ClientSideDelayPage(driver);
            _delayPage.GoToPage();

            ShortPause();
            Assert.That(_delayPage.IsButtonDisplayed(), Is.True);

            _delayPage.ClickButton();
            Assert.That(_delayPage.IsSpinnerDisplayed(), Is.True);

            _delayPage.WaitForSpinnerToDisappear();

            string result = _delayPage.WaitForSuccessText();
            ShortPause();

            Assert.That(
                result,
                Is.EqualTo("Data calculated on the client side.")
            );
        }
    }
}
