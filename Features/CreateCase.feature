Feature: Create Case 

Test Case Creation and Data Driven Testing Implementation

Background: 
	Given User logged into Application
	

@11
Scenario: 11 | Verify the User is on Create Case Page
		When User Click on plus and Code Enforcemetn Case Option
		Then I see user is on 'Create A Case' page

@12
Scenario Outline: 12 | Verify the User is on Create Case Page Example
		When User Click on plus and Code Enforcemetn Case Option
		Then  I See user is on <Page>
		Examples: 
		| Page                |
		| Create A Case       |
		| Create A Submission |

@14
Scenario: 14 | Verify the User is on Create Case Page DataTable
		When User Click on plus and Code Enforcemetn Case Option
		Then I see user is on create case pagePopup		
		| headerName          |
		| Create A Case       |
		| Create A Submission |
