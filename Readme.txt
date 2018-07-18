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
	#I don't understand that step, it is not clear to me
	#And I want to check that there is There is Safety in Numbers among those
	When I want to click 'Gartner IAM Summit 2016 - London' link
	Then I want to check if I am redirected to page with 'Gartner IAM Summit 2016 - London' title
	When I navigate to News
	Then I want to check if I am redirected to page'Omada News' page
	And I want to check if there is 'Gartner IAM Summit 2016 - London' news
	When I have open home test page
	And I want to click Contact