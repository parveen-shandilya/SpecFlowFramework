Feature: Login into Agency

Test Agency user login

@1
Scenario: 1 | Verify the URL of the Agency
	Given Open the Browser
	When  Enter the URL
	Then  Login is page opened

@2
Scenario: 2 | Verify the URL of the Agency is not wrong
	Given Open the Browser
	When  Enter the URL
	Then  Login is page opened is not Wrong