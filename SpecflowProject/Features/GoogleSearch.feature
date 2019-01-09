Feature: Google Search
	As a frequent user of the site
	I want to test the search functionality.



Scenario: I want to check if the search page is fully loaded.
	Given I am on the homepage
	And I should see the page fully loaded
	When I search for the keyword "selenium"
	Then I should see selenium in the search results



Scenario Outline: I want to search the following keywords.
	Given I am on the homepage
	And I should see the page fully loaded
	When I search for following <Keywords>
	Then I should see following <Results>

	Scenarios: 
			  | Keywords  | Results   |
			  | microsoft | Microsoft - Official Home Page |
			  | audi      | Audi      |
			  | bmw       | BMW       |