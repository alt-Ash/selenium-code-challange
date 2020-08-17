## selenium-code-challange
*A solution that automated tests on the Boking.com Website*

## Challenge: Automate Tests for Booking.com Filters 

Write a set of Selenium tests for these new filters options, including a framework to support these tests.

### Instructions to make it the tests run 
1. Clones repository from GitHub
2. Report all NuGet packages for the solution -> necessary to ensure that the web drivers are installed
3. Set the test .runsettings file:
    1. From the top section of the VS IDE select "Test" -> the test section of VS will drop down
    2. From the list of options select "Configure Run Settings" -> a sidebar should open.
    3. From the options available click "Select solution-wide run settings file" -> A windows file explorer will open
    4. navigate to the location on your system where you have cloned the repo of this project
    5. Open the solution folder "BookingAutomtated.Selenium.Tests" -> The project folder should open 
    6. Inside you will find a file name "TextContext.runsettings" select this file to mark it as the run settings file for the tests. 
    
*I have included a link to the official Microsoft documentation for selecting test files for Visual Studio: https://docs.microsoft.com/en-us/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file?view=vs-2019

### Test Data
Location: Limerick
Dates: One night stay (3 months from today’s date)
Number of People: 2 adults
Room: 1 Room

### The Output
Tests that can validate certain Hotel are listed when filter options are applied. 

