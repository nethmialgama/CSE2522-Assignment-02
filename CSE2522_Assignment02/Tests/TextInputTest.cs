using CSE2522_Assignment02.Pages;
using CSE2522_Assignment02.Utilities;
using NUnit.Framework;
using System.Threading;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class TextInputTest : BaseTest
    {
        private TextInputPage _textInputPage;

        private void ShortPause()
        {
            Thread.Sleep(1000);
        }

        [TestCase(TestName = "TC001_1 - Text Input - Verificaiton of the page")]
        public void TC001_1_VerifyPageLoad()
        {
            _textInputPage = new TextInputPage(driver);
            _textInputPage.GoToPage();

            ShortPause();
            Assert.That(_textInputPage.IsInputBoxDisplayed(), Is.True);
            Assert.That(_textInputPage.IsButtonDisplayed(), Is.True);

            string inputText = "Nethmi";
            _textInputPage.EnterText(inputText);

            ShortPause();
            _textInputPage.ClickButton();

            ShortPause();
            Assert.That(
                _textInputPage.GetButtonText(),
                Is.EqualTo(inputText)
            );
        }
    }
}
