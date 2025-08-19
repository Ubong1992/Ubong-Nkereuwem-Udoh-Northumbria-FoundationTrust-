
#Framework
This is an automation framework using playwright,Regnoroll(Specflow),Dotnet8,Dependency Injection(DI).POM(Page object model and C#
To test the Northumbria trust foundation nhs website.

# Installation
Clone the repository and install the required dependencies
git clone git@github.com:Ubong1992/Ubong-Nkereuwem-Udoh-Northumbria-FoundationTrust-.git
cd Ubong-Nkereuwem-Udoh-Northumbria-FoundationTrust
dotnet build - to build the project


# Prerequisites
Required Software

To run the tests and the project, make sure you have the following installed:
Visual Studio 2022
https://visualstudio.microsoft.com/vs/community/

Playwright
Install Playwright
https://playwright.dev/

Gherkin
Required for writing and running BDD tests.

Cucumber
For BDD-style test automation integration.

Regnoroll
Dependency Injection and SpecFlow support.

xUnit
Test framework used for the automation suite.


# To run the test and build the project, you need to have the following dependencies installed:
dotnet build - to build the project
dotnet test - to run the tests from command line

# Configuring the Test Environment
The browser type can be configured in the appsettings.json file.
The test suite can be set up to run in different environments (e.g., Test, Staging). Modify your environment settings accordingly in appsettings.json.

# Supported platforms and Browsers
The user of the projet needs to change the browser type in the appsettings.json file
Chrome/Chromium and Firefox (window,linux and Mac machine)

# To update the appsettings file
git restore appsettings.json

# To see the status of the project and uncommitted changes:
git status

# Further improvement plan
CI/CD Integration: Automate test runs on a schedule or trigger from code commits.
Cross-browser Testing: Add support for mobile and tablet devices.
Test Reporting: Integrate detailed test reporting and analytics.

