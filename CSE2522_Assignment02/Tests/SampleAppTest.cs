using CSE2522_Assignment02.Pages;
using CSE2522_Assignment02.Utilities;
using NUnit.Framework;
using System.Threading;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class SampleAppTest : BaseTest
    {
        private SampleAppPage _sampleAppPage;

        private void ShortPause()
        {
            Thread.Sleep(1000);
        }

        [TestCase(TestName = "TC002_1 - Sample App - Verification of the sample app page")]
        public void TC002_1_VerifyPage()
        {
            _sampleAppPage = new SampleAppPage(driver);
            _sampleAppPage.GoToPage();

            Assert.That(
                _sampleAppPage.IsPageLoaded(),
                Is.True,
                "Sample App page did not load."
            );
        }

        [TestCase(TestName = "TC002_2 - Sample App - Verification of a successful login")]
        public void TC002_2_SuccessfulLogin()
        {
            _sampleAppPage = new SampleAppPage(driver);
            _sampleAppPage.GoToPage();

            ShortPause();
            _sampleAppPage.Login("Nethmi", "pwd");

            ShortPause();
            Assert.That(
                _sampleAppPage.GetLoginStatus(),
                Is.EqualTo("Welcome, Nethmi!")
            );
        }

        [TestCase(TestName = "TC002_3 - Sample App - Verification of an unsuccessful login")]
        public void TC002_3_UnsuccessfulLogin()
        {
            _sampleAppPage = new SampleAppPage(driver);
            _sampleAppPage.GoToPage();

            ShortPause();
            _sampleAppPage.Login("Nethmi", "WrongPassword");

            ShortPause();
            Assert.That(
                _sampleAppPage.GetLoginStatus(),
                Is.EqualTo("Invalid username/password")
            );
        }
    }
}
