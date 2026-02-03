# CSE2522 - Industrial Session on Software Testing and Validation
## Assignment 02 - UI Automation

This project contains automated UI tests for the [UI Testing Playground](http://uitestingplayground.com/) website. It uses C#, Selenium WebDriver, and NUnit.

### Project Structure
- **Pages**: Contains the Page Object Models (POM) for each test scenario.
- **Tests**: Contains the NUnit test classes organized by test case IDs.
- **Utilities**: Base classes for setup and teardown.

### Prerequisites
1. **Google Chrome**: Ensure you have the latest version of Chrome installed.
2. **.NET SDK**: This project targets .NET 10.
3. **IDE**: Visual Studio 2022 or VS Code.

### Setup Instructions
1. Clone the repository or download the source code.
2. Open the solution file in Visual Studio.
3. Restore the NuGet packages (the IDE usually does this automatically).

### How to Run Tests
1. Open the **Test Explorer** in Visual Studio.
2. Click **Run All** to execute all tests.
3. To run via Command Line (Terminal):
   ```bash
   dotnet test
   ```

### Test Cases Covered
- **TC001_1**: Text Input Verification
- **TC002_1 to TC002_3**: Sample App Login testing (Success/Unsuccess)
- **TC003_1**: Client Side Delay testing with loading indicator
- **TC004_1 to TC004_4**: Alerts, Confirms, and Prompt handling verification
