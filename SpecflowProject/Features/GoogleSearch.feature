Feature: Google Search
	As a frequent user of the site
	I want to test the search functionality.



Scenario: I want to if the search page is fully loaded.
	Given I am on the homepage
	And I should see the page fully loaded
	When I search for the keyword "selenium"
	Then I should see selenium in the search results