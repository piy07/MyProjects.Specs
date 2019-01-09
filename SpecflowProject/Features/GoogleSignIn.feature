Feature: Google Sign In
	In order to login with a registered user
	I want to check the sign in functionality.

@mytag
Scenario: Sign In with registered user.
	Given I am on google homepage
	And  Sign in button displayed on the page
	When I click on the Sign In button
	Then I should be on the Sign In page
	Then I fill in email field with email "doe777530@gmail.com"
	When  I click Next button
	Then I should see the password field
	Then I fill password field with password "test@1234"
	When I click Next button
	Then I should be on the homepage
	And I should see the user "doe777530@gmail.com" logged in successfully


