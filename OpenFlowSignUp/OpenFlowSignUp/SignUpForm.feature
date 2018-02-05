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
    |sampleuser1|sampleuser1@example.com|test123|

Scenario Outline: Missing required fields
    Given I am on the sign-up page
    And I leave a required field blank <username> <email> <password>
    When I click Register
    Then I should see the appropriate error for missing field

    Examples:
    |username       |email             |password|
    ||email@example.com|test1234|
    |     |email@example.com|test1234|
    |test1234||test1234|
    |test1234|email@example.com ||
    |||test1234|
    |test1234|||
    ||email@example.com||
    ||||

Scenario Outline: Incorrect field values
    Given I am on the sign-up page
    And I enter an invalid value for a field <username> <email> <password>
    When I click Register
    Then I should see the appropriate error for invalid value

    Examples:
    |username       |email             |password|
    |a|email@example.com|test1234|
    |!|email@example.com|test1234|
    |1|email@example.com|test1234|
    |anothertest|email @example.com|test1234|
    |anothertest|test@@example.com|test1234|
    |test098|email_test@example.com|test1|

Scenario Outline: Existing values
    Given I am on the sign-up page
    And I enter an existing value for a field <username> <email> <password>
    When I click Register
    Then I should see the appropriate error message

    Examples:
    |username       |email             |password|
    |test1234|newemail@example.com|test1234|
    |32312test1234|email@example.com|test1234|

Scenario: Existing user
    Given I am on the sign-up page
    When I click on Sign In
    Then I should be taken to the sign-in page

Scenario Outline: Language Selection
    Given I am on the sign-up page
    When I select a Language from the dropdown <id>
    Then I should see the correct values for the other fields

    Examples:
    # Testing a subset
    |id|
    |1|
    |5|
    |11|
    |21|
    |36|