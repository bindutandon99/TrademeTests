

## Index
1. Project Description
2. Instructions/Pre-requisites for running the tests
3. Tests
    1. API tests
    1. Web UI tests

4. Executing tests from command line
    1. Run API tests
    1. Run Web UI tests
5. Executing tests from Visual Studio 


## Project Description

  This project is Web UI and API Test Suite containing tests for performing certain search scenarios on Trade Me sandbox using BDD approach.
  
  Test Scenarios -
  
  1) UI test - To perform a property Search based on certain filters(property type , region) and verify key details for the property selected.
  2) API test - To verify the number of the named car brands available 


## Instructions/Prequisites for running the tests

1. Automation framework and code have been implemented using .NET 6.0 and C# as the language 
2. .NET Core 6.0 can be downloaded from https://dotnet.microsoft.com/download/dotnet-core/6.0
3. I have used Microsoft Visual Studio(VS) 2022 community edition(https://visualstudio.microsoft.com/downloads/) as the IDE during development. 
4. If not already there, SpecFlow Visual Studio Extension needs to be installed for BDD/Gherkin support.
   To install -
   Go to Extensions > Manage Extensions in Visual Studio, search for SpecFlow for Visual Studio, and install it.
   Once installed, restart Visual Studio to enable all the SpecFlow features.
5.  To run tests from Visual Studio, please see section 'Executing tests from visual studio' section below.
6. Tests can be run from command line without using VS as well. Please check the 'Executing tests from command line' section below for more information.
7. chromedriver.exe version 130.0.6723.116 is required to run the tests, If your chrome browser version is lower than 130.0.6723.116, you have to upgrade.
8. Make sure chromedriver.exe is not being used by any other process during test execution. Use "taskkill -f -im chromedriver.exe" to kill if it's being used.

## Download  Code
Clone the repository 
```bash
git clone  git@github.com:bindutandon99/TrademeTests.git or https://github.com/bindutandon99/TrademeTests.git
```
## Tests

The solution has two test projects (API and Web UI)

### API tests

1. API tests have been automated using .NET Http client and NUnit test framework using SpecFlow/BDD.

### Web UI tests

1. Automated tests use Specflow/Selenium Webdriver and BDD approach.


## Executing tests from command line

### Run API tests

1. Navigate to API Test folder where you can find the *.csproj file e.g. C:\Users\xxxx\source\repos\TreademeAPItests\TrademeAPITests.csproj
2. Open command line and run "dotnet test -v m --logger trx TrademeAPITests.csproj"
3. After test run is finished , open TestResults to see the test result trx file.When trx file is opened,click on Test run completed(hyperlink on lower left) from test results for more details.
 

### Run Web UI tests
1. Navigate to UI Test folder where you can find the *.csproj file e.g. C:\Users\xxxx\source\repos\TreademeUItests\TrademeWebUITests.csproj
2. Open command line and run "dotnet test -v m --logger trx TrademeWebUITests.csproj"
3. After test run is finished , open TestResults to see the test result trx file. When trx file is opened,click on Test run completed(hyperlink on lower left) from test results for more details.
 

## Executing tests from Visual studio 

1. Select Test > Test Explorer from the Visual Studio menu
2. After successful compilation, you should see tests in the Test Explorer panel.
3. Right-click and run all or selected tests. For reference, Automation Tests Results Screenshots.docx. can be viewed.