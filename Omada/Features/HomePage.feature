Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: End to end test cases
	When I have open home test page
	Then I want check if header elements are displayed
	And I want to check if footer is displayed
	When I want to search for 'gartner'
	Then I want to check if there is more then 6 results
	#And I want to check that there is 'There is Safety in Numbers' among those results
	When I want to click 'Gartner IAM Summit 2016 - London' link
	Then I want to check if I am redirected to page with 'Gartner IAM Summit 2016 - London' title
	When I navigate to News
	Then I want to check if I am redirected to page'Omada News' page
	And I want to check if there is 'Gartner IAM Summit 2016 - London' news
	When I have open home test page
	And I want to click Contact
	Then I want to click U.S West
	And I want to mouseover Germany

Scenario: Search phrase
	When I have open home test page
	Then I want check if header elements are displayed
	And I want to check if footer is displayed
	When I want to search for 'gartner'
	Then I want to check that there is 'worldwide companies' among those results



Scenario: Privacy Policy
	When I have open home test page
	When I want to click Contact
	Then I open privacy policy in new tab
	When I want to close tab
	When I want to close privacy policy
	Then I want to check if privacy policy is no longer visible

Scenario: Download PDF file
	When I have open home test page
	When I want to close privacy policy
	And I click Cases from Resources
	And I click download for 'ecco' company
	And I fill all require fields
	| JobTitle | FirstName | LastName | Email               | BusinessPhone | CompanyName | Country |
	| Tester   | Michal    | Test     | local@localhost.com | 12345678      | Test        | Poland  |
	And I click accept
	And I Unlock form by sliding slider
	And I click download button
	And I click Download Customer Case
	And I wait till download of file 'Omada-Case-ECCO-Shoes.pdf' finish

Scenario: Close multiple tabs
	When I have open home test page
	When I want to open multiple tabs
	When I want to close tab


	