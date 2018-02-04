Feature: SignUp
	In order to be able to access the boards
	As a new user
	I want to be able to sign up successfully
	
@mytag
Scenario Outline: Register new user
	Given I am on the sign-up page
	And I have entered a valid Username <username>
    And I have entered a valid Email <email>
    And I have entered a valid Password <password>
	When I click Register
	Then I should be signed-in

    Examples:
    |username       |email             |password|
    |test1234       |email@example.com |test1234|