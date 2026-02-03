using CSE2522_Assignment02.Pages;
using CSE2522_Assignment02.Utilities;
using NUnit.Framework;
using System.Threading;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class AlertsTest : BaseTest
    {
        private AlertsPage _alertsPage;

        private void ShortPause()
        {
            Thread.Sleep(1000);
        }

        [TestCase(TestName = "TC004_1 - Alerts - Verification of the Alerts page")]
        public void TC004_1_PageVerification()
        {
            _alertsPage = new AlertsPage(driver);
            _alertsPage.GoToPage();

            Assert.That(
                _alertsPage.AreAllButtonsDisplayed(),
                Is.True,
                "Not all alert buttons are visible on the page."
            );
        }

        [TestCase(TestName = "TC004_2 - Alerts - Verification of the Alert text")]
        public void TC004_2_AlertTextVerification()
        {
            _alertsPage = new AlertsPage(driver);
            _alertsPage.GoToPage();

            ShortPause();
            _alertsPage.ClickAlertButton();

            string alertText = _alertsPage.GetAlertText();
            Assert.That(
                alertText,
                Does.Contain("Today is a working day")
                    .And.Contain("less likely a holiday")
            );

            ShortPause();
            _alertsPage.AcceptAlert();
        }

        [TestCase(TestName = "TC004_3 - Alerts - Verification of the Alert text depneding on the first alert")]
        public void TC004_3_ConfirmWorkflow()
        {
            _alertsPage = new AlertsPage(driver);
            _alertsPage.GoToPage();

            ShortPause();
            _alertsPage.ClickConfirmButton();

            string firstMessage = _alertsPage.GetAlertText();
            Assert.That(firstMessage, Does.Contain("Friday").And.Contain("agree"));

            ShortPause();
            _alertsPage.AcceptAlert();

            string yesResult = _alertsPage.GetAlertText();
            Assert.That(yesResult, Is.EqualTo("Yes"));

            ShortPause();
            _alertsPage.AcceptAlert();

            ShortPause();
            _alertsPage.ClickConfirmButton();
            ShortPause();
            _alertsPage.DismissAlert();

            string noResult = _alertsPage.GetAlertText();
            Assert.That(noResult, Is.EqualTo("No"));

            ShortPause();
            _alertsPage.AcceptAlert();
        }

        [TestCase(TestName = "TC004_4 - Alerts - Verification of the Alert prompt")]
        public void TC004_4_PromptWorkflow()
        {
            _alertsPage = new AlertsPage(driver);
            _alertsPage.GoToPage();

            ShortPause();
            _alertsPage.ClickPromptButton();

            string promptMessage = _alertsPage.GetAlertText();
            Assert.That(promptMessage, Is.Not.Null.And.Not.Empty);

            string inputName = "Nethmi";
            _alertsPage.TypeInAlert(inputName);

            ShortPause();
            _alertsPage.AcceptAlert();

            string acceptedResult = _alertsPage.GetAlertText();
            Assert.That(
                acceptedResult.ToLower(),
                Does.Contain("user value").And.Contain(inputName.ToLower())
            );

            ShortPause();
            _alertsPage.AcceptAlert();

            ShortPause();
            _alertsPage.ClickPromptButton();
            ShortPause();
            _alertsPage.DismissAlert();

            string cancelledResult = _alertsPage.GetAlertText();
            Assert.That(
                cancelledResult.ToLower(),
                Does.Contain("user value").And.Contain("no answer")
            );

            ShortPause();
            _alertsPage.AcceptAlert();
        }
    }
}
